using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustMan = HBM.CustomerManagement;

namespace HBM
{
    public partial class Customers : System.Web.UI.Page
    {


        public CustMan.Customer CustomerObj
        {
            get 
            {
                CustMan.Customer customer;
                if (Session["CustomerObj"] == null)
                {
                    customer = new CustMan.Customer();
                    customer.CustomerId = Int32.Parse(hdnCustomerId.Value.Trim() == String.Empty ? "0" : hdnCustomerId.Value.Trim());
                    customer.CompanyId = Master.CompanyId;
                    customer.Select();
                }
                else
                {
                    customer = (CustMan.Customer)Session["CustomerObj"];
                }
                return customer;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.ClearSessions();
                CheckFromURL();
                LoadInitialData();
                SetData();
            }
        }

        /// <summary>
        /// Load all lookup data with this method
        /// </summary>
        private void LoadInitialData()
        {
            //Load Guest Type


            //Load CC Type


            //Load Country


        }

        private void SetData()
        {
            txtCustomerName.Text = CustomerObj.CustomerName;
            txtBillingAddress.Text = CustomerObj.BillingAddress;
            txtBillingCity.Text = CustomerObj.BillingCity;
            cmbBillingCountry.SelectedItem.Value = CustomerObj.BillingCountry;

            txtBillingPostCode.Text = CustomerObj.BillingPostCode;
            txtBillingState.Text = CustomerObj.BillingState;
            cmbCar.SelectedItem.Text = CustomerObj.Car;
            txtLicensePlate.Text = CustomerObj.CarLicensePlate;

            if (CustomerObj.CCExpirationDate.HasValue)
            {
                cmbCCExpiryDateMonth.SelectedItem.Value = CustomerObj.CCExpirationDate.Value.Month;
                cmbCCExpiryDateYear.SelectedItem.Value = CustomerObj.CCExpirationDate.Value.Year;
            }

            txtNameOnCard.Text = CustomerObj.CCNameOnCard;
            txtCCNumber.Text = CustomerObj.CCNo.HasValue ? CustomerObj.CCNo.Value.ToString() : string.Empty;

            cmbCCType.SelectedItem.Value = CustomerObj.CCType.Value;
            txtCompanyAddress.Text = CustomerObj.CompanyAddress;
            txtCompanyName.Text = CustomerObj.CompanyName;
            txtNotes.Text = CustomerObj.CompanyNotes;
            txtDriveLicense.Text = CustomerObj.DriverLicense;
            txtEmail.Text = CustomerObj.Email;
            txtFax.Text = CustomerObj.Fax;
            cmbGender.SelectedItem.Text = CustomerObj.Gender;
            txtMemberCode.Text = CustomerObj.MemberCode;

            txtPhone.Text = CustomerObj.Mobile;
            txtCountryOfIssue.Text = CustomerObj.PassportCountryOfIssue;

            if (CustomerObj.PassportExpirationDate.HasValue)
            {
                dtpExpiryDate.Date = CustomerObj.PassportExpirationDate.Value;
            }

            txtPassportNumber.Text = CustomerObj.PassportNumber;
            txtPhone.Text = CustomerObj.Phone;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomerObj.CustomerName = txtCustomerName.Text.Trim();
            CustomerObj.BillingAddress = txtBillingAddress.Text.Trim();
            CustomerObj.BillingCity = txtBillingCity.Text.Trim();
            CustomerObj.BillingCountry = cmbBillingCountry.SelectedItem.Text;
            CustomerObj.BillingPostCode = txtBillingPostCode.Text.Trim();
            CustomerObj.BillingState = txtBillingState.Text.Trim();
            CustomerObj.Car = cmbCar.SelectedItem.Text;
            CustomerObj.CarLicensePlate = txtLicensePlate.Text.Trim();
            CustomerObj.CCExpirationDate = GetCCExpiryDate();
            CustomerObj.CCNameOnCard = txtNameOnCard.Text.Trim();
            int CCNo;
            if (int.TryParse(txtCCNumber.Text.Trim(), out CCNo))
            {
                CustomerObj.CCNo = CCNo;
            }
            else
            {
                CustomerObj.CCNo = null;
            }

            CustomerObj.CCType = int.Parse(cmbCCType.SelectedItem.Value.ToString());
            CustomerObj.CompanyAddress = txtCompanyAddress.Text.Trim();
            CustomerObj.CompanyName = txtCompanyName.Text.Trim();
            CustomerObj.CompanyNotes = txtNotes.Text.Trim();
            CustomerObj.DriverLicense = txtDriveLicense.Text.Trim();
            CustomerObj.Email = txtEmail.Text.Trim();
            CustomerObj.Fax = txtFax.Text.Trim();
            CustomerObj.Gender = cmbGender.SelectedItem.Text.Trim();
            CustomerObj.MemberCode = txtMemberCode.Text.Trim();
            
            CustomerObj.Mobile = txtPhone.Text.Trim();
            CustomerObj.PassportCountryOfIssue = txtCountryOfIssue.Text.Trim();
            CustomerObj.PassportExpirationDate = dtpExpiryDate.Date;
            CustomerObj.PassportNumber = txtPassportNumber.Text.Trim();
            CustomerObj.Phone = txtPhone.Text.Trim();

            CustomerObj.CreatedUser = Master.LoggedUser.UserId;
            CustomerObj.UpdatedUser = Master.LoggedUser.UserId;

            //CustomerObj.StatusId = stat

            string errorMSG;
            if ((new CustomerManagement.CustomerManager()).IsValidToSave(CustomerObj, out errorMSG))
            {
                if (CustomerObj.Save())
                {

                    
                }
                
            }

            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = errorMSG;
            //Display error on a label

        }

        private DateTime? GetCCExpiryDate()
        {
            DateTime? expDate = new DateTime();

            if (cmbCCExpiryDateMonth.SelectedItem.ValueString != string.Empty && 
                cmbCCExpiryDateYear.SelectedItem.ValueString != string.Empty)
            {
                DateTime tempDate = new DateTime(
                    int.Parse(cmbCCExpiryDateYear.SelectedItem.ValueString),
                    int.Parse(cmbCCExpiryDateMonth.SelectedItem.ValueString),
                    1);

                expDate = tempDate;
            }
            else
            {
                expDate = null;
            }

            return expDate;
        }

        #region Methods

        /// <summary>
        /// Check if GRNId is passed to edit
        /// </summary>
        private void IsEditCustomer()
        {

            if (Request.QueryString["CustomerId"] != null && Request.QueryString["CustomerId"].Trim() != String.Empty)
            {
                hdnCustomerId.Value = Request.QueryString["CustomerId"].Trim();
                Page.Title = "View Customer";
            }
        }

        /// <summary>
        /// Fill FromURL to go back
        /// </summary>
        private void CheckFromURL()
        {
            if (Request.QueryString["FromURL"] != null && Request.QueryString["FromURL"].Trim() != String.Empty)
            {
                hdnFromURL.Value = Request.QueryString["FromURL"].Trim();
            }
        }

        #endregion Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (hdnFromURL.Value.Trim() != string.Empty)
            {
                Response.Redirect(hdnFromURL.Value.Trim(), false);
            }
            else
            {
                Response.Redirect(HBM.Common.Constants.CONST_DEFAULTBACKPAGE, false);
            }
        }

        protected void btnSaveCountry_Click(object sender, EventArgs e)
        {

        }
    }
}
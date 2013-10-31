using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustMan = HBM.CustomerManagement;
using HBM.CustomerManagement;
using HBM.Common;

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
                    customer = customer.Select();
                    customer = customer != null ? customer : new Customer();
                    Session["CustomerObj"] = customer;
                }
                else
                {
                    customer = (CustMan.Customer)Session["CustomerObj"];
                }
                return customer;
            }
        }

        public DateTime? CCExpiryDate
        {
            get 
            {
                DateTime? expDate = new DateTime();

                if (cmbCCExpiryDateMonth.SelectedIndex > -1 &&
                    cmbCCExpiryDateYear.SelectedIndex > -1)
                {
                    DateTime tempDate = new DateTime(
                        int.Parse(cmbCCExpiryDateYear.SelectedItem.Value.ToString()),
                        int.Parse(cmbCCExpiryDateMonth.SelectedItem.Value.ToString()),
                        1);

                    expDate = tempDate;
                }
                else
                {
                    expDate = null;
                }

                return expDate;
            }
            set 
            {
                if (value.HasValue)
                {
                    cmbCCExpiryDateMonth.Value = value.Value.Month;
                    cmbCCExpiryDateYear.Value = value.Value.Year;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Master.ClearSessions();
                    CheckFromURL();
                    IsEditCustomer();
                    LoadInitialData();
                    SetData();
                }
            }
            catch (System.Exception)
            {

            }
        }

        /// <summary>
        /// Load all lookup data with this method
        /// </summary>
        private void LoadInitialData()
        {
            try
            {
                //Load Guest Type
                cmbGuestType.DataSource = new GuestType() { CompanyId = Master.CompanyId }.SelectAllList();
                cmbGuestType.TextField = "GuestTypeName";
                cmbGuestType.ValueField = "GuestTypeId";
                cmbGuestType.DataBind();

                //Load CC Tyep
                cmbCCType.DataSource = new CreditCardType() { CompanyId = Master.CompanyId }.SelectAllList();
                cmbCCType.TextField = "Name";
                cmbCCType.ValueField = "CreditCardTypeId";
                cmbCCType.DataBind();

                //Load Passport issued country
                cmbPassportCountryOfIssue.DataSource = new Country().SelectAllList();
                cmbPassportCountryOfIssue.TextField = "CountryName";
                cmbPassportCountryOfIssue.ValueField = "CountryId";
                cmbPassportCountryOfIssue.DataBind();

                //Load Country
                cmbBillingCountry.DataSource = new Country().SelectAllList();
                cmbBillingCountry.TextField = "CountryName";
                cmbBillingCountry.ValueField = "CountryId";
                cmbBillingCountry.DataBind();
            }
            catch (System.Exception)
            {

            }
        }

        private void SetData()
        {
            try
            {
                txtCustomerName.Text = CustomerObj.CustomerName;
                txtBillingAddress.Text = CustomerObj.BillingAddress;
                txtBillingCity.Text = CustomerObj.BillingCity;

                if (CustomerObj.BillingCountryId.HasValue)
                {
                    cmbBillingCountry.Value = CustomerObj.BillingCountryId;
                }

                txtBillingPostCode.Text = CustomerObj.BillingPostCode;
                txtBillingState.Text = CustomerObj.BillingState;

                if (string.IsNullOrEmpty(CustomerObj.Car) == false)
                {
                    cmbCar.Text = CustomerObj.Car;

                }

                txtLicensePlate.Text = CustomerObj.CarLicensePlate;
                CCExpiryDate = CustomerObj.CCExpirationDate;
                txtNameOnCard.Text = CustomerObj.CCNameOnCard;
                txtCCNumber.Text = CustomerObj.CCNo.HasValue ? CustomerObj.CCNo.Value.ToString() : string.Empty;

                if (CustomerObj.CreditCardTypeId.HasValue)
                {
                    cmbCCType.Value = CustomerObj.CreditCardTypeId.Value;
                }

                txtCompanyAddress.Text = CustomerObj.CompanyAddress;
                txtCompanyName.Text = CustomerObj.CompanyName;
                txtNotes.Text = CustomerObj.CompanyNotes;
                txtDriveLicense.Text = CustomerObj.DriverLicense;
                txtEmail.Text = CustomerObj.Email;
                txtFax.Text = CustomerObj.Fax;

                if (CustomerObj.GuestTypeId>0)
                {
                    cmbGuestType.Value = CustomerObj.GuestTypeId;
                }

                if (string.IsNullOrEmpty(CustomerObj.Gender) == false)
                {
                    cmbGender.Value = CustomerObj.Gender;
                }

                txtMemberCode.Text = CustomerObj.MemberCode;
                txtPhone.Text = CustomerObj.Mobile;

                if (CustomerObj.PassportCountryOfIssue.HasValue)
                {
                    cmbPassportCountryOfIssue.Value = CustomerObj.PassportCountryOfIssue;
                }

                if (CustomerObj.PassportExpirationDate.HasValue)
                {
                    dtpExpiryDate.Date = CustomerObj.PassportExpirationDate.Value;
                }

                txtPassportNumber.Text = CustomerObj.PassportNumber;
                txtPhone.Text = CustomerObj.Phone;
            }
            catch (System.Exception)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerObj.CompanyId = Master.CompanyId;
                CustomerObj.CustomerName = txtCustomerName.Text.Trim();
                CustomerObj.BillingAddress = txtBillingAddress.Text.Trim();
                CustomerObj.BillingCity = txtBillingCity.Text.Trim();

                if (cmbBillingCountry.SelectedIndex > -1
                    && (int)cmbBillingCountry.SelectedItem.Value > 0)
                {
                    CustomerObj.BillingCountryId = (int)cmbBillingCountry.SelectedItem.Value;
                }
                else
                {
                    CustomerObj.BillingCountryId = null;
                }

                CustomerObj.BillingPostCode = txtBillingPostCode.Text.Trim();
                CustomerObj.BillingState = txtBillingState.Text.Trim();

                if (cmbCar.SelectedIndex > -1)
                {
                    CustomerObj.Car = cmbCar.SelectedItem.Text;
                }
                else
                {
                    CustomerObj.Car = null;
                }

                CustomerObj.CarLicensePlate = txtLicensePlate.Text.Trim();
                CustomerObj.CCExpirationDate = CCExpiryDate;
                CustomerObj.CCNameOnCard = txtNameOnCard.Text.Trim();
                Int64 CCNo;
                if (Int64.TryParse(txtCCNumber.Text.Trim(), out CCNo))
                {
                    CustomerObj.CCNo = CCNo;
                }
                else
                {
                    CustomerObj.CCNo = null;
                }

                if (cmbCCType.SelectedIndex > -1)
                {
                    CustomerObj.CreditCardTypeId = int.Parse(cmbCCType.SelectedItem.Value.ToString());
                }
                else
                {
                    CustomerObj.CreditCardTypeId = null;
                }

                CustomerObj.CompanyAddress = txtCompanyAddress.Text.Trim();
                CustomerObj.CompanyName = txtCompanyName.Text.Trim();
                CustomerObj.CompanyNotes = txtNotes.Text.Trim();
                CustomerObj.DriverLicense = txtDriveLicense.Text.Trim();
                CustomerObj.Email = txtEmail.Text.Trim();
                CustomerObj.Fax = txtFax.Text.Trim();
                CustomerObj.Gender = cmbGender.SelectedItem.Text.Trim();
                CustomerObj.MemberCode = txtMemberCode.Text.Trim();
                CustomerObj.Mobile = txtPhone.Text.Trim();
                CustomerObj.GuestTypeId = (int)cmbGuestType.SelectedItem.Value;

                if (cmbPassportCountryOfIssue.SelectedIndex > -1 && (int)cmbPassportCountryOfIssue.SelectedItem.Value > 0)
                {
                    CustomerObj.PassportCountryOfIssue = (int)cmbPassportCountryOfIssue.SelectedItem.Value;
                }
                else
                {
                    CustomerObj.PassportCountryOfIssue = null;
                }

                CustomerObj.PassportExpirationDate = (DateTime?)dtpExpiryDate.Value;
                CustomerObj.PassportNumber = txtPassportNumber.Text.Trim();
                CustomerObj.Phone = txtPhone.Text.Trim();
                CustomerObj.CreatedUser = Master.LoggedUser.UsersId;
                CustomerObj.UpdatedUser = Master.LoggedUser.UsersId;
                CustomerObj.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;

                string errorMSG;
                if ((new CustomerManagement.CustomerManager()).IsValidToSave(CustomerObj, out errorMSG))
                {
                    if (string.IsNullOrEmpty(errorMSG) && CustomerObj.Save())
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                        ClearForm();
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Unsuccess + "')", true);
                    }

                }

                //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Email + "')", true);

                //divErrorMsg.Visible = true;
                //divErrorMsg.InnerText = errorMSG;
                //Display error on a label
            }
            catch (System.Exception)
            {

            }
        }

        private void ClearForm()
        {
            try
            {
                Session["CustomerObj"] = null;
                hdnCustomerId.Value = "0";
                txtCustomerName.Text = string.Empty;
                txtBillingAddress.Text = string.Empty;
                txtBillingCity.Text = string.Empty;
                txtBillingPostCode.Text = string.Empty;
                txtBillingState.Text = string.Empty;
                txtLicensePlate.Text = string.Empty;
                txtNameOnCard.Text = string.Empty;
                txtCCNumber.Text = string.Empty;
                txtCompanyAddress.Text = string.Empty;
                txtCompanyName.Text = string.Empty;
                txtNotes.Text = string.Empty;
                txtDriveLicense.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtMemberCode.Text = string.Empty;
                txtPhone.Text = string.Empty;
                dtpExpiryDate.Value = null;
                txtPassportNumber.Text = string.Empty;
                txtPhone.Text = string.Empty;

                cmbCar.Value = null;
                cmbBillingCountry.Value = null;
                cmbCCType.Value = null;
                cmbGender.Value = null;
                cmbPassportCountryOfIssue.Value = null;
                cmbCCExpiryDateMonth.Value = null;
                cmbCCExpiryDateYear.Value = null;
                cmbGuestType.Value = null;
            }
            catch (System.Exception)
            {

            }
        }

        #region Methods

        /// <summary>
        /// Check if GRNId is passed to edit
        /// </summary>
        private void IsEditCustomer()
        {
            try
            {
                if (Request.QueryString["CustomerId"] != null && Request.QueryString["CustomerId"].Trim() != String.Empty)
                {
                    hdnCustomerId.Value = Request.QueryString["CustomerId"].Trim();
                    Page.Title = "View Customer";
                }
            }
            catch (System.Exception)
            {

            }

        }

        /// <summary>
        /// Fill FromURL to go back
        /// </summary>
        private void CheckFromURL()
        {
            try
            {
                if (Request.QueryString["FromURL"] != null && Request.QueryString["FromURL"].Trim() != String.Empty)
                {
                    hdnFromURL.Value = Request.QueryString["FromURL"].Trim();
                }
            }
            catch (System.Exception)
            {

            }

        }

        #endregion Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
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
            catch (System.Exception)
            {

            }

        }

        protected void btnSaveCountry_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception)
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (System.Exception)
            {
                
                
            }
        }
    }
}
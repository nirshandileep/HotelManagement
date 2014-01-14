using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustMan = HBM.CustomerManagement;
using HBM.CustomerManagement;
using HBM.Common;
using HBM.Utility;

namespace HBM
{
    public partial class Customers : System.Web.UI.Page
    {
        #region Properties

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

        #endregion

        #region Methods

        private void ViewData()
        {
            try
            {

                CustMan.Customer CustomerObj = new CustMan.Customer();
                CustomerObj.CustomerId = Int32.Parse(hdnCustomerId.Value.Trim() == String.Empty ? "0" : hdnCustomerId.Value.Trim());
                CustomerObj.CompanyId = Master.CurrentCompany.CompanyId;

                CustomerObj = CustomerObj.Select();

                chkUseSameBillingAddress.Checked = CustomerObj.UseSameBillingAddress;

                if (CustomerObj.UseSameBillingAddress)
                {
                    txtCompanyAddressLine1.Enabled = false;
                    txtCompanyAddressLine2.Enabled = false;
                    txtCompanyState.Enabled = false;
                    cmbCompanyCountry.Enabled = false;
                    txtCompanyPostCode.Enabled = false;
                    txtCompanyCity.Enabled = false;
                }
                else
                {
                    txtCompanyAddressLine1.Enabled = true;
                    txtCompanyAddressLine2.Enabled = true;
                    txtCompanyState.Enabled = true;
                    cmbCompanyCountry.Enabled = true;
                    txtCompanyPostCode.Enabled = true;
                    txtCompanyCity.Enabled = true;
                }


                txtCustomerName.Text = CustomerObj.CustomerName;
                txtBillingAddressLine1.Text = CustomerObj.BillingAddressLine1;
                txtBillingAddressLine2.Text = CustomerObj.BillingAddressLine2;

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
                txtCCNumber.Text = string.IsNullOrEmpty(CustomerObj.CCNo) ? string.Empty : CustomerObj.CCNo.ToString();
                txtCardSecurityCode.Text = CustomerObj.CardSecurityCode;

                if (CustomerObj.CardStartDate == null)
                {
                    dtStartDate.Text = string.Empty;
                }
                else
                {
                    dtStartDate.Value = CustomerObj.CardStartDate;
                }


                txtCardIssueNo.Text = CustomerObj.CardIssueNo;

                if (CustomerObj.CreditCardTypeId.HasValue)
                {
                    cmbCCType.Value = CustomerObj.CreditCardTypeId.Value;
                }

                txtCompanyAddressLine1.Text = CustomerObj.CompanyAddressLine1;
                txtCompanyAddressLine2.Text = CustomerObj.CompanyAddressLine2;
                txtCompanyCity.Text = CustomerObj.CompanyCity;
                if (CustomerObj.CompanyCountryId.HasValue)
                    cmbCompanyCountry.Value = CustomerObj.CompanyCountryId;
                txtCompanyState.Text = CustomerObj.CompanyState;
                txtCompanyPostCode.Text = CustomerObj.CompanyPostCode;

                txtCompanyName.Text = CustomerObj.CompanyName;
                txtNotes.Text = CustomerObj.CompanyNotes;
                txtDriveLicense.Text = CustomerObj.DriverLicense;
                txtEmail.Text = CustomerObj.Email;
                txtFax.Text = CustomerObj.Fax;

                if (CustomerObj.GuestTypeId > 0)
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

        private void ClearFormData()
        {
            try
            {
                if (Request.QueryString["CustomerId"] != null && Request.QueryString["CustomerId"].Trim() != String.Empty)
                {
                    Response.Redirect(Constants.URL_CUSTOMERS, false);
                }
                else
                {
                    hdnCustomerId.Value = "0";
                    txtCustomerName.Text = string.Empty;
                    txtBillingAddressLine1.Text = string.Empty;
                    txtBillingAddressLine2.Text = string.Empty;

                    txtBillingCity.Text = string.Empty;
                    txtBillingPostCode.Text = string.Empty;
                    txtBillingState.Text = string.Empty;
                    txtLicensePlate.Text = string.Empty;
                    txtNameOnCard.Text = string.Empty;
                    txtCCNumber.Text = string.Empty;
                    txtCardSecurityCode.Text = string.Empty;

                    txtCompanyAddressLine1.Text = string.Empty;
                    txtCompanyAddressLine2.Text = string.Empty;
                    txtCompanyCity.Text = string.Empty;
                    txtCompanyPostCode.Text = string.Empty;
                    txtCompanyState.Text = string.Empty;
                    cmbCompanyCountry.Value = null;

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

                    txtCustomerName.IsValid = true;
                    txtMemberCode.IsValid = true;
                    cmbGender.IsValid = true;
                    txtPhone.IsValid = true;
                    cmbGuestType.IsValid = true;
                    txtBillingAddressLine1.IsValid = true;
                    txtBillingCity.IsValid = true;
                    txtEmail.IsValid = true;

                    txtCompanyAddressLine1.Enabled = true;
                    txtCompanyAddressLine2.Enabled = true;
                    txtCompanyState.Enabled = true;
                    cmbCompanyCountry.Enabled = true;
                    txtCompanyPostCode.Enabled = true;
                    txtCompanyCity.Enabled = true;
                }
            }
            catch (System.Exception)
            {

            }
        }

        private void LoadInitialData()
        {
            try
            {

                //Load CC Tyep
                cmbCCType.DataSource = new CreditCardType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
                cmbCCType.TextField = "Name";
                cmbCCType.ValueField = "CreditCardTypeId";
                cmbCCType.DataBind();

                //Load Passport issued country
                cmbPassportCountryOfIssue.DataSource = new Country().SelectAllList();
                cmbPassportCountryOfIssue.TextField = "CountryName";
                cmbPassportCountryOfIssue.ValueField = "CountryId";
                cmbPassportCountryOfIssue.DataBind();

                //Load Billing Country
                cmbBillingCountry.DataSource = new Country().SelectAllList();
                cmbBillingCountry.TextField = "CountryName";
                cmbBillingCountry.ValueField = "CountryId";
                cmbBillingCountry.DataBind();

                //Load Company Country
                cmbCompanyCountry.DataSource = new Country().SelectAllList();
                cmbCompanyCountry.TextField = "CountryName";
                cmbCompanyCountry.ValueField = "CountryId";
                cmbCompanyCountry.DataBind();
            }
            catch (System.Exception)
            {

            }
        }

        private void IsEditCustomer()
        {
            try
            {
                if (Request.QueryString["CustomerId"] != null && Request.QueryString["CustomerId"] != String.Empty)
                {
                    hdnCustomerId.Value = Cryptography.Decrypt(Request.QueryString["CustomerId"]);
                    Page.Title = "View Customer";
                    this.btnReservation.Visible = true;
                }
            }
            catch (System.Exception)
            {

            }

        }

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

        private void SaveData()
        {
            CustMan.Customer currentCustomer = new CustMan.Customer();
            currentCustomer.CustomerId = Int32.Parse(hdnCustomerId.Value.Trim() == String.Empty ? "0" : hdnCustomerId.Value.Trim());
            currentCustomer.CompanyId = Master.CurrentCompany.CompanyId;
            currentCustomer.CustomerName = txtCustomerName.Value.ToString();

            if (cmbCar.SelectedItem.Value != null && cmbCar.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.Car = cmbCar.SelectedItem.Value.ToString();
            }
            else
            {
                currentCustomer.Car = null;
            }


            currentCustomer.CarLicensePlate = txtLicensePlate.Value.ToString();
            currentCustomer.CCExpirationDate = CCExpiryDate;
            currentCustomer.CCNameOnCard = txtNameOnCard.Value.ToString();

            currentCustomer.CCNo = txtCCNumber.Value.ToString();

            currentCustomer.CardSecurityCode = txtCardSecurityCode.Value.ToString();

            if (dtStartDate.Value.ToString() == string.Empty)
            {
                currentCustomer.CardStartDate = null;
            }
            else
            {
                currentCustomer.CardStartDate = Convert.ToDateTime(dtStartDate.Value.ToString());
            }


            currentCustomer.CardIssueNo = txtCardIssueNo.Value.ToString();


            if (cmbCCType.SelectedItem.Value != null && cmbCCType.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.CreditCardTypeId = Convert.ToInt32(cmbCCType.SelectedItem.Value.ToString());
            }
            else
            {
                currentCustomer.CreditCardTypeId = null;
            }

            currentCustomer.CompanyName = txtCompanyName.Value.ToString();
            currentCustomer.CompanyNotes = txtNotes.Value.ToString();

            currentCustomer.UseSameBillingAddress = chkUseSameBillingAddress.Checked == true ? true : false;

            if (chkUseSameBillingAddress.Checked)
            {
                currentCustomer.CompanyAddressLine1 = string.Empty;
                currentCustomer.CompanyAddressLine2 = string.Empty;
                currentCustomer.CompanyCity = string.Empty;
                currentCustomer.CompanyCountryId = null;
                currentCustomer.CompanyState = string.Empty;
                currentCustomer.CompanyPostCode = string.Empty;
            }
            else
            {
                currentCustomer.CompanyAddressLine1 = txtCompanyAddressLine1.Value.ToString();
                currentCustomer.CompanyAddressLine2 = txtCompanyAddressLine2.Value.ToString();
                currentCustomer.CompanyCity = txtCompanyCity.Text.Trim();

                if (cmbCompanyCountry.SelectedItem.Value != null && cmbCompanyCountry.SelectedItem.Value.ToString() != string.Empty)
                {
                    currentCustomer.CompanyCountryId = Convert.ToInt32(cmbCompanyCountry.SelectedItem.Value.ToString());
                }
                else
                {
                    currentCustomer.CompanyCountryId = null;
                }

                currentCustomer.CompanyState = txtCompanyState.Value.ToString();
                currentCustomer.CompanyPostCode = txtCompanyPostCode.Value.ToString();
            }




            currentCustomer.BillingAddressLine1 = txtBillingAddressLine1.Value.ToString();
            currentCustomer.BillingAddressLine2 = txtBillingAddressLine2.Value.ToString();
            currentCustomer.BillingCity = txtBillingCity.Value.ToString();
            currentCustomer.BillingState = txtBillingState.Value.ToString();

            if (cmbBillingCountry.SelectedItem.Value != null && cmbBillingCountry.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.BillingCountryId = Convert.ToInt32(cmbBillingCountry.SelectedItem.Value);
            }
            else
            {
                currentCustomer.BillingCountryId = null;
            }

            currentCustomer.BillingPostCode = txtBillingPostCode.Value.ToString();





            //if (chkUseSameBillingAddress.Checked)
            //{
            //    CustomerObj.BillingAddressLine1 = CustomerObj.CompanyAddressLine1;
            //    CustomerObj.BillingAddressLine2 = CustomerObj.CompanyAddressLine2;
            //    CustomerObj.BillingCity = CustomerObj.CompanyCity;
            //    CustomerObj.BillingCountryId = CustomerObj.CompanyCountryId;
            //    CustomerObj.BillingPostCode = CustomerObj.CompanyPostCode;
            //    CustomerObj.BillingState = CustomerObj.CompanyState;
            //}
            //else
            //{
            //    if (txtBillingAddressLine1.Text.Trim() == string.Empty
            //        || txtBillingAddressLine2.Text.Trim() == string.Empty
            //        || txtBillingCity.Text.Trim() == string.Empty)
            //    {
            //        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Save_Unsuccess_BillingAddress_Notprovided + "')", true);
            //    }

            //    CustomerObj.BillingAddressLine1 = txtBillingAddressLine1.Text.Trim();
            //    CustomerObj.BillingAddressLine2 = txtBillingAddressLine2.Text.Trim();
            //    CustomerObj.BillingCity = txtBillingCity.Text.Trim();
            //    if (cmbBillingCountry.SelectedIndex > -1
            //        && (int)cmbBillingCountry.SelectedItem.Value > 0)
            //    {
            //        CustomerObj.BillingCountryId = (int)cmbBillingCountry.SelectedItem.Value;
            //    }
            //    else
            //    {
            //        CustomerObj.BillingCountryId = null;
            //    }
            //    CustomerObj.BillingPostCode = txtBillingPostCode.Text.Trim();
            //    CustomerObj.BillingState = txtBillingState.Text.Trim();

            //}


            currentCustomer.DriverLicense = txtDriveLicense.Value.ToString();
            currentCustomer.Email = txtEmail.Value.ToString();
            currentCustomer.Fax = txtFax.Value.ToString();
            currentCustomer.Gender = cmbGender.SelectedItem.Value.ToString();
            currentCustomer.MemberCode = txtMemberCode.Value.ToString();
            currentCustomer.Mobile = txtPhone.Value.ToString();
            currentCustomer.GuestTypeId = (int)cmbGuestType.SelectedItem.Value;

            if (cmbPassportCountryOfIssue.SelectedItem.Value != null && cmbPassportCountryOfIssue.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.PassportCountryOfIssue = Convert.ToInt32(cmbPassportCountryOfIssue.SelectedItem.Value);
            }
            else
            {
                currentCustomer.PassportCountryOfIssue = null;
            }

            currentCustomer.PassportExpirationDate = (DateTime?)dtpExpiryDate.Value;
            currentCustomer.PassportNumber = txtPassportNumber.Value.ToString();
            currentCustomer.Phone = txtPhone.Value.ToString();
            currentCustomer.CreatedUser = Master.LoggedUser.UsersId;
            currentCustomer.UpdatedUser = Master.LoggedUser.UsersId;
            currentCustomer.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;

            string errorMSG;
            if ((new CustomerManagement.CustomerManager()).IsValidToSave(currentCustomer, out errorMSG))
            {
                if (string.IsNullOrEmpty(errorMSG) && currentCustomer.Save())
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);                    
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Save_Unsuccess + "')", true);
                }

            }
        }

        #endregion Methods

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LoadInitData();

                if (!IsPostBack)
                {
                    CheckFromURL();
                    IsEditCustomer();
                    LoadInitialData();
                    ViewData();
                }
            }
            catch (System.Exception)
            {

            }
        }

        private void LoadInitData()
        {
            //Load Guest Type
            cmbGuestType.DataSource = new GuestType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbGuestType.TextField = "GuestTypeName";
            cmbGuestType.ValueField = "GuestTypeId";
            cmbGuestType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveData();

            }
            catch (System.Exception)
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFormData();
            }
            catch (System.Exception)
            {


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Common.Constants.URL_CUSTOMERSEARCH, false);
            }
            catch (System.Exception)
            {


            }
        }

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Common.Constants.URL_RESERVATION + "?CustomerID=" + Cryptography.Encrypt(hdnCustomerId.Value), false);
            }
            catch (System.Exception)
            {


            }
        }

        protected void chkUseSameBillingAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseSameBillingAddress.Checked)
            {
                txtCompanyAddressLine1.Value = null;
                txtCompanyAddressLine2.Value = null;
                txtCompanyState.Value = null;
                cmbCompanyCountry.SelectedIndex = -1;
                txtCompanyPostCode.Value = null;
                txtCompanyCity.Value = null;

                txtCompanyAddressLine1.Enabled = false;
                txtCompanyAddressLine2.Enabled = false;
                txtCompanyState.Enabled = false;
                cmbCompanyCountry.Enabled = false;
                txtCompanyPostCode.Enabled = false;
                txtCompanyCity.Enabled = false;

            }
            else
            {
                txtCompanyAddressLine1.Enabled = true;
                txtCompanyAddressLine2.Enabled = true;
                txtCompanyState.Enabled = true;
                cmbCompanyCountry.Enabled = true;
                txtCompanyPostCode.Enabled = true;
                txtCompanyCity.Enabled = true;

            }
        }

        #endregion
    }
}
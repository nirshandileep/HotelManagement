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
using HBM.SessionManager;
using System.Data;
using DevExpress.Web.ASPxGridView;
using System.Collections;
using DevExpress.Web.ASPxEditors;

namespace HBM
{
    public partial class Customers : System.Web.UI.Page
    {
        #region Properties

        DataSet dsData = new DataSet();

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

        public DateTime? CCExpiryDateGrp
        {
            get
            {
                DateTime? expDate = new DateTime();

                if (cmbCCExpiryDateMonthGrp.SelectedIndex > -1 &&
                    cmbCCExpiryDateYearGrp.SelectedIndex > -1)
                {
                    DateTime tempDate = new DateTime(
                        int.Parse(cmbCCExpiryDateYearGrp.SelectedItem.Value.ToString()),
                        int.Parse(cmbCCExpiryDateMonthGrp.SelectedItem.Value.ToString()),
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
                    cmbCCExpiryDateMonthGrp.Value = value.Value.Month;
                    cmbCCExpiryDateYearGrp.Value = value.Value.Year;
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

                if (CustomerObj.CustomerId > 0)
                {
                    CustomerObj.CompanyId = Master.CurrentCompany.CompanyId;
                    CustomerObj = CustomerObj.Select();

                    if (CustomerObj.IsGroupCustomer.HasValue && CustomerObj.IsGroupCustomer == true)
                    {
                        LoadGroupCustomers(CustomerObj);
                    }
                    else
                    {
                        LoadIndividualCustomers(CustomerObj);
                    }

                }
                else
                {
                    CustMan.Customer CustomerObj1 = new CustMan.Customer();
                    dsData = CustomerObj1.SelectGroupByGroupId(0);
                    gvGroupMembers.DataSource = dsData;
                    gvGroupMembers.DataBind();
                    dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["CustomerId"] };
                    Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;
                }





            }
            catch (System.Exception)
            {

            }
        }

        private void LoadIndividualCustomers(CustMan.Customer CustomerObj)
        {
            hdnCustomerMode.Value = ((int)Common.Enums.CustomerModes.Individual).ToString();
            rblCustomerMode.SelectedValue = ((int)Common.Enums.CustomerModes.Individual).ToString();
            tblIndividualCustomer.Visible = true;
            tblGroupCustomer.Visible = false;

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
                        
            rblCustomerMode.Enabled = false;
        }

        private void LoadGroupCustomers(CustMan.Customer CustomerObj)
        {

            hdnCustomerMode.Value = ((int)Common.Enums.CustomerModes.Group).ToString();
            rblCustomerMode.SelectedValue = ((int)Common.Enums.CustomerModes.Group).ToString();

            chkUseSameBillingAddressGrp.Checked = CustomerObj.UseSameBillingAddress;

            tblIndividualCustomer.Visible = false;
            tblGroupCustomer.Visible = true;

            if (CustomerObj.UseSameBillingAddress)
            {
                txtCompanyAddressLine1Grp.Enabled = false;
                txtCompanyAddressLine2Grp.Enabled = false;
                txtCompanyStateGrp.Enabled = false;
                cmbCompanyCountryGrp.Enabled = false;
                txtCompanyPostCodeGrp.Enabled = false;
                txtCompanyCityGrp.Enabled = false;
            }
            else
            {
                txtCompanyAddressLine1Grp.Enabled = true;
                txtCompanyAddressLine2Grp.Enabled = true;
                txtCompanyStateGrp.Enabled = true;
                cmbCompanyCountryGrp.Enabled = true;
                txtCompanyPostCodeGrp.Enabled = true;
                txtCompanyCityGrp.Enabled = true;
            }


            txtGroupName.Text = CustomerObj.CustomerName;
            txtBillingAddressLine1Grp.Text = CustomerObj.BillingAddressLine1;
            txtBillingAddressLine2Grp.Text = CustomerObj.BillingAddressLine2;

            txtBillingCityGrp.Text = CustomerObj.BillingCity;

            if (CustomerObj.BillingCountryId.HasValue)
            {
                cmbBillingCountryGrp.Value = CustomerObj.BillingCountryId;
            }

            txtBillingZipPostalCodeGrp.Text = CustomerObj.BillingPostCode;
            txtBillingStateGrp.Text = CustomerObj.BillingState;

            CCExpiryDateGrp = CustomerObj.CCExpirationDate;
            txtNameOnCardGrp.Text = CustomerObj.CCNameOnCard;
            txtCCNoGrp.Text = string.IsNullOrEmpty(CustomerObj.CCNo) ? string.Empty : CustomerObj.CCNo.ToString();
            txtCardSecurityCodeGrp.Text = CustomerObj.CardSecurityCode;

            if (CustomerObj.CardStartDate == null)
            {
                dtStartDateGrp.Text = string.Empty;
            }
            else
            {
                dtStartDateGrp.Value = CustomerObj.CardStartDate;
            }


            txtCardIssueNoGrp.Text = CustomerObj.CardIssueNo;

            if (CustomerObj.CreditCardTypeId.HasValue)
            {
                cmbCCTypeGrp.Value = CustomerObj.CreditCardTypeId.Value;
            }

            txtCompanyAddressLine1Grp.Text = CustomerObj.CompanyAddressLine1;
            txtCompanyAddressLine2Grp.Text = CustomerObj.CompanyAddressLine2;
            txtCompanyCityGrp.Text = CustomerObj.CompanyCity;
            if (CustomerObj.CompanyCountryId.HasValue)
                cmbCompanyCountryGrp.Value = CustomerObj.CompanyCountryId;
            txtCompanyStateGrp.Text = CustomerObj.CompanyState;
            txtCompanyPostCodeGrp.Text = CustomerObj.CompanyPostCode;

            txtCompanyNameGrp.Text = CustomerObj.CompanyName;
            txtCompanyNotesGrp.Text = CustomerObj.CompanyNotes;
            txtEmailGrp.Text = CustomerObj.Email;
            txtFaxGrp.Text = CustomerObj.Fax;

            if (CustomerObj.GuestTypeId > 0)
            {
                cmbGuestTypeGrp.Value = CustomerObj.GuestTypeId;
            }

            txtMemberCodeGrp.Text = CustomerObj.MemberCode;
            txtPhoneGrp.Text = CustomerObj.Phone;

            //Load the grid
            gvGroupMembers.DataSource = CustomerObj.DsGroupCustomers;
            gvGroupMembers.DataBind();
            dsData = CustomerObj.DsGroupCustomers;
            Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;
            dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["CustomerId"] };
            rblCustomerMode.Enabled = false;

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
                    rblCustomerMode.Enabled = true;
                    tblIndividualCustomer.Visible = true;
                    tblGroupCustomer.Visible = false;
                    hdnCustomerMode.Value = "1";
                    hdnCustomerMode.Value = "1";
                    rblCustomerMode.SelectedValue = ((int)Common.Enums.CustomerModes.Individual).ToString();
                    
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
                ///
                /// Individual Customers
                /// 

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

                ///
                ///Group Details
                ///

                //Load CC Tyep
                cmbCCTypeGrp.DataSource = new CreditCardType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
                cmbCCTypeGrp.TextField = "Name";
                cmbCCTypeGrp.ValueField = "CreditCardTypeId";
                cmbCCTypeGrp.DataBind();

                //Load Billing Country
                cmbBillingCountryGrp.DataSource = new Country().SelectAllList();
                cmbBillingCountryGrp.TextField = "CountryName";
                cmbBillingCountryGrp.ValueField = "CountryId";
                cmbBillingCountryGrp.DataBind();

                //Load Company Country
                cmbCompanyCountryGrp.DataSource = new Country().SelectAllList();
                cmbCompanyCountryGrp.TextField = "CountryName";
                cmbCompanyCountryGrp.ValueField = "CountryId";
                cmbCompanyCountryGrp.DataBind();
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

            if (hdnCustomerMode.Value.Trim() == "1")
            {
                SaveSingleCustomerData(currentCustomer);
            }
            else
            {
                SaveCustomerGroupData(currentCustomer);
            }

            string errorMSG;
            if ((new CustomerManagement.CustomerManager()).IsValidToSave(currentCustomer, out errorMSG))
            {
                if (string.IsNullOrEmpty(errorMSG) && currentCustomer.Save())
                {
                    hdnCustomerId.Value = currentCustomer.CustomerId.ToString();
                    this.ViewData();
                    dsData = currentCustomer.SelectGroupByGroupId(currentCustomer.CustomerId);
                    gvGroupMembers.DataSource = dsData;
                    gvGroupMembers.DataBind();
                    dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["CustomerId"] };
                    Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;

                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Save_Unsuccess + "')", true);
                }
            }
        }

        private void SaveSingleCustomerData(CustMan.Customer currentCustomer)
        {
            currentCustomer.CustomerName = txtCustomerName.Value.ToString();

            if (cmbCar.SelectedItem != null && cmbCar.SelectedItem.Value != null && cmbCar.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.Car = cmbCar.SelectedItem.Value.ToString();
            }
            else
            {
                currentCustomer.Car = null;
            }

            currentCustomer.CarLicensePlate = txtLicensePlate.Value == null ? string.Empty : txtLicensePlate.Value.ToString();
            currentCustomer.CCExpirationDate = CCExpiryDate;
            currentCustomer.CCNameOnCard = txtNameOnCard.Value == null ? string.Empty : txtNameOnCard.Value.ToString();
            currentCustomer.CCNo = txtCCNumber.Value == null ? string.Empty : txtCCNumber.Value.ToString();
            currentCustomer.CardSecurityCode = txtCardSecurityCode.Value == null ? string.Empty : txtCardSecurityCode.Value.ToString();

            if (dtStartDate.Value == null || dtStartDate.Value.ToString() == string.Empty)
            {
                currentCustomer.CardStartDate = null;
            }
            else
            {
                currentCustomer.CardStartDate = Convert.ToDateTime(dtStartDate.Value.ToString());
            }


            currentCustomer.CardIssueNo = txtCardIssueNo.Value == null ? string.Empty : txtCardIssueNo.Value.ToString();


            if (cmbCCType.SelectedItem != null && cmbCCType.SelectedItem.Value != null && cmbCCType.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.CreditCardTypeId = Convert.ToInt32(cmbCCType.SelectedItem.Value.ToString());
            }
            else
            {
                currentCustomer.CreditCardTypeId = null;
            }

            currentCustomer.CompanyName = txtCompanyName.Value == null ? string.Empty : txtCompanyName.Value.ToString();
            currentCustomer.CompanyNotes = txtNotes.Value == null ? string.Empty : txtNotes.Value.ToString();

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
                currentCustomer.CompanyAddressLine1 = txtCompanyAddressLine1.Value == null ? string.Empty : txtCompanyAddressLine1.Value.ToString();
                currentCustomer.CompanyAddressLine2 = txtCompanyAddressLine2.Value == null ? string.Empty : txtCompanyAddressLine2.Value.ToString();
                currentCustomer.CompanyCity = txtCompanyCity.Text.Trim();

                if (cmbCompanyCountry.SelectedItem != null && cmbCompanyCountry.SelectedItem.Value != null && cmbCompanyCountry.SelectedItem.Value.ToString() != string.Empty)
                {
                    currentCustomer.CompanyCountryId = Convert.ToInt32(cmbCompanyCountry.SelectedItem.Value.ToString());
                }
                else
                {
                    currentCustomer.CompanyCountryId = null;
                }

                currentCustomer.CompanyState = txtCompanyState.Value == null ? string.Empty : txtCompanyState.Value.ToString();
                currentCustomer.CompanyPostCode = txtCompanyPostCode.Value == null ? string.Empty : txtCompanyPostCode.Value.ToString();
            }

            currentCustomer.BillingAddressLine1 = txtBillingAddressLine1.Value == null ? string.Empty : txtBillingAddressLine1.Value.ToString();
            currentCustomer.BillingAddressLine2 = txtBillingAddressLine2.Value == null ? string.Empty : txtBillingAddressLine2.Value.ToString();
            currentCustomer.BillingCity = txtBillingCity.Value.ToString();
            currentCustomer.BillingState = txtBillingState.Value == null ? string.Empty : txtBillingState.Value.ToString();

            if (cmbBillingCountry.SelectedItem != null && cmbBillingCountry.SelectedItem.Value != null && cmbBillingCountry.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.BillingCountryId = Convert.ToInt32(cmbBillingCountry.SelectedItem.Value);
            }
            else
            {
                currentCustomer.BillingCountryId = null;
            }

            currentCustomer.BillingPostCode = txtBillingPostCode.Value == null ? string.Empty : txtBillingPostCode.Value.ToString();

            currentCustomer.DriverLicense = txtDriveLicense.Value == null ? string.Empty : txtDriveLicense.Value.ToString();
            currentCustomer.Email = txtEmail.Value == null ? string.Empty : txtEmail.Value.ToString();
            currentCustomer.Fax = txtFax.Value == null ? string.Empty : txtFax.Value.ToString();
            currentCustomer.Gender = cmbGender.SelectedItem == null ? string.Empty : cmbGender.SelectedItem.Value.ToString();
            currentCustomer.MemberCode = txtMemberCode.Value == null ? string.Empty : txtMemberCode.Value.ToString();
            currentCustomer.Mobile = txtPhone.Value == null ? string.Empty : txtPhone.Value.ToString();

            if (cmbGuestType.SelectedItem != null)
            {
                currentCustomer.GuestTypeId = (int)cmbGuestType.SelectedItem.Value;
            }

            if (cmbPassportCountryOfIssue.SelectedItem != null && cmbPassportCountryOfIssue.SelectedItem.Value != null && cmbPassportCountryOfIssue.SelectedItem.Value.ToString() != string.Empty)
            {
                currentCustomer.PassportCountryOfIssue = Convert.ToInt32(cmbPassportCountryOfIssue.SelectedItem.Value);
            }
            else
            {
                currentCustomer.PassportCountryOfIssue = null;
            }


            if (dtpExpiryDate.Value != null)
            {
                currentCustomer.PassportExpirationDate = (DateTime?)dtpExpiryDate.Value;
            }
            currentCustomer.PassportNumber = txtPassportNumber.Value == null ? string.Empty :  txtPassportNumber.Value.ToString();
            currentCustomer.Phone = txtPhone.Value==null ? string.Empty : txtPhone.Value.ToString();
            currentCustomer.CreatedUser = Master.LoggedUser.UsersId;
            currentCustomer.UpdatedUser = Master.LoggedUser.UsersId;
            currentCustomer.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;

        }

        private void SaveCustomerGroupData(CustMan.Customer currentCustomer)
        {
            currentCustomer.CustomerName = txtGroupName.Value.ToString();

            currentCustomer.Car = null;
            currentCustomer.CarLicensePlate = null;

            currentCustomer.CCExpirationDate = CCExpiryDateGrp;
            currentCustomer.CCNameOnCard = txtNameOnCardGrp.Text.ToString();
            currentCustomer.CCNo = txtCCNoGrp.Text.ToString();
            currentCustomer.CardSecurityCode = txtCardSecurityCodeGrp.Text.ToString();

            if (dtStartDateGrp.Value == null)
            {
                currentCustomer.CardStartDate = null;
            }
            else
            {
                if (dtStartDateGrp.Value == null && dtStartDateGrp.Value.ToString() == string.Empty)
                {
                    currentCustomer.CardStartDate = null;
                }
                else
                {
                    currentCustomer.CardStartDate = Convert.ToDateTime(dtStartDateGrp.Value.ToString());
                }
            }

            currentCustomer.CardIssueNo = txtCardIssueNoGrp.Text.ToString();

            if (cmbCCTypeGrp.SelectedItem == null)
            {
                currentCustomer.CreditCardTypeId = null;
            }
            else
            {
                if (cmbCCTypeGrp.SelectedItem.Value != null && cmbCCTypeGrp.SelectedItem.Value.ToString() != string.Empty)
                {
                    currentCustomer.CreditCardTypeId = Convert.ToInt32(cmbCCTypeGrp.SelectedItem.Value.ToString());
                }
                else
                {
                    currentCustomer.CreditCardTypeId = null;
                }
            }

            currentCustomer.CompanyName = txtCompanyNameGrp.Text.ToString();
            currentCustomer.CompanyNotes = txtCompanyNotesGrp.Text.ToString();

            currentCustomer.UseSameBillingAddress = chkUseSameBillingAddressGrp.Checked == true ? true : false;

            if (chkUseSameBillingAddressGrp.Checked)
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
                currentCustomer.CompanyAddressLine1 = txtCompanyAddressLine1Grp.Text.ToString();
                currentCustomer.CompanyAddressLine2 = txtCompanyAddressLine2Grp.Text.ToString();
                currentCustomer.CompanyCity = txtCompanyCityGrp.Text.Trim();

                if (cmbCompanyCountryGrp.Items == null || cmbCompanyCountryGrp.SelectedItem == null)
                {
                    currentCustomer.CompanyCountryId = null;
                }
                else
                {
                    if (cmbCompanyCountryGrp.SelectedItem.Value != null && cmbCompanyCountryGrp.SelectedItem.Value.ToString() != string.Empty)
                    {
                        currentCustomer.CompanyCountryId = Convert.ToInt32(cmbCompanyCountryGrp.SelectedItem.Value.ToString());
                    }
                    else
                    {
                        currentCustomer.CompanyCountryId = null;
                    }
                }

                currentCustomer.CompanyState = txtCompanyStateGrp.Text.ToString();
                currentCustomer.CompanyPostCode = txtCompanyPostCodeGrp.Text.ToString();
            }

            currentCustomer.BillingAddressLine1 = txtBillingAddressLine1Grp.Text.ToString();
            currentCustomer.BillingAddressLine2 = txtBillingAddressLine2Grp.Text.ToString();
            currentCustomer.BillingCity = txtBillingCityGrp.Text.ToString();
            currentCustomer.BillingState = txtBillingStateGrp.Text.ToString();

            if (cmbBillingCountryGrp.Items == null || cmbBillingCountryGrp.SelectedItem == null)
            {
                currentCustomer.BillingCountryId = null;
            }
            else
            {
                if (cmbBillingCountryGrp.SelectedItem.Value != null && cmbBillingCountryGrp.SelectedItem.Value.ToString() != string.Empty)
                {
                    currentCustomer.BillingCountryId = Convert.ToInt32(cmbBillingCountryGrp.SelectedItem.Value);
                }
                else
                {
                    currentCustomer.BillingCountryId = null;
                }
            }

            currentCustomer.BillingPostCode = txtBillingZipPostalCodeGrp.Text.ToString();

            currentCustomer.DriverLicense = null;
            currentCustomer.Email = txtEmailGrp.Text.ToString();
            currentCustomer.Fax = txtFaxGrp.Text.ToString();
            currentCustomer.Gender = "Male";
            currentCustomer.MemberCode = txtMemberCodeGrp.Text.ToString();
            currentCustomer.Mobile = txtPhoneGrp.Text.ToString();
            currentCustomer.GuestTypeId = (int)cmbGuestTypeGrp.SelectedItem.Value;
            currentCustomer.PassportCountryOfIssue = null;

            currentCustomer.Phone = txtPhoneGrp.Text.ToString();
            currentCustomer.CreatedUser = Master.LoggedUser.UsersId;
            currentCustomer.UpdatedUser = Master.LoggedUser.UsersId;
            currentCustomer.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;
            currentCustomer.IsGroupCustomer = true;
            currentCustomer.DsGroupCustomers = (DataSet)Session[Constants.SESSION_GROUPCUSTOMERS];


        }

        private void LoadGridLookupValues()
        {
            GuestType guestType = new GuestType();
            guestType.CompanyId = SessionHandler.CurrentCompanyId;

            List<GuestType> guestTypes = new GuestType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            ((GridViewDataComboBoxColumn)gvGroupMembers.Columns["GuestTypeId"]).PropertiesComboBox.DataSource = guestTypes;
            ((GridViewDataComboBoxColumn)gvGroupMembers.Columns["GuestTypeId"]).PropertiesComboBox.TextField = "GuestTypeName";
            ((GridViewDataComboBoxColumn)gvGroupMembers.Columns["GuestTypeId"]).PropertiesComboBox.ValueField = "GuestTypeId";
        }

        #endregion Methods

        #region Events

        protected void Page_Init(object sender, EventArgs e)
        {
            gvGroupMembers.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            this.LoadGridLookupValues();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInitData();

                if (!IsPostBack)
                {
                    this.CheckFromURL();
                    IsEditCustomer();
                    LoadInitialData();
                    ViewData();
                }

                AuthoriseUser();
               
            }
            catch (System.Exception)
            {

            }
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.CustomerManagement_Customer_Add)
                                || SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.CustomerManagement_Customer_Edit);
            btnClear.Visible = btnSave.Visible;

            btnReservation.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.ReservationManagement_Reservation_Add);
            btnSearch.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.CustomerManagement_Customer_Search);

            cmbGuestType.Buttons[0].Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_Add);
            cmbGuestTypeGrp.Buttons[0].Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_Add);
                
            if (!SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.CustomerManagement_Customer_View))
            {
                Response.Redirect(Constants.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadInitData()
        {
            //Load Guest Type
            cmbGuestType.DataSource = new GuestType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbGuestType.TextField = "GuestTypeName";
            cmbGuestType.ValueField = "GuestTypeId";
            cmbGuestType.DataBind();

            cmbGuestTypeGrp.DataSource = new GuestType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbGuestTypeGrp.TextField = "GuestTypeName";
            cmbGuestTypeGrp.ValueField = "GuestTypeId";
            cmbGuestTypeGrp.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveData();
            }
            catch (System.Exception ex)
            {
                throw ex;
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

        protected void chkUseSameBillingAddressGrp_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkUseSameBillingAddress.Checked)
            {
                txtCompanyAddressLine1Grp.Value = null;
                txtCompanyAddressLine2Grp.Value = null;
                txtCompanyStateGrp.Value = null;
                cmbCompanyCountryGrp.SelectedIndex = -1;
                txtCompanyPostCodeGrp.Value = null;
                txtCompanyCityGrp.Value = null;

                txtCompanyAddressLine1Grp.Enabled = false;
                txtCompanyAddressLine2Grp.Enabled = false;
                txtCompanyStateGrp.Enabled = false;
                cmbCompanyCountryGrp.Enabled = false;
                txtCompanyPostCodeGrp.Enabled = false;
                txtCompanyCityGrp.Enabled = false;

            }
            else
            {
                txtCompanyAddressLine1Grp.Enabled = true;
                txtCompanyAddressLine2Grp.Enabled = true;
                txtCompanyStateGrp.Enabled = true;
                cmbCompanyCountryGrp.Enabled = true;
                txtCompanyPostCodeGrp.Enabled = true;
                txtCompanyCityGrp.Enabled = true;

            }
        }

        protected void rblCustomerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblCustomerMode.SelectedValue == ((int)Common.Enums.CustomerModes.Individual).ToString())
            {
                tblIndividualCustomer.Visible = true;
                tblGroupCustomer.Visible = false;
                hdnCustomerMode.Value = "1";
            }
            else
            {
                tblIndividualCustomer.Visible = false;
                tblGroupCustomer.Visible = true;
                hdnCustomerMode.Value = "2";

            }
        }

        protected void gvGroupMembers_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "GuestTypeId") return;
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvGroupMembers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvGroupMembers.FindVisibleIndexByKeyValue(e.Keys[gvGroupMembers.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_GROUPCUSTOMERS] as DataSet;
            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0]
                .Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvGroupMembers.KeyFieldName])));

            gvGroupMembers.DataSource = dsData.Tables[0];
            gvGroupMembers.DataBind();

            Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;
        }

        protected void gvGroupMembers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GROUPCUSTOMERS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();

            Random rd = new Random();
            e.NewValues["CustomerId"] = rd.Next();
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
            e.NewValues["CreatedUser"] = SessionHandler.LoggedUser.UsersId;

            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString() != "Count")
                {
                    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
                }
            }
            gridView.CancelEdit();
            e.Cancel = true;

            dsData.Tables[0].Rows.Add(row);

            gvGroupMembers.DataSource = dsData.Tables[0];
            gvGroupMembers.DataBind();

            Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;

        }

        protected void gvGroupMembers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GROUPCUSTOMERS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Modify;
            e.NewValues["UpdatedUser"] = SessionHandler.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            gvGroupMembers.DataSource = dsData.Tables[0];
            gvGroupMembers.DataBind();

            Session[Constants.SESSION_GROUPCUSTOMERS] = dsData;
        }

        #endregion
    }
}
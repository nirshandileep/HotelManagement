using System;
using System.IO;
using ComMan = HBM.CompanyManagement;
using Status = HBM.Common.Enums;
using System.Drawing;
using HBM.Common;

namespace HBM.ControlPanel
{
    public partial class Company : System.Web.UI.Page
    {

        byte[] file = null;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.LoadCompany();
            }
            AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = Master.LoggedUser.IsUserAuthorised(Enums.Rights.CompanyManagement_Company_Add) ||
                                Master.LoggedUser.IsUserAuthorised(Enums.Rights.CompanyManagement_Company_Edit);
        }

        ComMan.Company company = new ComMan.Company();

        protected void LoadCompany()
        {
            try
            {
                company.CompanyId = SessionManager.SessionHandler.CurrentCompanyId;
                ComMan.Company currentCompany = new ComMan.Company();
                currentCompany = company.Select();
                txtCompanyName.Text = currentCompany.CompanyName;
                txtCompanyAddress.Text = currentCompany.CompanyAddress;
                txtCompanyCity.Text = currentCompany.CompanyCity;
                txtCompanyEmail.Text = currentCompany.CompanyEmail;
                txtCompanyTelephone.Text = currentCompany.CompanyTelephone;
                txtCompanyFax.Text = currentCompany.CompanyFax;
                txtWebURL.Text = currentCompany.WebURL;
                txtRegistrationNo.Text = currentCompany.RegistrationNo;
                txtVATNo.Text = currentCompany.VATNo;
                txtAdditionalDetails1.Text = currentCompany.AdditionalDetails1;
                txtAdditionalDetails2.Text = currentCompany.AdditionalDetails2;

                if (currentCompany.CompanyLogo.Length > 0)
                {
                    trImageRow.Visible = true;
                    bimgLogo.ContentBytes = currentCompany.CompanyLogo;
                    hdnCompanyLogo.Value = Convert.ToBase64String(currentCompany.CompanyLogo);

                }


            }
            catch (System.Exception)
            {


            }
        }

        protected bool SaveData()
        {
            bool result = false;

            try
            {

                company.CompanyId = SessionManager.SessionHandler.CurrentCompanyId;
                company.CompanyName = txtCompanyName.Text.Trim();
                company.CompanyAddress = txtCompanyAddress.Text.Trim();
                company.CompanyCity = txtCompanyCity.Text.Trim();
                company.CompanyEmail = txtCompanyEmail.Text.Trim();
                company.CompanyTelephone = txtCompanyTelephone.Text.Trim();
                company.CompanyFax = txtCompanyFax.Text.Trim();
                company.WebURL = txtWebURL.Text.Trim();
                company.RegistrationNo = txtRegistrationNo.Text.Trim();
                company.VATNo = txtVATNo.Text.Trim();
                company.AdditionalDetails1 = txtAdditionalDetails1.Text.Trim();
                company.AdditionalDetails2 = txtAdditionalDetails2.Text.Trim();

                company.StatusId = (int)Enums.HBMStatus.Modify;


                if (file != null)
                {
                    company.CompanyLogo = file;
                }
                else if (hdnCompanyLogo.Value != string.Empty)
                {
                    company.CompanyLogo = (byte[]) Convert.FromBase64String(hdnCompanyLogo.Value);
                }



                if (company.Save())
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                    this.LoadCompany();
                }


            }
            catch (System.Exception)
            {

            }

            return result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        protected void ucCompanyLogo_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            file = e.UploadedFile.FileBytes;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }

    }
}
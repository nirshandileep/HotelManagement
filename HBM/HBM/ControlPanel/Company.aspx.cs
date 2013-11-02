using System;
using System.IO;
using GenMan = HBM.GeneralManagement;
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
        }

        GenMan.Company company = new GenMan.Company();

        protected void LoadCompany()
        {
            try
            {
                company.CompanyId = SessionManager.SessionHandler.CurrentCompanyId;
                GenMan.Company currentCompany = new GenMan.Company();
                currentCompany = company.Select();
                txtCompanyName.Text = currentCompany.CompanyName;
                txtCompanyAddress.Text = currentCompany.CompanyAddress;
                txtCompanyCity.Text = currentCompany.CompanyCity;
                txtCompanyEmail.Text = currentCompany.CompanyEmail;
                txtCompanyTelephone.Text = currentCompany.CompanyTelephone;
                txtCompanyFax.Text = currentCompany.CompanyFax;

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
                company.StatusId = (int)Status.HBMStatus.Modify;


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
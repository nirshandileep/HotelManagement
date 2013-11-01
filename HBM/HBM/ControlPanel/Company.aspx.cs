using System;
using System.IO;
using GenMan = HBM.GeneralManagement;
using Status = HBM.Common.Enums;
using System.Drawing;

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
                GenMan.Company company1 = new GenMan.Company();
                company1 = company.Select();
                txtCompanyName.Text = company1.CompanyName;
                txtCompanyAddress.Text = company1.CompanyAddress;
                txtCompanyCity.Text = company1.CompanyCity;
                txtCompanyEmail.Text = company1.CompanyEmail;
                txtCompanyTelephone.Text = company1.CompanyTelephone;
                txtCompanyFax.Text = company1.CompanyFax;

                string base64String = Convert.ToBase64String(company1.CompanyLogo, 0, company1.CompanyLogo.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
                Image1.DataBind();
              

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
                company.CompanyLogo = file;

                if (company.Save())
                {
                    this.LoadCompany();
                    //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
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
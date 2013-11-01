using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenMan = HBM.GeneralManagement;
using Status = HBM.Common.Enums;
using HBM.Common;

namespace HBM.ControlPanel
{
    public partial class Company : System.Web.UI.Page
    {
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


    }
}
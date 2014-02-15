using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using HBM.Common;
using HBM.Utility;

namespace HBM
{
    public partial class Roles : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            gvRights.SettingsPager.PageSize = Constants.GRID_PAGESIZE;

            if (!IsPostBack)
            {
                if (Request.QueryString["RolesId"] != null)
                {
                    this.hdnRoleId.Value = Cryptography.Decrypt(Request.QueryString["RolesId"]);
                    this.DisplayData();
                    
                }
            }

            this.LoadRights();
            this.AuthoriseUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_Add)
                || Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_View))
            {
                Response.Redirect(Constants.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.hdnRoleId.Value != string.Empty)
                {
                    this.UpdateData();
                }
                else
                {
                    this.SaveData();
                }
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadRights()
        {
            try
            {
                UserMan.Rights RightsObj = new UserMan.Rights();

                if (this.hdnRoleId.Value != string.Empty)
                {
                    RightsObj.RolesId = Convert.ToInt32(this.hdnRoleId.Value);
                }

                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

                if (this.hdnRoleId.Value != string.Empty)
                {

                    for (int i = 0; i <= gvRights.VisibleRowCount - 1; i++)
                    {
                        if (gvRights.GetRowValues(i,"RolesId").ToString() != string.Empty)
                        {
                            gvRights.Selection.SelectRow(i);
                        }
                    }
                    
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected bool SaveData()
        {

            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                UserMan.Roles RolesObj = new UserMan.Roles();

                RolesObj.RoleName = txtRoleName.Text.Trim();

                if (!RolesObj.IsDuplicateRoleName(RolesObj.RoleName, Master.CurrentCompany.CompanyId))
                {

                    RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                    RolesObj.CompanyId = Master.CurrentCompany.CompanyId;
                    RolesObj.CreatedUser = Master.LoggedUser.UsersId;
                    RolesObj.UpdatedUser = Master.LoggedUser.UsersId;

                    if (RolesObj.Save(db, transaction))
                    {
                        List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                        if (myList.Count > 0)
                        {
                            for (int i = 0; i <= myList.Count - 1; i++)
                            {
                                RolesObj.RightId = Convert.ToInt32(myList[i].ToString());
                                RolesObj.SaveRoleRights(db, transaction);
                            }
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Select_Role + "')", true);
                            transaction.Rollback();

                        }
                    }

                    transaction.Commit();
                    result = true;

                    this.DisplayData();
                    
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Rolename + "')", true);

                }


            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return result;
        }

        protected bool UpdateData()
        {
            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                UserMan.Roles RolesObj = new UserMan.Roles();
                RolesObj.RolesId = Convert.ToInt32(this.hdnRoleId.Value);
                RolesObj.RoleName = txtRoleName.Text.Trim();
                RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                RolesObj.CompanyId = Master.CurrentCompany.CompanyId;
                RolesObj.UpdatedUser = Master.LoggedUser.UsersId;

                if (RolesObj.Save(db, transaction))
                {                  

                    //Delete exiting role rights
                    RolesObj.DeleteByRolesId(db, transaction);

                    List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                    if (myList.Count > 0)
                    {
                        for (int i = 0; i <= myList.Count - 1; i++)
                        {
                            RolesObj.RightId = Convert.ToInt32(myList[i].ToString());
                            RolesObj.SaveRoleRights(db, transaction);
                        }
                    }
                }

                transaction.Commit();
                result = true;

                this.DisplayData();

                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);

            }
            catch (System.Exception)
            {

            }

            return result;
        }

        protected void DisplayData()
        {
            try
            {

                int currentRoleId = Convert.ToInt32(this.hdnRoleId.Value);
                UserMan.Roles RolesObj = new UserMan.Roles();
                RolesObj.RolesId = currentRoleId;
                RolesObj.CompanyId = Master.CurrentCompany.CompanyId;
                RolesObj = RolesObj.Select();
                this.txtRoleName.Text = RolesObj.RoleName;
                this.txtRoleDescription.Text = RolesObj.RoleDescription;

                UserMan.Rights RightsObj = new UserMan.Rights();
                RightsObj.RolesId = RolesObj.RolesId;
                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

    }
}
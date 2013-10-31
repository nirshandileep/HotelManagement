using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using Status = HBM.Common.Enums;
using HBM.Common;

namespace HBM
{
    public partial class Users : System.Web.UI.Page
    {

        string currentPassword = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.LoadRoles();

            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    this.hdnUserId.Value = Request.QueryString["UserId"];
                    this.DisplayData();
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.hdnUserId.Value != string.Empty)
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

        protected void LoadRoles()
        {
            try
            {
                UserMan.Roles roles = new UserMan.Roles();
                ddlRoles.ValueField = "RolesId";
                ddlRoles.TextField = "RoleName";
                ddlRoles.DataSource = roles.SelectAllDataset();
                ddlRoles.DataBind();
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
                UserMan.Users users = new UserMan.Users();

                ////Check for existing uername
                users.UserName = txtUserName.Text.Trim();

                if (!users.IsUserIsDuplicateUserName(users.UserName, Master.CompanyId))
                {
                    users.EmailAddress = txtEmail.Text.Trim();

                    if (!users.IsDuplicateEmail(users.EmailAddress, Master.CompanyId))
                    {
                        users.FirstName = txtFirstName.Text.Trim();
                        users.LastName = txtLastName.Text.Trim();

                        users.Password = txtPassword.Text.Trim();
                        users.RolesId = Convert.ToInt32(ddlRoles.Value);
                        users.CreatedUser = Master.LoggedUser.UsersId;
                        users.CompanyId = Master.CompanyId;
                        users.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;
                        if (users.Save())
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                            this.ClearFormData();
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Email + "')", true);
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Username + "')", true);
                }


            }
            catch (System.Exception)
            {

            }

            return result;
        }

        protected bool UpdateData()
        {
            bool result = false;

            try
            {
                UserMan.Users users = new UserMan.Users();
                users.UsersId = Convert.ToInt32(this.hdnUserId.Value);
                users.UserName = txtUserName.Text.Trim();
                users.FirstName = txtFirstName.Text.Trim();
                users.LastName = txtLastName.Text.Trim();
                users.EmailAddress = txtEmail.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.CompanyId = Master.CompanyId;
                users.UpdatedUser = Master.LoggedUser.UsersId;
                users.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;
                users.RolesId = Convert.ToInt32(ddlRoles.Value);
                if (users.Save())
                {
                    this.ClearFormData();
                }

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

                int currentUserId = Convert.ToInt32(this.hdnUserId.Value);
                UserMan.Users users = new UserMan.Users();
                users.UsersId = currentUserId;
                users.CompanyId = Master.CompanyId;
                users = users.Select();
                txtUserName.Text = users.UserName;
                txtFirstName.Text = users.FirstName;
                txtLastName.Text = users.LastName;
                txtEmail.Text = users.EmailAddress;
                txtPassword.Text = users.Password;
                ddlRoles.SelectedItem = ddlRoles.Items.FindByValue(users.RolesId.ToString());

                currentPassword = users.Password;

            }
            catch (System.Exception)
            {


            }
        }

        protected void ClearFormData()
        {
            try
            {
                this.txtUserName.Text = string.Empty;
                this.txtFirstName.Text = string.Empty;
                this.txtLastName.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtConfirmPassword.Text = string.Empty;
                this.ddlRoles.SelectedIndex = -1;
                this.txtFirstName.Focus();

            }
            catch (System.Exception)
            {

            }
        }

        protected void txtPassword_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e)
        {
            e.Properties["cp_myPassword"] = currentPassword;
        }

        protected void txtConfirmPassword_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e)
        {
            e.Properties["cp_myPassword"] = currentPassword;

        }

    }
}
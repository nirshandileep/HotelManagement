using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using Status= HBM.Common.Enums;

namespace HBM
{
    public partial class Users : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["UserId"] != null)
                {
                    this.hdnUserId.Value = Request.QueryString["UserId"];
                    this.DisplayData();
                }

                this.LoadRoles();
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
                users.FirstName = txtFirstName.Text.Trim();
                users.LastName = txtLastName.Text.Trim();
                users.EmailAddress = txtEmail.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.RolesId = Convert.ToInt32(ddlRoles.Value);
                users.CreatedUser = 1;
                users.StatusId =(int) HBM.Common.Enums.BHMStatus.Active;
                users.Save();

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
                users.UserId = Convert.ToInt32(this.hdnUserId.Value);
                users.FirstName = txtFirstName.Text.Trim();
                users.LastName = txtLastName.Text.Trim();
                users.EmailAddress = txtEmail.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.RolesId = Convert.ToInt32(ddlRoles.Value);
                users.Save();

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
                users.UserId = currentUserId;
                users = users.Select();

                txtFirstName.Text = users.FirstName;
                txtLastName.Text = users.LastName;
                txtEmail.Text = users.EmailAddress;
                txtPassword.Text = users.Password;
                ddlRoles.SelectedIndex = ddlRoles.Items.IndexOf(ddlRoles.Items.FindByValue(users.RolesId));

            }
            catch (System.Exception)
            {


            }
        }

    }
}
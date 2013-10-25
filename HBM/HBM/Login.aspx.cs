using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using HBM.Common;

namespace HBM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            this.AuthenticateUser();
        }

        protected void AuthenticateUser()
        {
            try
            {
                UserMan.Users users = new UserMan.Users();

                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                int userID = 0;
                int companyId = 0;
                if (users.IsUserAuthenticated(userName, password, out userID, out companyId))
                {
                    if (userID > 0)
                    {
                        users.UsersId = userID;
                        users.CompanyId = companyId;
                        users = users.Select();
                        Session["LoggedUser"] = users;
                        Response.Redirect(HBM.Common.Constants.CONST_DEFAULTBACKPAGE, false);
                    }
                }
                else
                {
                    trMsg.Visible = true;
                    lblError.Text = HBM.Common.Messages.Invalid_Credentials;
                    lblError.Visible = true;
                }
            }
            catch (System.Exception)
            {
                
                
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;

namespace HBM
{
    public partial class UserSearch : System.Web.UI.Page
    {

        public UserMan.Users UserObj
        {
            get
            {
                UserMan.Users roles;
                return roles = new UserMan.Users();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvUsers.DataSource = UserObj.SelectAllDataset();
                gvUsers.DataBind();
            }
            catch (System.Exception)
            {

            }
        }

        
    }
}
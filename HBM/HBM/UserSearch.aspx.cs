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
                

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserMan.Users UserObj = new UserMan.Users();
                UserObj.CompanyId = 1;
                gvUsers.DataSource = UserObj.SelectAllDataset();
                gvUsers.DataBind();
            }
            catch (System.Exception)
            {

            }
        }

        
    }
}
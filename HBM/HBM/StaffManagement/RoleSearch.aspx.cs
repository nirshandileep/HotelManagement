using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using HBM.Utility;

namespace HBM
{
    public partial class RoleSearch : System.Web.UI.Page
    {
        public UserMan.Roles RolesObj
        {
            get
            {
                UserMan.Roles roles;
                return roles = new UserMan.Roles();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvRoles.DataSource = RolesObj.SelectAllDataset();
                gvRoles.DataBind();
            }
            catch (System.Exception )
            {                
                
            }
        }
    }
}
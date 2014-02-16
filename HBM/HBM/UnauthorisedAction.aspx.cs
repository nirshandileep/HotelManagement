using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBM
{
    public partial class UnauthorisedAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            if (Master != null)
            {
                Master.ClearSessions();
            }

            Response.Redirect(HBM.Common.Constants.URL_LOGIN, false);
        }
    }
}
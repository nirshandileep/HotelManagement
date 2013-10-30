using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Common;

namespace HBM.ControlPanel
{
    public partial class SwitchBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tcCommon.ActiveTab.Index = 0;
                iframePage.Attributes["src"] = Constants.CONST_BEDTYPE;
            }

        }

      
        protected void tcCommon_TabClick(object source, DevExpress.Web.ASPxTabControl.TabControlCancelEventArgs e)
        {
            switch (e.Tab.Index)
            {
                case 0:
                    iframePage.Attributes["src"] = Constants.CONST_BEDTYPE;
                    break;
                case 1:
                    iframePage.Attributes["src"] = Constants.CONST_DEPARTMENT;
                    break;
                case 2:
                    iframePage.Attributes["src"] = Constants.CONST_GAURANTEE;
                    break;
                case 3:
                    iframePage.Attributes["src"] = Constants.CONST_ROOMS;
                    break;
                case 4:
                    iframePage.Attributes["src"] = Constants.CONST_SOURCE;
                    break;




            }
        }
    }
}
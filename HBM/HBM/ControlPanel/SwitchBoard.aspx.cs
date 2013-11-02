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
            switch (e.Tab.Name)
            {
                case "BedType":
                    iframePage.Attributes["src"] = Constants.CONST_BEDTYPE;
                    break;
                case "Departments":
                    iframePage.Attributes["src"] = Constants.CONST_DEPARTMENT;
                    break;
                case "Gaurantee":
                    iframePage.Attributes["src"] = Constants.CONST_GAURANTEE;
                    break;
                case "Rooms":
                    iframePage.Attributes["src"] = Constants.CONST_ROOMS;
                    break;
                case "RatePlan":
                    iframePage.Attributes["src"] = Constants.CONST_RATEPLANS;
                    break;
                case "Source":
                    iframePage.Attributes["src"] = Constants.CONST_SOURCE;
                    break;
                case "TaxTypes":
                    iframePage.Attributes["src"] = Constants.CONST_TAXTYPES;
                    break;      
            }
        }
    }
}
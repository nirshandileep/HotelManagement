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
                iframePage.Attributes["src"] = Constants.URL_BEDTYPE;
            }

        }


        protected void tcCommon_TabClick(object source, DevExpress.Web.ASPxTabControl.TabControlCancelEventArgs e)
        {
            switch (e.Tab.Name)
            {
                case "BedType":
                    iframePage.Attributes["src"] = Constants.URL_BEDTYPE;
                    break;
                case "Departments":
                    iframePage.Attributes["src"] = Constants.URL_DEPARTMENT;
                    break;
                case "Gaurantee":
                    iframePage.Attributes["src"] = Constants.URL_GAURANTEE;
                    break;
                case "Rooms":
                    iframePage.Attributes["src"] = Constants.URL_ROOMS;
                    break;
                case "RatePlan":
                    iframePage.Attributes["src"] = Constants.URL_RATEPLANS;
                    break;
                case "Source":
                    iframePage.Attributes["src"] = Constants.URL_SOURCE;
                    break;
                case "TaxTypes":
                    iframePage.Attributes["src"] = Constants.URL_TAXTYPES;
                    break;
                case "AdditionalServiceType":
                    iframePage.Attributes["src"] = Constants.URL_ADDITIONALSERVICETYPE;
                    break;
                case "AdditionalService":
                    iframePage.Attributes["src"] = Constants.URL_ADDITIONALSERVICE;
                    break;
                case "GuestType":
                    iframePage.Attributes["src"] = Constants.URL_GUESTTYPES;
                    break;
                case "CreditCardTypes":
                    iframePage.Attributes["src"] = Constants.URL_CREDITCARDTYPE;
                    break;
                case "PaymentTypes":
                    iframePage.Attributes["src"] = Constants.URL_PAYMENTTYPES;
                    break;

            }


        }
    }
}
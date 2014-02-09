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
            AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            tcCommon.Tabs.FindByName("BedType").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Bedtypes_View);
            tcCommon.Tabs.FindByName("Departments").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Departments_View);
            tcCommon.Tabs.FindByName("Gaurantee").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Gaurantee_View);
            tcCommon.Tabs.FindByName("Rooms").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Rooms_View);
            tcCommon.Tabs.FindByName("RatePlan").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_RatePlan_View);
            tcCommon.Tabs.FindByName("RoomRatePlan").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_RoomRatePlan_View);
            tcCommon.Tabs.FindByName("Source").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Source_View);
            tcCommon.Tabs.FindByName("TaxTypes").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_TaxType_View);
            tcCommon.Tabs.FindByName("AdditionalServiceType").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServiceType_View);
            tcCommon.Tabs.FindByName("AdditionalService").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServices_View);
            tcCommon.Tabs.FindByName("GuestType").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_View);
            tcCommon.Tabs.FindByName("CreditCardTypes").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_CreditCardType_View);
            tcCommon.Tabs.FindByName("PaymentTypes").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_PaymentType_View);
            tcCommon.Tabs.FindByName("ServiceMethods").Visible = SessionManager.SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_ServiceMethod_View);
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
                case "RoomRatePlan":
                    iframePage.Attributes["src"] = Constants.URL_ROOMRATEPLANS;
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
                case "ServiceMethods":
                    iframePage.Attributes["src"] = Constants.URL_SERVICEMETHODS;
                    break;

            }


        }
    }
}
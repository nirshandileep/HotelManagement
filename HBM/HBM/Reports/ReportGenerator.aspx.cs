using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Reporting;
using HBM.SessionManager;

namespace HBM.Reports
{
    public partial class ReportGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.LoadReportList();

        }

        private void LoadReportList()
        {
            HBM.Reporting.Reports reports = new Reporting.Reports();
            cmbReportType.DataSource = reports.GetReportTypes();
            cmbReportType.ValueField = "key";
            cmbReportType.TextField = "Value";
            cmbReportType.DataBind();


        }

        protected void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

          

            switch (cmbReportType.SelectedItem.Value.ToString())
            {
                case "0":
                    this.LoadCustomerList();
                    break;

                case "1":
                    break;

            }



        }

        private void LoadCustomerList()
        {
            Reporting.Reports report = new Reporting.Reports();
            gvReports.DataSource = report.GetCustomerList( SessionHandler.CurrentCompanyId).Tables[0];
            gvReports.DataBind();

        }

        protected void cbmExporter_ButtonClick(object source, DevExpress.Web.ASPxEditors.ButtonEditClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {

             
            }

        }
    }


}
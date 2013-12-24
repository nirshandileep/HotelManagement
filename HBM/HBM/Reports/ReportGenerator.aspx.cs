using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Reporting;
using HBM.SessionManager;
using System.Data;
using DevExpress.XtraPrinting;
using DevExpress.Web.ASPxGridView;
using HBM.Common;

namespace HBM.Reports
{
    public partial class ReportGenerator : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadReportList();

            if (Session[Constants.SESSION_CURRENTREPORT] != null)
            {
                gvReports.DataSource = (DataTable)Session[Constants.SESSION_CURRENTREPORT];
                gvReports.DataBind();
            }

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
            gvReports.DataSource = report.GetCustomerList(SessionHandler.CurrentCompanyId).Tables[0];
            gvReports.DataBind();

            if (report.GetCustomerList(SessionHandler.CurrentCompanyId).Tables[0] != null && report.GetCustomerList(SessionHandler.CurrentCompanyId).Tables[0].Rows.Count > 0)
            {
                Session[Constants.SESSION_CURRENTREPORT] = report.GetCustomerList(SessionHandler.CurrentCompanyId).Tables[0];
                cbmExporter.Visible = true;
                gvExporter.FileName = "Customer List";
            }

        }

        protected void cbmExporter_ButtonClick(object source, DevExpress.Web.ASPxEditors.ButtonEditClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {

                switch (cbmExporter.Text)
                {
                    case "PDF":
                        gvExporter.GridViewID = gvReports.ID;    
                        
                        gvExporter.WritePdfToResponse();
                        break;

                    case "RTF":
                        gvExporter.GridViewID = gvReports.ID;
                        gvExporter.WriteRtfToResponse();                                          
                        break;

                    case "Excel":
                        gvExporter.GridViewID = gvReports.ID;                       
                        gvExporter.WriteXlsToResponse();
                        break;

                    case "CSV":
                        gvExporter.GridViewID = gvReports.ID;                       
                        gvExporter.WriteCsvToResponse();
                        break;

                }



            }

        }
    }


}
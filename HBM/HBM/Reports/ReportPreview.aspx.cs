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
    public partial class ReportPreview : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvReports.SettingsPager.PageSize = Constants.GRID_PAGESIZE;

            if (Session[Constants.SESSION_CURRENTREPORT] != null)
            {
                gvReports.DataSource = (DataTable)Session[Constants.SESSION_CURRENTREPORT];
                gvReports.DataBind();
                cbmExporter.Visible = true;
            }
            else
            {
                cbmExporter.Visible = false;
            }
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                    
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenMan = HBM.GeneralManagement;
using DevExpress.Web.ASPxGridView;
using System.Data;

namespace HBM.ControlPanel
{
    public partial class BedType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.LoadBedTypes();
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadBedTypes()
        {
            try
            {
                GenMan.BedType bedType = new GenMan.BedType();
                gvBedTypes.DataSource = bedType.SelectAllDataset();
                gvBedTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvBedTypes_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {


            }
            catch (System.Exception)
            {


            }

        }

        protected void gvBedTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = (DataTable)grid.DataSource;

            table.Rows.Add(new Object[] { e.NewValues["BedTypeName"], e.NewValues["BedTypeDescription"] });

            Session["Table"] = table;

            e.Cancel = true;
            grid.CancelEdit();
        }
    }
}
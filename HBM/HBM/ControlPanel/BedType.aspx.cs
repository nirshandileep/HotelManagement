using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenMan = HBM.GeneralManagement;

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
                gvBedTypes.DataSource= bedType.SelectAllDataset();
                gvBedTypes.DataBind();
                
            }
            catch (System.Exception)
            {
                
                
            }
        }
    }
}
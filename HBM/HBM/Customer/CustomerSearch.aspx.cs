using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Utility;
using DevExpress.Web.ASPxGridView;
using HBM.Common;


namespace HBM
{
    public partial class CustomerSearch : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            gvCustomers.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvCustomers.DataSource = new CustomerManagement.Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();            
            gvCustomers.DataBind();                        
        }

       

    }
}
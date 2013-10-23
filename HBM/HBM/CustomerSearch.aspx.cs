using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBM
{
    public partial class CustomerSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvCustomers.DataSource = new CustomerManagement.Customer() { CompanyId = Master.CompanyId }.SelectAllList();
            gvCustomers.DataBind();
        }
    }
}
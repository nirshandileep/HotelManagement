using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Utility;
using DevExpress.Web.ASPxGridView;
using HBM.Common;
using System.Data;


namespace HBM
{
    public partial class CustomerSearch : System.Web.UI.Page
    {
        DataSet dsCustomers = new DataSet();

        protected void Page_Init(object sender, EventArgs e)
        {
            gvCustomers.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvCustomers.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadCustomers();  
        }

        protected void gvCustomers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvCustomers.FindVisibleIndexByKeyValue(e.Keys[gvCustomers.KeyFieldName]);
            e.Cancel = true;
            
            CustomerManagement.Customer customer = new CustomerManagement.Customer();
            customer.CustomerId =(int)e.Keys[gvCustomers.KeyFieldName];

           if (customer.Delete())
            {
                this.LoadCustomers();
            }

        }

        private void LoadCustomers()
        {
            dsCustomers = new CustomerManagement.Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
            gvCustomers.DataSource = dsCustomers;
            gvCustomers.DataBind();            
        }
       

    }
}
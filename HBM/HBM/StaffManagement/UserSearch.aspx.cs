using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using HBM.Utility;
using HBM.Common;

namespace HBM
{
    public partial class UserSearch : System.Web.UI.Page
    {

        UserMan.Users UserObj = new UserMan.Users();

        protected void Page_Init(object sender, EventArgs e)
        {
            gvUsers.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvUsers.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadUsers();
            }
            catch (System.Exception)
            {

            }
        }

        protected void gvUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvUsers.FindVisibleIndexByKeyValue(e.Keys[gvUsers.KeyFieldName]);
            e.Cancel = true;
            
            UserObj.UsersId = (int)e.Keys[gvUsers.KeyFieldName];

            if (UserObj.Delete())
            {
                this.LoadUsers();
            }
        }
        
        private void LoadUsers()
        {
           
            UserObj.CompanyId = Master.CurrentCompany.CompanyId;
            gvUsers.DataSource = UserObj.SelectAllDataset();
            gvUsers.DataBind();
        }
        
    }
}
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
                AuthoriseUser();
            }
            catch (System.Exception)
            {

            }
        }

        private void AuthoriseUser()
        {
            gvUsers.Columns[0].Visible = Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_User_Delete);
            gvUsers.Columns[1].Visible = Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_User_Edit) ||
                Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_User_View);
            gvUsers.Columns[2].Visible = !gvUsers.Columns[1].Visible;

            if (!Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_User_Search))
            {
                Response.Redirect(Constants.URL_UNAUTHORISEDACTION, false);
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
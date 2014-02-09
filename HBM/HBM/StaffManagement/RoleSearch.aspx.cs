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
    public partial class RoleSearch : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            gvRoles.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvRoles.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoles();

                AuthoriseUser();
            }
            catch (System.Exception )
            {                
                
            }
        }

        private void AuthoriseUser()
        {

            gvRoles.Columns["Actions"].Visible = Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_Delete);
            gvRoles.Columns[1].Visible = Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_Edit)
                     || Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_View);
            gvRoles.Columns[2].Visible = !gvRoles.Columns[1].Visible;

            if (!Master.LoggedUser.IsUserAuthorised(Enums.Rights.UserManagement_Roles_Search))
            {
                Response.Redirect(Constants.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void gvRoles_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvRoles.FindVisibleIndexByKeyValue(e.Keys[gvRoles.KeyFieldName]);
            e.Cancel = true;

            UserMan.Roles roles = new UserMan.Roles();

            roles.RolesId = (int)e.Keys[gvRoles.KeyFieldName];

            if (roles.Delete())
            {
                this.LoadRoles();
            }
        }


        private void LoadRoles()
        {
            UserMan.Roles roles= new UserMan.Roles();
            roles.CompanyId = SessionManager.SessionHandler.LoggedUser.CompanyId;
            gvRoles.DataSource = roles.SelectAllDataset();
            gvRoles.DataBind();
        }
    }
}
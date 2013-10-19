using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserMan = HBM.UserManagement;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using HBM.Common;

namespace HBM
{
    public partial class Roles : System.Web.UI.Page
    {

        public UserMan.Rights RightsObj
        {
            get
            {
                UserMan.Rights rights;
                return rights = new UserMan.Rights();
            }
        }

        public UserMan.Roles RolesObj
        {
            get
            {
                UserMan.Roles roles;
                return roles = new UserMan.Roles();
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            this.LoadRights();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void LoadRights()
        {
            try
            {
                gvRights.DataSource = RightsObj.SelectAllDataset();
                gvRights.DataBind();
            }
            catch (System.Exception ex)
            {

            }
        }

        protected bool SaveData()
        {
            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                RolesObj.RoleName = txtRoleName.Text.Trim();
                RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                RolesObj.CreatedUser=0;
                RolesObj.CreatedDate = DateTime.Now;
                RolesObj.UpdatedUser = 0;
                RolesObj.UpdatedDate = DateTime.Now;                
                RolesObj.Save(db,transaction);

                transaction.Commit();
                result = true;
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();              

            }

            return result;
        }

    }
}
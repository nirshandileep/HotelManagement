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
               

        protected void Page_Load(object sender, EventArgs e)
        {
                       

            if (Request.QueryString["RoleId"] != null)
            {
                
                this.hdnRoleId.Value = Request.QueryString["RoleId"];
                this.DisplayRoles();

            }
            else
            {
                this.LoadRights();

            }
            


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                this.SaveData();
            }
            catch (System.Exception)
            {


            }
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
                throw ex;
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

                UserMan.Roles RolesObj = new UserMan.Roles();

                RolesObj.RoleName = txtRoleName.Text.Trim();
                RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                RolesObj.CompanyId = 1;
                RolesObj.CreatedUser = 1;
                RolesObj.UpdatedUser = 1;

                if (RolesObj.Save(db, transaction))
                {
                    List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                    if (myList.Count > 0)
                    {
                        for (int i = 0; i <= myList.Count - 1; i++)
                        {
                            RolesObj.RightId = Convert.ToInt32(myList[i].ToString());
                            RolesObj.SaveRoleRights(db, transaction);
                        }
                    }
                }               
                
                transaction.Commit();
                result = true;
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return result;
        }

        protected void DisplayRoles()
        {
            try
            {

                int currentRoleId= Convert.ToInt32(this.hdnRoleId.Value);
                UserMan.Roles RolesObj = new UserMan.Roles();
                RolesObj.RoleId = currentRoleId;
                RolesObj.CompanyId = 1;
                RolesObj.Select();
                this.txtRoleName.Text = RolesObj.RoleName;
                this.txtRoleDescription.Text = RolesObj.RoleDescription;


            }
            catch (System.Exception)
            {
                
                
            }
        }

    }
}
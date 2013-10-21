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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["RolesId"] != null)
                {
                    this.hdnRoleId.Value = Request.QueryString["RolesId"];
                    this.DisplayData();
                }

                this.LoadRights();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.hdnRoleId.Value != string.Empty)
                {
                    this.UpdateData();
                }
                else
                {
                    this.SaveData();
                }

            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadRights()
        {
            try
            {
                UserMan.Rights RightsObj = new UserMan.Rights();

                if (this.hdnRoleId.Value != string.Empty)
                {
                    RightsObj.RolesId = Convert.ToInt32(this.hdnRoleId.Value);
                }

                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

                if (this.hdnRoleId.Value != string.Empty)
                {

                    for (int i = 0; i <= gvRights.VisibleRowCount - 1; i++)
                    {
                        if (gvRights.GetRowValues(i,"RolesId").ToString() != string.Empty)
                        {
                            gvRights.Selection.SelectRow(i);
                        }
                    }
                    
                }

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
                RolesObj.CompanyId = Master.CompanyId;
                RolesObj.CreatedUser = Master.LoggedUser.UsersId;
                RolesObj.UpdatedUser = Master.LoggedUser.UsersId;

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

        protected bool UpdateData()
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
                RolesObj.RolesId = Convert.ToInt32(this.hdnRoleId.Value);
                RolesObj.RoleName = txtRoleName.Text.Trim();
                RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                RolesObj.CompanyId = Master.CompanyId;
                RolesObj.UpdatedUser = Master.LoggedUser.UsersId;

                if (RolesObj.Save(db, transaction))
                {
                    List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                    //Delete exiting role rights
                    RolesObj.DeleteByRolesId(db, transaction);

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
            catch (System.Exception)
            {

            }

            return result;
        }

        protected void DisplayData()
        {
            try
            {

                int currentRoleId = Convert.ToInt32(this.hdnRoleId.Value);
                UserMan.Roles RolesObj = new UserMan.Roles();
                RolesObj.RolesId = currentRoleId;
                RolesObj.CompanyId = Master.CompanyId;
                RolesObj = RolesObj.Select();
                this.txtRoleName.Text = RolesObj.RoleName;
                this.txtRoleDescription.Text = RolesObj.RoleDescription;

                UserMan.Rights RightsObj = new UserMan.Rights();
                RightsObj.RolesId = RolesObj.RolesId;
                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

    }
}
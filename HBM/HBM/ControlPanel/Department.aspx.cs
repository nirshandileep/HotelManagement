using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenMan = HBM.GeneralManagement;
using DevExpress.Web.ASPxGridView;
using System.Data;
using HBM.Common;
using System.Collections;


namespace HBM.Reservation
{
    public partial class Department : System.Web.UI.Page
    {

        DataSet dsData = new DataSet();
        GenMan.Departments departments = new GenMan.Departments();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                gvDepartment.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadDepartments();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["DepartmentId"] };
                Session[Constants.SESSION_DEPARTMENT] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadDepartments()
        {
            try
            {
                departments.CompanyId = 1;
                dsData = departments.SelectAllDataset();
                gvDepartment.DataSource = dsData.Tables[0];
                gvDepartment.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvDepartment_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvDepartment.FindVisibleIndexByKeyValue(e.Keys[gvDepartment.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_DEPARTMENT] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvDepartment.KeyFieldName])));
                       

            if (departments.Save(dsData))
            {
                this.LoadDepartments();
            }
        }

        protected void gvDepartment_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_DEPARTMENT] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["DepartmentId"] = rd.Next();
            e.NewValues["StatusId"] = (int)Enums.BHMStatus.Active;
            e.NewValues["CompanyId"] = 1;
            e.NewValues["CreatedUser"] = 1;

            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString() != "Count")
                {
                    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
                }
            }
            gridView.CancelEdit();
            e.Cancel = true;

            dsData.Tables[0].Rows.Add(row);

            if (departments.Save(dsData))
            {
                this.LoadDepartments();
            }

        }

        protected void gvDepartment_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_DEPARTMENT] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["StatusId"] = (int)Enums.BHMStatus.Modify;
            e.NewValues["UpdatedUser"] = 1;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            if (departments.Save(dsData))
            {
                this.LoadDepartments();
            }
        }
    }
}
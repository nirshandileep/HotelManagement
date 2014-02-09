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
using HBM.SessionManager;
using DevExpress.Web.ASPxEditors;

namespace HBM.ControlPanel
{
    public partial class ServiceMethod : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        DataSet dsServiceMethods = new DataSet();
        
        GenMan.ServiceMethods serviceMethods = new GenMan.ServiceMethods();
        
        protected void Page_Init(object sender, EventArgs e)
        {
            gvServiceMethods.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            this.LoadServiceMethods();        

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvServiceMethods.DataBind();
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadServiceMethods()
        {
            try
            {
                serviceMethods.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = serviceMethods.SelectAllDataset();
                gvServiceMethods.DataSource = dsData.Tables[0];
                
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["ServiceMethodID"] };
                Session[Constants.SESSION_SERVICEMETHODS] = dsData;

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvServiceMethods_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_SERVICEMETHODS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["ServiceMethodID"] = rd.Next();
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
            e.NewValues["CompanyId"] = SessionHandler.CurrentCompanyId; ;
            e.NewValues["CreatedUser"] = SessionHandler.LoggedUser.UsersId;

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

            serviceMethods.ServiceMethod = e.NewValues["ServiceMethod"].ToString();
            
            if (!serviceMethods.IsDuplicateTypeName())
            {

                if (serviceMethods.Save(dsData))
                {
                    this.LoadServiceMethods();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }
        }

        protected void gvServiceMethods_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_SERVICEMETHODS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Modify;
            e.NewValues["UpdatedUser"] = SessionHandler.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            serviceMethods.ServiceMethodID = Convert.ToInt32(e.Keys["ServiceMethodID"].ToString());
            serviceMethods.ServiceMethod = e.NewValues["ServiceMethod"].ToString();
            
            if (!serviceMethods.IsDuplicateTypeName())
            {
                if (serviceMethods.Save(dsData))
                {
                    this.LoadServiceMethods();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }

        }

        protected void gvServiceMethods_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvServiceMethods.FindVisibleIndexByKeyValue(e.Keys[gvServiceMethods.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_SERVICEMETHODS] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvServiceMethods.KeyFieldName])));


            if (serviceMethods.Save(dsData))
            {
                this.LoadServiceMethods();
            }



        }

        protected void gvServiceMethods_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "ServiceMethodID") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvServiceMethods_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_ServiceMethod_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_ServiceMethod_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_ServiceMethod_Delete);
                    break;
            }
        }
    }
}
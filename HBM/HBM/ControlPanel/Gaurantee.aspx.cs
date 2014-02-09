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

namespace HBM.Reservation
{
    public partial class Gaurantee : System.Web.UI.Page
    {

        DataSet dsData = new DataSet();
        GenMan.Gaurantee gaurantee = new GenMan.Gaurantee();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                gvGaurantee.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadGaurantee();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["GuaranteeId"] };
                Session[Constants.SESSION_GAURANTEE] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadGaurantee()
        {
            try
            {
                gaurantee.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = gaurantee.SelectAllDataset();
                gvGaurantee.DataSource = dsData.Tables[0];
                gvGaurantee.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvGaurantee_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GAURANTEE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["GuaranteeId"] = rd.Next();
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
            e.NewValues["CompanyId"] = SessionHandler.CurrentCompanyId;
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

            if (gaurantee.Save(dsData))
            {
                this.LoadGaurantee();
            }


        }

        protected void gvGaurantee_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GAURANTEE] as DataSet;
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

            if (gaurantee.Save(dsData))
            {
                this.LoadGaurantee();
            }

        }

        protected void gvGaurantee_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvGaurantee.FindVisibleIndexByKeyValue(e.Keys[gvGaurantee.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_GAURANTEE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvGaurantee.KeyFieldName])));

            if (gaurantee.Save(dsData))
            {
                this.LoadGaurantee();
            }
        }

        protected void gvGaurantee_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Gaurantee_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Gaurantee_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_Gaurantee_Delete);
                    break;
            }
        }
      
    }
}
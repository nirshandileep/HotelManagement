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


namespace HBM.ControlPanel
{
    public partial class GuestTypes : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.GuestType guestType = new GenMan.GuestType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                gvGuestTypes.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadGuestTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["GuestTypeId"] };
                Session[Constants.SESSION_GUESTTYPE] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadGuestTypes()
        {
            try
            {
                guestType.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = guestType.SelectAllDataset();
                gvGuestTypes.DataSource = dsData.Tables[0];
                gvGuestTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvGuestTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GUESTTYPE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["GuestTypeId"] = rd.Next();
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

            guestType.GuestTypeName = e.NewValues["GuestTypeName"].ToString();


            if (!guestType.IsDuplicateTypeName())
            {

                if (guestType.Save(dsData))
                {
                    this.LoadGuestTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }


        }

        protected void gvGuestTypes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_GUESTTYPE] as DataSet;
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

            guestType.GuestTypeId = Convert.ToInt32(e.Keys["GuestTypeId"].ToString());
            guestType.GuestTypeName = e.NewValues["GuestTypeName"].ToString();

            if (!guestType.IsDuplicateTypeName())
            {
                if (guestType.Save(dsData))
                {
                    this.LoadGuestTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }
        }

        protected void gvGuestTypes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvGuestTypes.FindVisibleIndexByKeyValue(e.Keys[gvGuestTypes.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_GUESTTYPE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvGuestTypes.KeyFieldName])));


            if (guestType.Save(dsData))
            {
                this.LoadGuestTypes();
            }



        }

        protected void gvGuestTypes_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_GuestType_Delete);
                    break;
            }
        }
    }
}
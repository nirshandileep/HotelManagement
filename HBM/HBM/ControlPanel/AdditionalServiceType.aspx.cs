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
    public partial class AdditionalServiceType : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.AdditionalServiceType additionalServiceType = new GenMan.AdditionalServiceType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                gvAdditionalServiceType.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadAdditionalServiceTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["AdditionalServiceTypeId"] };
                Session[Constants.SESSION_ADDITIONALSERVICE] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadAdditionalServiceTypes()
        {
            try
            {
                additionalServiceType.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = additionalServiceType.SelectAllDataset();
                gvAdditionalServiceType.DataSource = dsData.Tables[0];
                gvAdditionalServiceType.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvAdditionalServiceType_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_ADDITIONALSERVICE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["AdditionalServiceTypeId"] = rd.Next();
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

            additionalServiceType.AdditionalServiceTypeName = e.NewValues["AdditionalServiceType"].ToString();

            if (!additionalServiceType.IsDuplicateTypeName())
            {
                if (additionalServiceType.Save(dsData))
                {
                    this.LoadAdditionalServiceTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }

        }

        protected void gvAdditionalServiceType_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_ADDITIONALSERVICE] as DataSet;
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

            additionalServiceType.AdditionalServiceTypeId = Convert.ToInt32(e.Keys["AdditionalServiceTypeId"].ToString());
            additionalServiceType.AdditionalServiceTypeName = e.NewValues["AdditionalServiceType"].ToString();

            if (!additionalServiceType.IsDuplicateTypeName())
            {

                if (additionalServiceType.Save(dsData))
                {
                    this.LoadAdditionalServiceTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }


        }

        protected void gvAdditionalServiceType_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvAdditionalServiceType.FindVisibleIndexByKeyValue(e.Keys[gvAdditionalServiceType.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_ADDITIONALSERVICE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvAdditionalServiceType.KeyFieldName])));


            if (additionalServiceType.Save(dsData))
            {
                this.LoadAdditionalServiceTypes();
            }



        }

        protected void gvAdditionalServiceType_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServiceType_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServiceType_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServiceType_Delete);
                    break;
            }
        }
    }
}
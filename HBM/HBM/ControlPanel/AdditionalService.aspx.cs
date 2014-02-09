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
    public partial class AdditionalService : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        DataSet dsAdditionalServiceType = new DataSet();
        DataSet dsServiceMethods = new DataSet();


        GenMan.AdditionalService additionalService = new GenMan.AdditionalService();
        GenMan.AdditionalServiceType additionalServiceType = new GenMan.AdditionalServiceType();
        GenMan.ServiceMethods serviceMethods = new GenMan.ServiceMethods();



        protected void Page_Init(object sender, EventArgs e)
        {
            gvAdditionalService.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

            this.LoadAdditionalService();
            this.LoadAdditionalServiceTypes();
            this.LoadServiceMethods();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvAdditionalService.DataBind();
            }
            catch (System.Exception)
            {

            }
        }


        protected void LoadAdditionalService()
        {
            try
            {
                additionalService.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = additionalService.SelectAllDataset();
                gvAdditionalService.DataSource = dsData.Tables[0];


                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["AdditionalServiceId"] };
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
                dsAdditionalServiceType = additionalServiceType.SelectAllDataset();
                dsAdditionalServiceType.Tables[0].TableName = "AdditionalService";
                ((GridViewDataComboBoxColumn)gvAdditionalService.Columns["AdditionalServiceTypeId"]).PropertiesComboBox.DataSource = dsAdditionalServiceType.Tables[0];

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
                dsServiceMethods = serviceMethods.SelectAllDataset();
                dsServiceMethods.Tables[0].TableName = "ServiceMethods";
                ((GridViewDataComboBoxColumn)gvAdditionalService.Columns["ServiceMethodID"]).PropertiesComboBox.DataSource = dsServiceMethods.Tables[0];

            }
            catch (System.Exception)
            {


            }
        }


        protected void gvAdditionalService_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_ADDITIONALSERVICE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["AdditionalServiceId"] = rd.Next();
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

            additionalService.ServiceCode = e.NewValues["ServiceCode"].ToString();

            if (!additionalService.IsDuplicateTypeName())
            {

                if (additionalService.Save(dsData))
                {
                    this.LoadAdditionalService();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }
        }

        protected void gvAdditionalService_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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

            additionalService.AdditionalServiceId = Convert.ToInt32(e.Keys["AdditionalServiceId"].ToString());
            additionalService.ServiceCode = e.NewValues["ServiceCode"].ToString();

            if (!additionalService.IsDuplicateTypeName())
            {
                if (additionalService.Save(dsData))
                {
                    this.LoadAdditionalService();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }

        }

        protected void gvAdditionalService_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvAdditionalService.FindVisibleIndexByKeyValue(e.Keys[gvAdditionalService.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_ADDITIONALSERVICE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvAdditionalService.KeyFieldName])));


            if (additionalService.Save(dsData))
            {
                this.LoadAdditionalService();
            }



        }

        protected void gvAdditionalService_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "AdditionalServiceTypeId" && e.Column.FieldName != "ServiceMethodID") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvAdditionalService_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServices_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServices_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_AdditionalServices_Delete);
                    break;
            }
        }
    }
}
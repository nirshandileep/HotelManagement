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
    public partial class TaxType : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.TaxType taxType = new GenMan.TaxType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                gvTaxTypes.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadTaxTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["TaxTypeId"] };
                Session[Constants.SESSION_TAXTYPES] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadTaxTypes()
        {
            try
            {
                taxType.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = taxType.SelectAllDataset();
                gvTaxTypes.DataSource = dsData.Tables[0];
                gvTaxTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvTaxTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_TAXTYPES] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["TaxTypeId"] = rd.Next();
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

            taxType.TaxTypeName = e.NewValues["TaxTypeName"].ToString();

             if (!taxType.IsDuplicateTypeName())
             {
                 if (taxType.Save(dsData))
                 {
                     this.LoadTaxTypes();
                 }
             }
             else
             {
                 throw new System.Exception(Messages.Duplicate_record);
             }


        }

        protected void gvTaxTypes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_TAXTYPES] as DataSet;
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

            taxType.TaxTypeId = Convert.ToInt32(e.Keys["TaxTypeId"].ToString());
            taxType.TaxTypeName = e.NewValues["TaxTypeName"].ToString();

            if (!taxType.IsDuplicateTypeName())
            {

                if (taxType.Save(dsData))
                {
                    this.LoadTaxTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }

        }

        protected void gvTaxTypes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvTaxTypes.FindVisibleIndexByKeyValue(e.Keys[gvTaxTypes.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_TAXTYPES] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvTaxTypes.KeyFieldName])));
            
            if (taxType.Save(dsData))
            {
                this.LoadTaxTypes();
            }



        }

        protected void gvTaxTypes_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_TaxType_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_TaxType_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_TaxType_Delete);
                    break;
            }
        }
    }
}
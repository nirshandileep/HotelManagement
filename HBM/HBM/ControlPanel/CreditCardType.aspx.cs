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
    public partial class CreditCardType : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.CreditCardType creditCardType = new GenMan.CreditCardType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                gvCreditCardTypes.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadCreditCardTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["CreditCardTypeId"] };
                Session[Constants.SESSION_CREDITCARDTYPE] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadCreditCardTypes()
        {
            try
            {
                creditCardType.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = creditCardType.SelectAllDataset();
                gvCreditCardTypes.DataSource = dsData.Tables[0];
                gvCreditCardTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvCreditCardTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_CREDITCARDTYPE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["CreditCardTypeId"] = rd.Next();
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

            creditCardType.Name = e.NewValues["Name"].ToString();
            
            if (!creditCardType.IsDuplicateTypeName())
            {
                if (creditCardType.Save(dsData))
                {
                    this.LoadCreditCardTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }


        }

        protected void gvCreditCardTypes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_CREDITCARDTYPE] as DataSet;
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

            creditCardType.CreditCardTypeId = Convert.ToInt32(e.Keys["CreditCardTypeId"].ToString());
            creditCardType.Name = e.NewValues["Name"].ToString();

            if (!creditCardType.IsDuplicateTypeName())
            {
                if (creditCardType.Save(dsData))
                {
                    this.LoadCreditCardTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);

            }

        }

        protected void gvCreditCardTypes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvCreditCardTypes.FindVisibleIndexByKeyValue(e.Keys[gvCreditCardTypes.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_CREDITCARDTYPE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvCreditCardTypes.KeyFieldName])));


            if (creditCardType.Save(dsData))
            {
                this.LoadCreditCardTypes();
            }



        }

        protected void gvCreditCardTypes_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            switch (e.ButtonType)
            {
                case ColumnCommandButtonType.New:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_CreditCardType_Add);
                    break;
                case ColumnCommandButtonType.Edit:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_CreditCardType_Edit);
                    break;
                case ColumnCommandButtonType.Delete:
                    e.Visible = SessionHandler.LoggedUser.IsUserAuthorised(Enums.Rights.GeneralManagement_CreditCardType_Delete);
                    break;
            }
        }
    }
}
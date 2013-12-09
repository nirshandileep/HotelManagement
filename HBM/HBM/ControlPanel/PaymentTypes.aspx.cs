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
    public partial class PaymentTypes : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.PaymentType paymentTypes = new GenMan.PaymentType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                gvPaymentTypes.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadPaymentTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["PaymentTypeId"] };
                Session[Constants.SESSION_PAYMENTTYPES] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadPaymentTypes()
        {
            try
            {
                paymentTypes.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = paymentTypes.SelectAllDataset();
                gvPaymentTypes.DataSource = dsData.Tables[0];
                gvPaymentTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvPaymentTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_PAYMENTTYPES] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["PaymentTypeId"] = rd.Next();
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

            paymentTypes.PaymentTypeName = e.NewValues["PaymentTypeName"].ToString();


            if (!paymentTypes.IsDuplicateTypeName())
            {
                if (paymentTypes.Save(dsData))
                {
                    this.LoadPaymentTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }


        }

        protected void gvPaymentTypes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_PAYMENTTYPES] as DataSet;
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

            paymentTypes.PaymentTypeId = Convert.ToInt32(e.Keys["PaymentTypeId"].ToString());
            paymentTypes.PaymentTypeName = e.NewValues["PaymentTypeName"].ToString();
            
            if (!paymentTypes.IsDuplicateTypeName())
            {
                if (paymentTypes.Save(dsData))
                {
                    this.LoadPaymentTypes();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }
        }

        protected void gvPaymentTypes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvPaymentTypes.FindVisibleIndexByKeyValue(e.Keys[gvPaymentTypes.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_PAYMENTTYPES] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvPaymentTypes.KeyFieldName])));


            if (paymentTypes.Save(dsData))
            {
                this.LoadPaymentTypes();
            }



        }
    }
}
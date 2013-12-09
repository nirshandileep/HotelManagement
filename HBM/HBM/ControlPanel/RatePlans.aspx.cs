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
    public partial class RatePlan : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        GenMan.RatePlans ratePlans = new GenMan.RatePlans();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {                             
                gvRatePlans.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadRatePlans();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["RatePlansId"] };
                Session[Constants.SESSION_RATEPLANS] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadRatePlans()
        {
            try
            {
                ratePlans.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = ratePlans.SelectAllDataset();
                gvRatePlans.DataSource = dsData.Tables[0];
                gvRatePlans.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvRatePlans_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_RATEPLANS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["RatePlansId"] = rd.Next();
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

            ratePlans.RatePlanName = e.NewValues["RatePlanName"].ToString();

              if (!ratePlans.IsDuplicateTypeName())
              {

                  if (ratePlans.Save(dsData))
                  {
                      this.LoadRatePlans();
                  }
              }
              else
              {
                  throw new System.Exception(Messages.Duplicate_record);
              }

        }

        protected void gvRatePlans_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_RATEPLANS] as DataSet;
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

            ratePlans.RatePlansId = Convert.ToInt32(e.Keys["RatePlansId"].ToString());
            ratePlans.RatePlanName = e.NewValues["RatePlanName"].ToString();

            if (!ratePlans.IsDuplicateTypeName())
            {
                if (ratePlans.Save(dsData))
                {
                    this.LoadRatePlans();
                }
            }
            else
            {
                throw new System.Exception(Messages.Duplicate_record);
            }


        }

        protected void gvRatePlans_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvRatePlans.FindVisibleIndexByKeyValue(e.Keys[gvRatePlans.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_RATEPLANS] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvRatePlans.KeyFieldName])));


            if (ratePlans.Save(dsData))
            {
                this.LoadRatePlans();
            }



        }
    }
}
﻿using System;
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
    public partial class Source : System.Web.UI.Page
    {

        DataSet dsData = new DataSet();
        GenMan.Source source = new GenMan.Source();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvSource.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            this.LoadSource();
            dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["SourceId"] };
            Session[Constants.SESSION_SOURCE] = dsData;
        }

        protected void LoadSource()
        {
            try
            {
                source.CompanyId = SessionHandler.CurrentCompanyId;
                dsData = source.SelectAllDataset();
                gvSource.DataSource = dsData.Tables[0];
                gvSource.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvSource_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvSource.FindVisibleIndexByKeyValue(e.Keys[gvSource.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_SOURCE] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvSource.KeyFieldName])));


            if (source.Save(dsData))
            {
                this.LoadSource();
            }
        }

        protected void gvSource_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_SOURCE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["SourceId"] = rd.Next();
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

            if (source.Save(dsData))
            {
                this.LoadSource();
            }

        }

        protected void gvSource_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_SOURCE] as DataSet;
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

            if (source.Save(dsData))
            {
                this.LoadSource();
            }
        }
    }
}
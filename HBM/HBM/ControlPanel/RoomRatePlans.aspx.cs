﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Common;
using DevExpress.Web.ASPxEditors;
using System.Data;
using HBM.GeneralManagement;
using DevExpress.Web.ASPxGridView;
using HBM.SessionManager;
using System.Collections;

namespace HBM.ControlPanel
{
    public partial class RoomRatePlans : System.Web.UI.Page
    {

        DataSet dsData = new DataSet();
        DataSet dsRatePlansForRoom = new DataSet();
        GeneralManagement.RoomRatePlan roomRatePlan = new GeneralManagement.RoomRatePlan();

        protected void Page_Init(object sender, EventArgs e)
        {
            gvRatePlan.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            cmbRooms.DataSource = new GeneralManagement.RoomDAO().SelectAll(new GeneralManagement.Room() { CompanyId = Master.CurrentCompany.CompanyId });
            cmbRooms.ValueField = "RoomId";
            cmbRooms.DataBind();

        }

        protected void cmbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get rate plan by room id
            int roomId = LoadRoomRatePlan();

            dsRatePlansForRoom = new RatePlansDAO().SelectAll(new RatePlans() { CompanyId = Master.CurrentCompany.CompanyId });
            dsRatePlansForRoom.Tables[0].TableName = "RoomRatePlan";
            ((GridViewDataComboBoxColumn)gvRatePlan.Columns["RatePlansId"]).PropertiesComboBox.DataSource = dsRatePlansForRoom.Tables[0];
        }

        private int LoadRoomRatePlan()
        {
            int roomId = 0;
            if (cmbRooms.SelectedIndex > -1)
            {
                roomId = (int)cmbRooms.Value;
            }

            gvRatePlan.DataSource = new GeneralManagement.RoomRatePlanDAO().SelectByRoomId(roomId);
            gvRatePlan.DataBind();

            return roomId;
        }

        protected void gvRatePlan_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "RatePlansId") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvRatePlan_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvRatePlan.FindVisibleIndexByKeyValue(e.Keys[gvRatePlan.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_ROOMRATEPLAN] as DataSet;
            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvRatePlan.KeyFieldName])));

            if (new RoomRatePlanDAO().InsertUpdateDelete(dsData))
            {
                this.LoadRoomRatePlan();
            }
        }

        protected void gvRatePlan_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_ROOMRATEPLAN] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["RoomRatePlanId"] = rd.Next();
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

            if (new RoomRatePlanDAO().InsertUpdateDelete(dsData))
            {
                this.LoadRoomRatePlan();
            }
        }

        protected void gvRatePlan_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_ROOMRATEPLAN] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["UpdatedUser"] = SessionHandler.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            if (new RoomRatePlanDAO().InsertUpdateDelete(dsData))
            {
                this.LoadRoomRatePlan();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Common;
using System.Data;
using DevExpress.Web.ASPxGridView;
using System.Collections;
using HBM.GeneralManagement;
using DevExpress.Web.ASPxEditors;

namespace HBM
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        DataSet dsDepartures = new DataSet();

        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadCleanedByUsers();
        }

        private void LoadCleanedByUsers()
        {
            try
            {
                DataSet dsCleaners = new UserManagement.Users() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
                dsCleaners.Tables[0].Columns["UsersId"].ColumnName = "CleanedBy";
                ((GridViewDataComboBoxColumn)gvDirtyRooms.Columns["CleanedBy"]).PropertiesComboBox.TextField = "UserName";
                ((GridViewDataComboBoxColumn)gvDirtyRooms.Columns["CleanedBy"]).PropertiesComboBox.ValueField = "CleanedBy";
                ((GridViewDataComboBoxColumn)gvDirtyRooms.Columns["CleanedBy"]).PropertiesComboBox.DataSource = dsCleaners;

            }
            catch (System.Exception)
            {


            }
        }

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

            MapSchedulerFields();

            if (!IsPostBack)
            {
                LoadDirtyRooms();
            }

            if (Session[Constants.SESSION_ARRIVALS] != null)
            {
                gvArrivals.DataSource = (DataSet)Session[Constants.SESSION_ARRIVALS];
                gvArrivals.DataBind();    
            }

            if (Session[Constants.SESSION_DEPARTURES] != null)
            {
                gvDepartures.DataSource = (DataSet)Session[Constants.SESSION_DEPARTURES];
                gvDepartures.DataBind();
            }

            if (Session[Constants.SESSION_DIRTYROOMS] != null)
            {
                gvDirtyRooms.DataSource = (DataSet)Session[Constants.SESSION_DIRTYROOMS];
                gvDirtyRooms.DataBind();
            }
        }

        #endregion

        #region Methods

        private void MapSchedulerFields()
        {
            DataSet dsTimeLineData = GetTimelineData();

            dsTimeLineData.Tables[0].PrimaryKey = new DataColumn[] { dsTimeLineData.Tables[0].Columns["ReservationRoomId"] };
            dsTimeLineData.Tables[1].PrimaryKey = new DataColumn[] { dsTimeLineData.Tables[1].Columns["RoomId"] };

            DataRelation tableRelation = new DataRelation("ReservationRoomRel", dsTimeLineData.Tables[1].Columns["RoomId"], dsTimeLineData.Tables[0].Columns["RoomId"]);
            dsTimeLineData.Relations.Add(tableRelation);

            schReservationDashboad.ResourceDataSource = dsTimeLineData.Tables[1];
            schReservationDashboad.Storage.Resources.Mappings.ResourceId = "RoomId";
            schReservationDashboad.Storage.Resources.Mappings.Caption = "RoomDescription";
            //schReservationDashboad.Storage.Resources.Mappings.Color = "Red";

            schReservationDashboad.Views.WorkWeekView.Enabled = false;
            schReservationDashboad.AppointmentDataSource = dsTimeLineData.Tables[0];
            schReservationDashboad.Storage.Appointments.Mappings.AppointmentId = "ReservationRoomId";
            schReservationDashboad.Storage.Appointments.Mappings.Start = "CheckInDate";
            schReservationDashboad.Storage.Appointments.Mappings.End = "CheckOutDate";
            schReservationDashboad.Storage.Appointments.Mappings.Label = "RoomNumber";
            schReservationDashboad.Storage.Appointments.Mappings.Subject = "CustomerName";
            schReservationDashboad.Storage.Appointments.Mappings.ResourceId = "RoomId";
            schReservationDashboad.DataBind();
        }

        private void LoadDirtyRooms()
        {
            DataSet dsDirtyRooms = new RoomDAO().SelectAllDirtyRooms(Master.CurrentCompany.CompanyId);
            dsDirtyRooms.Tables[0].PrimaryKey = new DataColumn[] { dsDirtyRooms.Tables[0].Columns["RoomId"] };
            Session[Constants.SESSION_DIRTYROOMS] = dsDirtyRooms;
            if (dsDirtyRooms.Tables[0].Columns.Contains("CleanedDate") == false)
            {
                dsDirtyRooms.Tables[0].Columns.Add("CleanedDate", Type.GetType("System.DateTime"));
            }
            gvDirtyRooms.DataSource = (DataSet)Session[Constants.SESSION_DIRTYROOMS];
            gvDirtyRooms.DataBind();
        }

        private void LoadArrivals(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                dtpArrivalFromDate.ErrorText = "From date cannot be greater than To date";
                return;
            }

            //Arrivals
            dsData = new ReservationManagement.ReservationRoomDAO().DashboardSelectArrivalsList(Master.CurrentCompany.CompanyId, fromDate, toDate);
            dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["ReservationRoomId"] };
            Session[Constants.SESSION_ARRIVALS] = dsData;

            gvArrivals.DataSource = (DataSet)Session[Constants.SESSION_ARRIVALS];
            gvArrivals.DataBind();
        }

        private void LoadDepartures(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                dtpArrivalFromDate.ErrorText = "From date cannot be greater than To date";
                return;
            }

            //Departures
            dsDepartures = new ReservationManagement.ReservationRoomDAO().DashboardSelectDeparturesList(Master.CurrentCompany.CompanyId, fromDate, toDate);
            dsDepartures.Tables[0].PrimaryKey = new DataColumn[] { dsDepartures.Tables[0].Columns["ReservationRoomId"] };
            Session[Constants.SESSION_DEPARTURES] = dsDepartures;

            gvDepartures.DataSource = (DataSet)Session[Constants.SESSION_DEPARTURES];
            gvDepartures.DataBind();
        }

        protected DataSet GetTimelineData()
        {

            DataSet dsReservations = new ReservationManagement.ReservationRoomDAO().DashboardSelectBookingsByDateRange(Master.CurrentCompany.CompanyId,
                DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(3));

            return dsReservations;

        }

        #endregion

        #region Events

        protected void gvArrivals_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            dsData = Session[Constants.SESSION_ARRIVALS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["UpdatedUser"] = Master.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            if (new ReservationManagement.ReservationRoom().UpdateDashboardArrivalsDepartures(dsData))
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                if (dtpArrivalFromDate.Value != null && dtpArrivalToDate.Value != null)
                {
                    LoadArrivals(dtpArrivalFromDate.Date, dtpArrivalToDate.Date);
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Unsuccess + "')", true);
            }
        }

        protected void gvDepartures_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_DEPARTURES] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["UpdatedUser"] = Master.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            if (new ReservationManagement.ReservationRoom().UpdateDashboardArrivalsDepartures(dsData))
            {

                if (row["IsDirty"] != null && Boolean.Parse(row["IsDirty"].ToString()) != false)
                {
                    new RoomDAO().UpdateRoomAsDirty(new Room() { RoomId = (int)row["RoomId"], UpdatedBy = Master.LoggedUser.UsersId });
                }

                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                if (dtpDeparturesFrom.Value != null && dtpDeparturesTo.Value != null)
                {
                    LoadDepartures(dtpDeparturesFrom.Date, dtpDeparturesTo.Date);
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Unsuccess + "')", true);
            }
        }

        protected void gvDirtyRooms_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "CleanedBy") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvDirtyRooms_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataSet dsDirtyRooms = Session[Constants.SESSION_DIRTYROOMS] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsDirtyRooms.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["UpdatedUser"] = Master.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;

            if (new GeneralManagement.RoomDAO().DashboardUpdateDirtyRooms(dsDirtyRooms))
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                LoadDirtyRooms();
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Unsuccess + "')", true);
            }
        }

        protected void btnSearchArrivals_Click(object sender, EventArgs e)
        {
            this.LoadArrivals(dtpArrivalFromDate.Date, dtpArrivalToDate.Date);
        }

        protected void btnSearchDepartures_Click(object sender, EventArgs e)
        {
            this.LoadDepartures(dtpDeparturesFrom.Date, dtpDeparturesTo.Date);
        }

        protected void gvDirtyRooms_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void gvDirtyRooms_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            this.LoadDirtyRooms();
        }

        protected void gvArrivals_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (Session[Constants.SESSION_ARRIVALS] != null)
            {
                gvArrivals.DataSource = (DataSet)Session[Constants.SESSION_ARRIVALS];
                gvArrivals.DataBind();
            }
        }

        protected void gvDepartures_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (Session[Constants.SESSION_DEPARTURES] != null)
            {
                gvDepartures.DataSource = (DataSet)Session[Constants.SESSION_DEPARTURES];
                gvDepartures.DataBind();
            }
        }

        #endregion
    }
}
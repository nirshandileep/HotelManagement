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


        protected void Page_Load(object sender, EventArgs e)
        {

            //Scheduler 
            schReservationDashboad.Views.WorkWeekView.Enabled = false;
            schReservationDashboad.AppointmentDataSource = this.CreatDataSource();
            schReservationDashboad.Storage.Appointments.Mappings.AppointmentId = "Id";
            schReservationDashboad.Storage.Appointments.Mappings.Start = "StartDate";
            schReservationDashboad.Storage.Appointments.Mappings.End = "EndDate";
            schReservationDashboad.Storage.Appointments.Mappings.Label = "Room";
            schReservationDashboad.Storage.Appointments.Mappings.Subject = "Name";
            schReservationDashboad.DataBind();

            if (!IsPostBack)
            {
                //pcPageControl.ActiveTabIndex = 0;

                //LoadArrivals(DateTime.Now, DateTime.Now);
                //LoadDepartures(DateTime.Now, DateTime.Now);
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

        private void LoadDirtyRooms()
        {
            DataSet dsDirtyRooms = new RoomDAO().SelectAllDirtyRooms(Master.CurrentCompany.CompanyId);
            dsDirtyRooms.Tables[0].PrimaryKey = new DataColumn[] { dsDirtyRooms.Tables[0].Columns["RoomId"] };
            Session[Constants.SESSION_DIRTYROOMS] = dsDirtyRooms;

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

        protected DataTable CreatDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(System.Int32));
            dt.Columns.Add("StartDate",typeof(System.DateTime));
            dt.Columns.Add("EndDate", typeof(System.DateTime));
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("Room",typeof(System.String));

            dt.Rows.Add(1,Convert.ToDateTime("10-11-2013"), Convert.ToDateTime("12-11-2013"), "James", "Sapphire");
            dt.Rows.Add(2,Convert.ToDateTime("20-11-2013"), Convert.ToDateTime("25-11-2013"), "Craig", "Garnet");
            dt.Rows.Add(3,Convert.ToDateTime("22-11-2013"), Convert.ToDateTime("30-11-2013"), "Sandra", "Ruby");
            dt.Rows.Add(1, Convert.ToDateTime("10-11-2013"), Convert.ToDateTime("12-11-2013"), "David", "Blue Sapphire");


            return dt;


        }

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


       
    }
}
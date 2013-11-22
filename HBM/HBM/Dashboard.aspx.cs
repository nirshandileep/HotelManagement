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

namespace HBM
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();
        DataSet dsDepartures = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

            pcPageControl.ActiveTabIndex = 0;

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
                LoadArrivals();
                LoadDepartures();

                Session[Constants.SESSION_DIRTYROOMS] = new DataSet();//Todo
                gvDirtyRooms.DataSource = new DataSet();
                gvDirtyRooms.DataBind();
            }

            if (Session[Constants.SESSION_ARRIVALS] != null)
            {
                gvArrivals.DataSource = (DataSet)Session[Constants.SESSION_ARRIVALS];
                gvArrivals.DataBind();    
            }

            if (Session[Constants.SESSION_DIRTYROOMS] != null)
            {
                gvDepartures.DataSource = (DataSet)Session[Constants.SESSION_DIRTYROOMS];
                gvDepartures.DataBind();
            }
        }

        private void LoadDepartures()
        {
            //Departures
            dsDepartures = new ReservationManagement.ReservationRoomDAO().DashboardSelectDeparturesList(Master.CurrentCompany.CompanyId);
            dsDepartures.Tables[0].PrimaryKey = new DataColumn[] { dsDepartures.Tables[0].Columns["ReservationRoomId"] };
            Session[Constants.SESSION_DEPARTURES] = dsDepartures;
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

            if (new ReservationManagement.ReservationRoom().UpdateDashboardArrivals(dsData))
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);

                LoadArrivals();
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Unsuccess + "')", true);
            }
        }

        private void LoadArrivals()
        {
            //Arrivals
            dsData = new ReservationManagement.ReservationRoomDAO().DashboardSelectArrivalsList(Master.CurrentCompany.CompanyId);
            dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["ReservationRoomId"] };
            Session[Constants.SESSION_ARRIVALS] = dsData;
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.Common;
using System.Data;

namespace HBM
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            pcPageControl.ActiveTabIndex = 0;

            schReservationDashboad.Views.WorkWeekView.Enabled = false;

            schReservationDashboad.AppointmentDataSource = this.CreatDataSource();
            schReservationDashboad.Storage.Appointments.Mappings.AppointmentId = "Id";
            schReservationDashboad.Storage.Appointments.Mappings.Start = "StartDate";
            schReservationDashboad.Storage.Appointments.Mappings.End = "EndDate";
            schReservationDashboad.Storage.Appointments.Mappings.Label = "Room";
            schReservationDashboad.Storage.Appointments.Mappings.Subject = "Name";

           
            schReservationDashboad.DataBind();
            

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

       
    }
}
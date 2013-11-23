using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResMan = HBM.ReservationManagement;
using HBM.Utility;
using HBM.Common;

namespace HBM.Reservation
{
    public partial class SearchReservation : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvReservation.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ResMan.Reservation resobj= new ResMan.Reservation();
                resobj.CompanyId = Master.CurrentCompany.CompanyId;
                gvReservation.DataSource = resobj.SelectAllDataset();
                gvReservation.DataBind();
            }
            catch (System.Exception)
            {

            }
        }
    }
}
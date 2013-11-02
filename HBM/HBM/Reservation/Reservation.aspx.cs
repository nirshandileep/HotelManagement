using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Res = HBM.ReservationManagement;
using GenMan = HBM.GeneralManagement;
using HBM.CustomerManagement;
using HBM.GeneralManagement;

namespace HBM.Reservation
{
    public partial class Reservation : System.Web.UI.Page
    {

        public Res.Reservation ReservationObj
        {
            get
            {
                Res.Reservation reservation;
                if (Session["ReservationObj"] == null)
                {
                    reservation = new Res.Reservation();
                    reservation.ReservationId = Int32.Parse(hdnReservationId.Value.Trim() == String.Empty ? "0" : hdnReservationId.Value.Trim());
                    reservation.CompanyId = Master.CompanyId;
                    reservation = reservation.Select();
                    reservation = reservation != null ? reservation : new Res.Reservation();
                    Session["ReservationObj"] = reservation;
                }
                else
                {
                    reservation = (Res.Reservation)Session["ReservationObj"];
                }
                return reservation;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.ClearSessions();
                CheckFromURL();
                IsEditReservation();
                LoadInitialData();
                SetData();
            }
        }

        /// <summary>
        /// Fill all form data
        /// </summary>
        private void SetData()
        {
            txtResCode.Text = ReservationObj.ReservationCode;
            cmbResStatus.Value = ReservationObj.StatusId;
            cmbSource.Value = ReservationObj.SourceId;
            teBookingTime.Value = ReservationObj.ReservationId == 0 ? DateTime.Now : ReservationObj.BookingDate;
            txtUser.Text = ReservationObj.ReservationId == 0 ? Master.LoggedUser.UserName : new UserManagement.Users() { UsersId = ReservationObj.CreatedUser }.Select().UserName;
            cmbGuarantee.Value = ReservationObj.GuaranteeId;
            
            dtpCheckIn.Value = ReservationObj.ReservationId == 0 ? "" : ReservationObj.ReservationRoom.CheckInDate.ToString();
            dtpCheckOut.Value = ReservationObj.ReservationId == 0 ? "" : ReservationObj.ReservationRoom.CheckOutDate.ToString();
            
            seNumberOfAdults.Value = ReservationObj.ReservationRoom.NumberOfAdults;
            seNumberOfChildren.Value = ReservationObj.ReservationRoom.NumberOfChildren;
            seNumberOfInfants.Value = ReservationObj.ReservationRoom.NumberOfInfant;

            cmbRooms.Value = ReservationObj.ReservationRoom.RoomRatePlan.RoomId;
            cmbRatePlan.Value = ReservationObj.ReservationRoom.RoomRatePlanId;

            //txtGuestName.Text = ReservationObj.



        }

        /// <summary>
        /// Load all lookup data with this method
        /// </summary>
        private void LoadInitialData()
        {
            cmbResStatus.DataSource = new Status().SelectAllList();
            cmbResStatus.TextField = "StatusName";
            cmbResStatus.ValueField = "StatusId";
            cmbResStatus.DataBind();

            cmbGuarantee.DataSource = new GenMan.Gaurantee(){ CompanyId = Master.CompanyId }.SelectAllList();
            cmbGuarantee.TextField = "GuaranteeName";
            cmbGuarantee.ValueField = "GuaranteeId";
            cmbGuarantee.DataBind();

            cmbCountry.DataSource = new Country() { CompanyId = Master.CompanyId }.SelectAllList();
            cmbCountry.TextField = "CountryName";
            cmbCountry.ValueField = "CountryId";
            cmbCountry.DataBind();

            cmbTax.DataSource = new GenMan.TaxType() { CompanyId = Master.CompanyId }.SelectAllList();
            cmbTax.TextField = "TaxTypeName";
            cmbTax.ValueField = "TaxTypeId";
            cmbTax.DataBind();
        }

        /// <summary>
        /// Check if GRNId is passed to edit
        /// </summary>
        private void IsEditReservation()
        {
            try
            {
                if (Request.QueryString["ReservationId"] != null && Request.QueryString["ReservationId"].Trim() != String.Empty)
                {
                    hdnReservationId.Value = Request.QueryString["ReservationId"].Trim();
                    Page.Title = "View Reservation";
                }
            }
            catch (System.Exception)
            {

            }
        }

        /// <summary>
        /// Fill FromURL to go back
        /// </summary>
        private void CheckFromURL()
        {
            try
            {
                if (Request.QueryString["FromURL"] != null && Request.QueryString["FromURL"].Trim() != String.Empty)
                {
                    hdnFromURL.Value = Request.QueryString["FromURL"].Trim();
                }
            }
            catch (System.Exception)
            {

            }

        }
    }
}
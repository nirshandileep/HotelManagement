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

        public Res.Reservation ResObj
        {
            get
            {
                Res.Reservation reservation;
                if (Session["ReservationObj"] == null)
                {
                    reservation = new Res.Reservation();
                    reservation.ReservationId = Int32.Parse(hdnReservationId.Value.Trim() == String.Empty ? "0" : hdnReservationId.Value.Trim());
                    reservation.CompanyId = Master.CurrentCompany.CompanyId;
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
                IsEditReservation();
                LoadInitialData();
                SetData();
            }
            if (IsCallback)
            {
                LoadInitialData();
            }
        }

        /// <summary>
        /// Fill all form data
        /// </summary>
        private void SetData()
        {
            txtResCode.Text = ResObj.ReservationCode;
            hdnReservationUserId.Add("CreatedUser", ResObj.ReservationId > 0 ? ResObj.CreatedUser : Master.LoggedUser.UsersId);

            if (ResObj.ReservationId > 0)
            {
                cmbResStatus.Value = ResObj.StatusId;
                cmbSource.Value = ResObj.SourceId;
                cmbGuarantee.Value = ResObj.GuaranteeId;
            }

            dtpBookingTime.Value = ResObj.ReservationId == 0 ? DateTime.Now : ResObj.BookingDate;
            txtUser.Text = ResObj.ReservationId == 0 ? Master.LoggedUser.UserName : new UserManagement.Users() { UsersId = ResObj.CreatedUser }.Select().UserName;
            dtpCheckIn.Value = ResObj.ReservationId == 0 ? DateTime.Now.AddDays(Common.Constants.CHECKIN_ADD_DAYS) : ResObj.ReservationRoom.CheckInDate;
            dtpCheckOut.Value = ResObj.ReservationId == 0 ? DateTime.Now.AddDays(Common.Constants.CHECKOUT_ADD_DAYS) : ResObj.ReservationRoom.CheckOutDate;


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

            cmbGuarantee.DataSource = new GenMan.Gaurantee() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbGuarantee.TextField = "GuaranteeName";
            cmbGuarantee.ValueField = "GuaranteeId";
            cmbGuarantee.DataBind();

            cmbTax.DataSource = new GenMan.TaxType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbTax.TextField = "TaxTypeName";
            cmbTax.ValueField = "TaxTypeId";
            cmbTax.DataBind();

            cmbCustomerName.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbCustomerName.ValueField = "CustomerId";
            cmbCustomerName.DataBind();
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
        /// Reservation Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResObj.ReservationCode = txtResCode.Text.Trim();
                ResObj.StatusId = (int)cmbResStatus.Value == -1 ? 1 : Int32.Parse(cmbResStatus.Value.ToString());
                ResObj.SourceId = (int?)cmbSource.Value;
                ResObj.BookingDate = (DateTime)dtpBookingTime.Value;
                ResObj.CreatedUser = (int)hdnReservationUserId.Get("CreatedUser");
                ResObj.UpdatedUser = Master.LoggedUser.UsersId;
                ResObj.GuaranteeId = (int)cmbGuarantee.Value;

                //Customer Section
                ResObj.CustomerId = (int)cmbCustomerName.Value;
                ResObj.CheckInDate = (DateTime)dtpCheckIn.Value;
                ResObj.CheckOutDate = (DateTime)dtpCheckOut.Value;

                ResObj.TaxTypeId = (int)cmbTax.Value;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Save room details to reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
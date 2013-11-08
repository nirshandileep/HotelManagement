using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Res = HBM.ReservationManagement;
using GenMan = HBM.GeneralManagement;
using HBM.CustomerManagement;
using System.Data;
using DevExpress.Web.ASPxGridView;
using HBM.Common;
using HBM.SessionManager;
using System.Collections;
using DevExpress.Web.ASPxEditors;
using HBM.GeneralManagement;

namespace HBM.Reservation
{
    public partial class Reservation : System.Web.UI.Page
    {
        DataSet dsData = new DataSet();

        private DataSet dsTempGuests;

        public DataSet DsTempGuests
        {
            get 
            {
                if (Session["DsTempGuests"] == null)
                {
                    dsTempGuests = new DataSet();
                    Session["DsTempGuests"] = dsTempGuests;
                }
                else
                {
                    dsTempGuests = (DataSet)Session["DsTempGuests"];
                }
                return dsTempGuests;
            }
            set
            {
                Session["DsTempGuests"] = value;
            }
        }

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

            //Some controls do not work wothout this placed here
            BindData();

            if (!IsPostBack)
            {
                LoadInitialData();
                SetLimits();
                IsEditReservation();
                SetData();
            }
            if (IsCallback)
            {
                
            }
        }

        private void SetLimits()
        {
            try
            {
                seAdultNumber.MinValue = 0;
                seChildNumber.MinValue = 0;
                seInfantNumber.MinValue = 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Page Init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCustomers.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvPaymentInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvRoomDetails.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvServiceInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

            LoadLookupDataToGridColumns();
        }

        private void LoadLookupDataToGridColumns()
        {
            try
            {
                ///
                /// Customers Grid (Guests List)
                ///
                ((GridViewDataComboBoxColumn)gvCustomers.Columns["CustomerId"]).PropertiesComboBox.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
                ((GridViewDataComboBoxColumn)gvCustomers.Columns["CustomerId"]).PropertiesComboBox.ValueField = "CustomerId";
                ((GridViewDataComboBoxColumn)gvCustomers.Columns["CustomerId"]).PropertiesComboBox.TextField = "CustomerName";

                ///
                /// Payment Information Grid
                ///
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["PaymentTypeId"]).PropertiesComboBox.DataSource = new GenMan.PaymentType().SelectAllList();
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["PaymentTypeId"]).PropertiesComboBox.ValueField = "PaymentTypeId";
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["PaymentTypeId"]).PropertiesComboBox.TextField = "PaymentTypeName";
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CreditCardTypeId"]).PropertiesComboBox.DataSource = new GenMan.CreditCardType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CreditCardTypeId"]).PropertiesComboBox.DataSource = "CreditCardTypeId";
                ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CreditCardTypeId"]).PropertiesComboBox.DataSource = "Name";

                ///
                /// Customer Combobox (Reservation Creater)
                ///
                cmbCustomerName.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
                cmbCustomerName.ValueField = "CustomerId";

                ///
                /// Additional Services
                ///
                ((GridViewDataComboBoxColumn)gvServiceInformation.Columns["AdditionalServiceId"]).PropertiesComboBox.DataSource = new GenMan.AdditionalService() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
                ((GridViewDataComboBoxColumn)gvServiceInformation.Columns["AdditionalServiceId"]).PropertiesComboBox.ValueField = "AdditionalServiceId";
                ((GridViewDataComboBoxColumn)gvServiceInformation.Columns["AdditionalServiceId"]).PropertiesComboBox.ValueField = "ServiceName";
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Fill the controls that gets emptied after every callback
        /// </summary>
        private void BindData()
        {

            cmbCustomerName.DataBind();
            gvCustomers.DataBind();
            gvPaymentInformation.DataBind();
            gvServiceInformation.DataBind();

        }

        /// <summary>
        /// Fill all form data
        /// </summary>
        private void SetData()
        {
            txtResCode.Text = ResObj.ReservationCode;

            if (Master.LoggedUser!=null)
            {
                hdnReservationUserId.Add("CreatedUser", ResObj.ReservationId > 0 ? ResObj.CreatedUser : Master.LoggedUser.UsersId);    
            }

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
            cmbResStatus.DataSource = new GenMan.Status().SelectAllList();
            cmbResStatus.TextField = "StatusName";
            cmbResStatus.ValueField = "StatusId";
            cmbResStatus.DataBind();

            cmbGuarantee.DataSource = new GenMan.Gaurantee() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
            cmbGuarantee.TextField = "GuaranteeName";
            cmbGuarantee.ValueField = "GuaranteeId";
            cmbGuarantee.DataBind();

            cmbTax.DataSource = new GenMan.TaxType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllList();
            cmbTax.TextField = "TaxTypeName";
            cmbTax.ValueField = "TaxTypeId";
            cmbTax.DataBind();

            cmbSource.DataSource = new GenMan.Source() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
            cmbSource.TextField = "SourceName";
            cmbSource.ValueField = "SourceId";
            cmbSource.DataBind();
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

        protected void gvCustomers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                int i = gvCustomers.FindVisibleIndexByKeyValue(e.Keys[gvCustomers.KeyFieldName]);
                e.Cancel = true;
                dsData = Session[Constants.SESSION_RATEPLANS] as DataSet;
                dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvCustomers.KeyFieldName])));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        protected void gvCustomers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {

                dsData = DsTempGuests;
                ASPxGridView gridView = sender as ASPxGridView;
                DataRow row = dsData.Tables[0].NewRow();
                Random rd = new Random();
                e.NewValues["ReservationGuestId"] = rd.Next();
                e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
                e.NewValues["CompanyId"] = Master.CurrentCompany.CompanyId;
                e.NewValues["CreatedUser"] = Master.LoggedUser.UsersId;

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
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        protected void gvCustomers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = DsTempGuests;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Modify;
            e.NewValues["UpdatedUser"] = Master.LoggedUser.UsersId;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;
        }

        protected void gvCustomers_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            try
            {
                if (e.Column.FieldName != "CustomerId") return;

                ASPxComboBox combo = e.Editor as ASPxComboBox;
                combo.DataBindItems();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
using System;
using ResMan = HBM.ReservationManagement;
using GenMan = HBM.GeneralManagement;
using HBM.CustomerManagement;
using System.Data;
using DevExpress.Web.ASPxGridView;
using HBM.Common;
using HBM.SessionManager;
using System.Collections;
using DevExpress.Web.ASPxEditors;
using GenRes = HBM.ReservationManagement;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using HBM.Utility;
using DevExpress.Web.ASPxMenu;
using HBM.GeneralManagement;

namespace HBM.Reservation
{
    public partial class Reservation : System.Web.UI.Page
    {
        #region Variables

        DataSet dsRoomInfomation = new DataSet();
        DataSet dsAdditionalService = new DataSet();
        DataSet dsPaymentInformation = new DataSet();

        GenMan.AdditionalService additionalService = new GenMan.AdditionalService();
        GenRes.ReservationRoom reservationRoom = new GenRes.ReservationRoom();
        GenRes.ReservationAdditionalService reservationAdditionalService = new GenRes.ReservationAdditionalService();
        GenRes.ReservationPayments reservationPayments = new GenRes.ReservationPayments();

        Int64 newReservationId = 0;

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {

            gvRoomInfo.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvServiceInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvPaymentInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

            gvRoomInfo.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvPaymentInformation.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvServiceInformation.SettingsPager.PageSize = Constants.GRID_PAGESIZE;

            this.LoadInitialData();

            if (!IsPostBack)
            {
                this.LoadRoomInformation(newReservationId);
                this.LoadAddiotnalService(newReservationId);
                this.LoadPaymentInformation(newReservationId);

            }

            ((GridViewDataComboBoxColumn)gvServiceInformation.Columns["AdditionalServiceId"]).PropertiesComboBox.DataSource = new GenMan.AdditionalService() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CurrencyId"]).PropertiesComboBox.DataSource = new GenMan.CurrencyTypes().SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["PaymentTypeId"]).PropertiesComboBox.DataSource = (new GenMan.PaymentType() { CompanyId = Master.CurrentCompany.CompanyId }).SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CreditCardTypeId"]).PropertiesComboBox.DataSource = (new GenMan.CreditCardType() { CompanyId = Master.CurrentCompany.CompanyId }).SelectAllDataset().Tables[0];


       

            if (!IsPostBack)
            {
                //// Display reservation
                if (Request.QueryString["ReservationId"] != null)
                {
                    this.hdnReservationId.Value = Cryptography.Decrypt(Request.QueryString["ReservationId"]);
                    Int64 currentReservationId = Convert.ToInt64(this.hdnReservationId.Value);
                    this.DisplayData(currentReservationId);
                    this.Calculate();

                    trReservationSection.Visible = true;
                    trSummarySection.Visible = true;
                    trButtonSection.Visible = true;
                    trStatusSection.Visible = true;

                    cmbCustomer.Enabled = false;
                    cmbSource.Enabled = false;
                    dtCheckingDate.Enabled = false;
                    dtCheckOutDate.Enabled = false;
                    btnCreate.Visible = false;
                }

                if (Request.QueryString["CustomerID"] != null)
                {
                    cmbCustomer.SelectedItem = cmbCustomer.Items.FindByValue(Cryptography.Decrypt(Request.QueryString["CustomerID"]));
                }

            }



        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            

            if (cmbRoom.SelectedItem != null)
            {
                seAdults.MaxValue = Convert.ToInt32(cmbRoom.SelectedItem.GetValue("MaxAdult").ToString());
                seChildren.MaxValue = Convert.ToInt32(cmbRoom.SelectedItem.GetValue("MaxChildren").ToString());
                seInfants.MaxValue = Convert.ToInt32(cmbRoom.SelectedItem.GetValue("MaxInfant").ToString());
            }


            if (cmbRoom.SelectedItem != null && cmbRoom.SelectedItem.Value != null)
            {
                int currentRoomID = Convert.ToInt32(cmbRoom.SelectedItem.Value.ToString());
                hdnRoom.Value = currentRoomID.ToString();
            }

            if (cmbRatePlan.SelectedItem != null && cmbRatePlan.SelectedItem.Value != null)
            {
                hdnRate.Value = cmbRatePlan.SelectedItem.GetValue("Rate").ToString();
            }
            else
            {
                hdnRate.Value = "0";
            }

        }

        #endregion

        #region Methods

        private void LoadInitialData()
        {
            cmbResStatus.DataSource = new GenMan.Status().SelectByModule("Reservation");
            cmbResStatus.TextField = "StatusName";
            cmbResStatus.ValueField = "StatusId";
            cmbResStatus.DataBind();

            cmbCustomer.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbCustomer.TextField = "CustomerName";
            cmbCustomer.ValueField = "CustomerId";
            cmbCustomer.DataBind();

            cmbTax.DataSource = new GenMan.TaxType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbTax.TextField = "TaxTypeName";
            cmbTax.ValueField = "TaxTypeId";
            cmbTax.DataBind();

            cmbSource.DataSource = new GenMan.Source() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbSource.TextField = "SourceName";
            cmbSource.ValueField = "SourceId";
            cmbSource.DataBind();

            this.LoadRoomList();
            //this.LoadRatePlans();

        }

        private bool SaveData(Int64 reservationId)
        {

            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                ResMan.Reservation reservation = new GenRes.Reservation();
                reservation.ReservationId = reservationId;
                reservation.CompanyId = Master.CurrentCompany.CompanyId;

                reservation.CustomerId = Convert.ToInt32(cmbCustomer.Value);
                reservation.SourceId = Convert.ToInt32(cmbSource.Value);
                reservation.CheckInDate = Convert.ToDateTime(dtCheckingDate.Text);
                reservation.CheckOutDate = Convert.ToDateTime(dtCheckOutDate.Text);

                reservation.StatusId = Convert.ToInt32(cmbResStatus.SelectedItem.Value.ToString());

                reservation.RoomTotal = Convert.ToDecimal(txtRoomTotal.Text.Trim());
                reservation.ServiceTotal = Convert.ToDecimal(txtServiceTotal.Text.Trim());
                reservation.NetTotal = Convert.ToDecimal(txtNetTotal.Text.Trim());
                reservation.Discount = Convert.ToDecimal(txtDiscount.Text.Trim());
                reservation.TaxTypeId = Convert.ToInt32(cmbTax.Value);
                reservation.TaxAmount = Convert.ToDecimal(txtTaxTotal.Text.Trim());
                reservation.Total = Convert.ToDecimal(txtTotal.Text.Trim());
                reservation.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());
                reservation.Balance = Convert.ToDecimal(txtBalance.Text.Trim());
                reservation.TaxPercentage = Convert.ToDecimal(hdnTaxPercent.Value == string.Empty ? "0" : hdnTaxPercent.Value);
                reservation.CreatedUser = Master.LoggedUser.UsersId;
                reservation.UpdatedUser = Master.LoggedUser.UsersId;

                if (Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] != null)
                {
                    reservation.ReservationRoomDataSet = (DataSet)Session[Constants.SESSION_RESERVATION_ROOMINFORMATION];
                }
                else
                {
                    reservationRoom.ReservationId = reservationId;
                    reservation.ReservationRoomDataSet = reservationRoom.SelectAllDataSetByReseervationId();
                }


                if (Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] != null)
                {
                    reservation.ReservationAdditionalServiceDataSet = (DataSet)Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE];
                }
                else
                {
                    reservationAdditionalService.ReservationId = reservationId;
                    reservation.ReservationAdditionalServiceDataSet = reservationAdditionalService.SelectAllDataSetByReservationID();
                }

                if (Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] != null)
                {
                    reservation.ReservationPaymentDataSet = (DataSet)Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION];
                }
                else
                {
                    reservationPayments.ReservationId = reservationId;
                    reservation.ReservationPaymentDataSet = reservationPayments.SelectAllDataSetByReservationID();
                }

                reservation.Save(db, transaction);

                if (reservation.StatusId == (int)HBM.Common.Enums.HBMStatus.CheckOut)
                {
                    if (Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] != null)
                    {
                        DataSet roomsToMakeDrity = (DataSet)Session[Constants.SESSION_RESERVATION_ROOMINFORMATION];

                        if (roomsToMakeDrity != null && roomsToMakeDrity.Tables.Count > 0 && roomsToMakeDrity.Tables[0] != null && roomsToMakeDrity.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= roomsToMakeDrity.Tables[0].Rows.Count - 1; i++)
                            {
                                Room dirtyroom = new Room();
                                dirtyroom.RoomId = Convert.ToInt32(roomsToMakeDrity.Tables[0].Rows[i]["RoomId"].ToString());
                                dirtyroom.UpdatedUser = Master.LoggedUser.UsersId;
                                dirtyroom.UpdateRoomAsDirty(db, transaction);
                            }


                        }

                    }

                }



                transaction.Commit();

                this.hdnReservationId.Value = reservation.ReservationId.ToString();

                result = true;
            }
            catch (System.Exception)
            {
                transaction.Rollback();
            }


            return result;
        }

        private bool DisplayData(Int64 reservationId)
        {
            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                ResMan.Reservation reservation = new ResMan.Reservation();
                reservation.ReservationId = reservationId;
                reservation = reservation.Select();

                ltlReservationCode.Text = " - " + reservation.ReservationCode;

                cmbCustomer.SelectedItem = cmbCustomer.Items.FindByValue(reservation.CustomerId.ToString());
                cmbSource.SelectedItem = cmbSource.Items.FindByValue(reservation.SourceId.ToString());

                dtCheckingDate.Value = reservation.CheckInDate;
                dtCheckOutDate.Value = reservation.CheckOutDate;

                cmbResStatus.SelectedItem = cmbResStatus.Items.FindByValue(reservation.StatusId.ToString());

                txtRoomTotal.Text = reservation.RoomTotal.ToString();
                txtServiceTotal.Text = reservation.ServiceTotal.ToString();
                txtNetTotal.Text = reservation.NetTotal.ToString();
                txtDiscount.Text = reservation.Discount.ToString();
                cmbTax.SelectedItem = cmbTax.Items.FindByValue(reservation.TaxTypeId.ToString());
                txtTaxTotal.Text = reservation.TaxAmount.ToString();
                txtTotal.Text = reservation.Total.ToString();
                txtPaidAmount.Text = reservation.PaidAmount.ToString();
                txtBalance.Text = reservation.Balance.ToString();
                hdnTaxPercent.Value = reservation.TaxPercentage.ToString();

                this.LoadRoomInformation(reservationId);
                this.LoadAddiotnalService(reservationId);
                this.LoadPaymentInformation(reservationId);

                transaction.Commit();
                result = true;
            }
            catch (System.Exception)
            {
                transaction.Rollback();
            }


            return result;
        }

        private void ClearRoomInfoSection()
        {
            ddlShareNames.Text = string.Empty;
            cmbRoom.SelectedIndex = -1;
            cmbRatePlan.SelectedIndex = -1;
            seAdults.Text = "0";
            seChildren.Text = "0";
            seInfants.Text = "0";
            hdnRate.Value = string.Empty;
            ddlShareNames.Focus();
        }

        private void ValidateReservation()
        {
            if (Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] != null)
            {
                if (((DataSet)Session[Constants.SESSION_RESERVATION_ROOMINFORMATION]).Tables[0].Rows.Count == 0)
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Reservation_RoomInfoEmpty + "')", true);
                    return;
                }
            }
        }

        private void ClearFormFields()
        {

            if (Request.QueryString["ReservationId"] != null)
            {
                Response.Redirect(Constants.URL_RESERVATION, false);
            }
            else
            {
                cmbCustomer.SelectedIndex = -1;
                cmbSource.SelectedIndex = -1;
                dtCheckingDate.Text = string.Empty;
                dtCheckOutDate.Text = string.Empty;

                this.ClearRoomInfoSection();
                this.LoadRoomInformation(newReservationId);
                this.LoadAddiotnalService(newReservationId);
                this.LoadPaymentInformation(newReservationId);
                this.LoadInitialData();

                txtRoomTotal.Text = "0";
                txtServiceTotal.Text = "0";
                txtNetTotal.Text = "0";
                txtDiscount.Text = "0";
                cmbTax.SelectedIndex = -1;
                txtTaxTotal.Text = "0";
                txtTotal.Text = "0";
                txtPaidAmount.Text = "0";
                txtBalance.Text = "0";

                this.hdnReservationId.Value = string.Empty;

                trReservationSection.Visible = false;
                trSummarySection.Visible = false;
                trButtonSection.Visible = false;
                trStatusSection.Visible = false;

                cmbCustomer.Enabled = true;
                cmbSource.Enabled = true;
                dtCheckingDate.Enabled = true;
                dtCheckOutDate.Enabled = true;
                btnCreate.Visible = true;

            }




        }

        private void Calculate()
        {
            if (gvRoomInfo.GetTotalSummaryValue(gvRoomInfo.TotalSummary["Amount"]) != null)
            {
                txtRoomTotal.Text = gvRoomInfo.GetTotalSummaryValue(gvRoomInfo.TotalSummary["Amount"]).ToString() == string.Empty ? "0" : gvRoomInfo.GetTotalSummaryValue(gvRoomInfo.TotalSummary["Amount"]).ToString();
            }
            else
            {
                txtRoomTotal.Text = "0";
            }


            if (gvServiceInformation.GetTotalSummaryValue(gvServiceInformation.TotalSummary["Amount"]) != null)
            {
                txtServiceTotal.Text = gvServiceInformation.GetTotalSummaryValue(gvServiceInformation.TotalSummary["Amount"]).ToString() == string.Empty ? "0" : gvServiceInformation.GetTotalSummaryValue(gvServiceInformation.TotalSummary["Amount"]).ToString();

            }
            else
            {
                txtServiceTotal.Text = "0";
            }


            txtNetTotal.Text = (Convert.ToDecimal(txtRoomTotal.Text) + Convert.ToDecimal(txtServiceTotal.Text)).ToString();
            txtDiscount.Text = txtDiscount.Text == string.Empty ? "0" : txtDiscount.Text;

            decimal taxPercent;
            taxPercent = Convert.ToDecimal(hdnTaxPercent.Value == string.Empty ? "0" : hdnTaxPercent.Value);
            txtTaxTotal.Text = (Convert.ToDecimal(txtNetTotal.Text) * (taxPercent / 100)).ToString("F2");

            txtTotal.Text = ((Convert.ToDecimal(txtRoomTotal.Text) + Convert.ToDecimal(txtServiceTotal.Text) + Convert.ToDecimal(txtTaxTotal.Text) - Convert.ToDecimal(txtDiscount.Text))).ToString();

            if (gvPaymentInformation.GetTotalSummaryValue(gvPaymentInformation.TotalSummary["Amount"]) != null)
            {
                txtPaidAmount.Text = gvPaymentInformation.GetTotalSummaryValue(gvPaymentInformation.TotalSummary["Amount"]).ToString() == string.Empty ? "0" : gvPaymentInformation.GetTotalSummaryValue(gvPaymentInformation.TotalSummary["Amount"]).ToString();
            }
            else
            {
                txtPaidAmount.Text = "0";
            }

            txtBalance.Text = ((Convert.ToDecimal(txtRoomTotal.Text) + Convert.ToDecimal(txtServiceTotal.Text) + Convert.ToDecimal(txtTaxTotal.Text)) - (Convert.ToDecimal(txtDiscount.Text) + Convert.ToDecimal(txtPaidAmount.Text))).ToString();
        }      

        private void LoadSharesList(int customerID)
        {
            DataSet dsCustomersList = new DataSet();
            Customer customer = new Customer();
            dsCustomersList = customer.SelectByGroup(customerID);

            if (dsCustomersList != null && dsCustomersList.Tables.Count > 0 && dsCustomersList.Tables[0] != null && dsCustomersList.Tables[0].Rows.Count > 0)
            {
                ASPxMenu tmpMenu = (ASPxMenu)ddlShareNames.FindControl("mnuGuest");

                if (tmpMenu != null)
                {
                    for (int i = 0; i <= dsCustomersList.Tables[0].Rows.Count - 1; i++)
                    {
                        tmpMenu.Items[0].Items.Add(new MenuItem(dsCustomersList.Tables[0].Rows[i]["CustomerName"] != null ? dsCustomersList.Tables[0].Rows[i]["CustomerName"].ToString() : string.Empty));
                    }
                }

            }

        }

        private bool ValidateRooms()
        {
            bool result = true;

            if (hdnRate.Value == string.Empty || hdnRate.Value == "0")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Reservation_RoomRateisEmpty + "')", true);
                result = false;
            }


            return result;
        }

        private void LoadCardInformationByCustomer(int customerID)
        {
            DataSet dsCustomers = new DataSet();
            Customer customer = new Customer();
            dsCustomers = customer.SelectById(customerID);

            reservationPayments.ReservationId = 0;
            dsPaymentInformation = reservationPayments.SelectAllDataSetByReservationID();
            dsPaymentInformation.Tables[0].PrimaryKey = new DataColumn[] { dsPaymentInformation.Tables[0].Columns["ReservationPaymentId"] };

            DataRow dataRow = dsPaymentInformation.Tables[0].NewRow();

            Random rd = new Random();
            dataRow["ReservationPaymentId"] = rd.Next();
            dataRow["PaymentDate"] = DateTime.Today;
            dataRow["PaymentTypeId"] = (int)HBM.Common.Enums.PaymentType.CreditCard;
            dataRow["CreditCardTypeId"] = dsCustomers.Tables[0].Rows[0]["CreditCardTypeId"] != null ? dsCustomers.Tables[0].Rows[0]["CreditCardTypeId"] : "1";
            dataRow["CCNo"] = dsCustomers.Tables[0].Rows[0]["CCNo"] != null ? dsCustomers.Tables[0].Rows[0]["CCNo"] : string.Empty;
            dataRow["CCExpirationDate"] = dsCustomers.Tables[0].Rows[0]["CCExpirationDate"] != null ? dsCustomers.Tables[0].Rows[0]["CCExpirationDate"] : string.Empty;
            dataRow["CCNameOnCard"] = dsCustomers.Tables[0].Rows[0]["CCNameOnCard"] != null ? dsCustomers.Tables[0].Rows[0]["CCNameOnCard"] : string.Empty;
            dataRow["Amount"] = "0.00";
            dataRow["CreatedUser"] = SessionHandler.LoggedUser.UsersId;
            dataRow["StatusId"] = (int)HBM.Common.Enums.HBMStatus.Active;

            if (dsCustomers.Tables[0].Rows[0]["CreditCardTypeId"] != null)
            {
                dsPaymentInformation.Tables[0].Rows.Add(dataRow);

                gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
                gvPaymentInformation.DataBind();

                Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = dsPaymentInformation;
            }

        }

        private void LoadRoomList()
        {
            if (cmbCustomer.SelectedItem != null && cmbCustomer.SelectedItem.Value != null)
            {
                Session[Constants.SESSION_RESERVERATION_ROOMLIST] = new GenMan.Room() { }.SelectAvailable(Master.CurrentCompany.CompanyId, Convert.ToDateTime(dtCheckingDate.Value), Convert.ToDateTime(dtCheckOutDate.Value)).Tables[0];

                DataTable dt = (DataTable)Session[Constants.SESSION_RESERVERATION_ROOMLIST];

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbRoom.DataSource = dt;
                    cmbRoom.TextField = "RoomName";
                    cmbRoom.ValueField = "RoomId";
                    cmbRoom.DataBind();

                    trReservationSection.Visible = true;
                    trSummarySection.Visible = true;
                    trButtonSection.Visible = true;
                    trStatusSection.Visible = true;

                    cmbCustomer.Enabled = false;
                    cmbSource.Enabled = false;
                    dtCheckingDate.Enabled = false;
                    dtCheckOutDate.Enabled = false;

                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Reservation_NoAvailableRooms + "')", true);
                }
            }
            else
            {
                if (Session[Constants.SESSION_RESERVERATION_ROOMLIST] != null)
                {
                    cmbRoom.DataSource = (DataTable)Session[Constants.SESSION_RESERVERATION_ROOMLIST];
                    cmbRoom.TextField = "RoomName";
                    cmbRoom.ValueField = "RoomId";
                    cmbRoom.DataBind();
                }

            }

        }

        private void LoadRatePlans()
        {
            if (hdnRoom.Value != string.Empty)
            {
                int currentRoomID = Convert.ToInt32(hdnRoom.Value);
                cmbRatePlan.DataSource = new GenMan.RoomRatePlan() { RoomId = currentRoomID }.SelectByRoomId();
                cmbRatePlan.TextField = "RatePlanName";
                cmbRatePlan.ValueField = "RatePlansId";
                cmbRatePlan.DataBind();               
            }
            
        }

        #endregion

        #region Events

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            if (cmbCustomer.SelectedItem != null && (string.Empty != cmbCustomer.SelectedItem.Value.ToString()))
            {
                this.LoadCardInformationByCustomer(Convert.ToInt32(cmbCustomer.SelectedItem.Value));
                this.LoadSharesList(Convert.ToInt32(cmbCustomer.SelectedItem.Value));

                this.LoadRoomList();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            this.ValidateReservation();

            if (hdnReservationId.Value != string.Empty)
            {
                Int64 currentReservationId;
                currentReservationId = Convert.ToInt64(hdnReservationId.Value);

                if (this.SaveData(currentReservationId))
                {
                    btnCreate.Visible = false;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Update_Success + "')", true);

                }

            }
            else
            {
                if (this.SaveData(newReservationId))
                {
                    btnCreate.Visible = false;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);

                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (this.ValidateRooms())
            {

                if (Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] != null)
                {
                    dsRoomInfomation = (DataSet)Session[Constants.SESSION_RESERVATION_ROOMINFORMATION];

                    DataRow dr = dsRoomInfomation.Tables[0].NewRow();
                    Random rd = new Random();
                    dr["ReservationRoomId"] = rd.Next();
                    dr["ReservationId"] = 0;
                    dr["RoomId"] = Convert.ToInt32(cmbRoom.Value);
                    dr["RoomName"] = cmbRoom.Text;
                    dr["RatePlanId"] = Convert.ToInt32(cmbRatePlan.Value);
                    dr["RatePlanName"] = cmbRatePlan.Text;
                    dr["Sharers"] = ddlShareNames.Text.Trim();
                    dr["CheckInDate"] = dtCheckingDate.Value;
                    dr["CheckOutDate"] = dtCheckOutDate.Value;
                    dr["NumberOfAdults"] = seAdults.Text;
                    dr["NumberOfChildren"] = seChildren.Text;
                    dr["NumberOfInfant"] = seInfants.Text;
                    dr["Rate"] = Convert.ToDecimal(hdnRate.Value == string.Empty ? "0" : hdnRate.Value); ;
                    TimeSpan tspan = Convert.ToDateTime(dtCheckOutDate.Text) - Convert.ToDateTime(dtCheckingDate.Text);
                    double totalDays = 0;
                    totalDays = tspan.TotalDays;

                    if (totalDays == 0)
                    {
                        totalDays = 1;
                    }



                    dr["Days"] = totalDays;
                    dr["Amount"] = totalDays * (Convert.ToDouble(hdnRate.Value == string.Empty ? "0" : hdnRate.Value));
                    dr["StatusId"] = (int)HBM.Common.Enums.HBMStatus.Active;
                    dr["CreatedUser"] = SessionHandler.LoggedUser.UsersId;

                    dsRoomInfomation.Tables[0].Rows.Add(dr);
                    Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;

                }
                else
                {
                    reservationRoom.ReservationId = 0;
                    dsRoomInfomation = reservationRoom.SelectAllDataSetByReseervationId();
                    Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;
                }

                gvRoomInfo.DataSource = dsRoomInfomation.Tables[0];
                gvRoomInfo.DataBind();

                this.ClearRoomInfoSection();
                this.Calculate();

                if (cmbCustomer.SelectedItem != null)
                {
                    this.LoadSharesList(Convert.ToInt32(cmbCustomer.SelectedItem.Value));
                }

            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearFormFields();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.URL_RESERVATIONSEARCH, false);
        }

        protected void cmbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnTaxPercent.Value = cmbTax.SelectedItem.GetValue("TaxPercentage").ToString();
            this.Calculate();
        }

        protected void txtDiscount_ValueChanged(object sender, EventArgs e)
        {
            this.Calculate();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ppPrintPreview.ContentUrl = Constants.URL_PRINTPREVIEW + "?ReservationID=" + hdnReservationId.Value;
            ppPrintPreview.ShowOnPageLoad = true;
        }

        protected void cmbRatePlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Session["RoomList"] != null)
            {
                int currentRoomID = Convert.ToInt32(cmbRoom.SelectedItem.Value.ToString());
                hdnRoom.Value = currentRoomID.ToString();

            }




        }

        protected void cmbRatePlan_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            LoadRatePlans();

        }

        #endregion

        #region Room Information

        private void LoadRoomInformation(Int64 reservationId)
        {
            reservationRoom.ReservationId = reservationId;
            dsRoomInfomation = reservationRoom.SelectAllDataSetByReseervationId();
            gvRoomInfo.DataSource = dsRoomInfomation.Tables[0];
            gvRoomInfo.DataBind();

            dsRoomInfomation.Tables[0].PrimaryKey = new DataColumn[] { dsRoomInfomation.Tables[0].Columns["ReservationRoomId"] };
            Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;

        }

        protected void gvRoomInfo_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "ReservationRoomId") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvRoomInfo_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvRoomInfo.FindVisibleIndexByKeyValue(e.Keys[gvRoomInfo.KeyFieldName]);
            e.Cancel = true;
            dsRoomInfomation = Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] as DataSet;

            dsRoomInfomation.Tables[0].DefaultView.Delete(dsRoomInfomation.Tables[0].Rows.IndexOf(dsRoomInfomation.Tables[0].Rows.Find(e.Keys[gvRoomInfo.KeyFieldName])));

            gvRoomInfo.DataSource = dsRoomInfomation.Tables[0];
            gvRoomInfo.DataBind();

            Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;

        }

        protected void gvRoomInfo_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsRoomInfomation = Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsRoomInfomation.Tables[0].NewRow();

            Random rd = new Random();
            e.NewValues["ReservationRoomId"] = rd.Next();

            Random rd1 = new Random();
            e.NewValues["ReservationId"] = rd1.Next();


            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
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

            dsRoomInfomation.Tables[0].Rows.Add(row);

            gvRoomInfo.DataSource = dsRoomInfomation.Tables[0];
            gvRoomInfo.DataBind();

            Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;

        }

        protected void gvRoomInfo_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsRoomInfomation = Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsRoomInfomation.Tables[0];
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

            gvRoomInfo.DataSource = dsRoomInfomation.Tables[0];
            gvRoomInfo.DataBind();

            Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = dsRoomInfomation;

        }

        protected void gvRoomInfo_DataBound(object sender, EventArgs e)
        {
            this.Calculate();
        }

        #endregion

        #region Addtional Service

        private void LoadAddiotnalService(Int64 reservationId)
        {
            reservationAdditionalService.ReservationId = reservationId;
            dsAdditionalService = reservationAdditionalService.SelectAllDataSetByReservationID();
            gvServiceInformation.DataSource = dsAdditionalService.Tables[0];
            gvServiceInformation.DataBind();

            dsAdditionalService.Tables[0].PrimaryKey = new DataColumn[] { dsAdditionalService.Tables[0].Columns["ReservationAdditionalServiceId"] };
            Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] = dsAdditionalService;

        }

        protected void gvServiceInformation_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvServiceInformation.FindVisibleIndexByKeyValue(e.Keys[gvServiceInformation.KeyFieldName]);
            e.Cancel = true;
            dsAdditionalService = Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] as DataSet;

            dsAdditionalService.Tables[0].DefaultView.Delete(dsAdditionalService.Tables[0].Rows.IndexOf(dsAdditionalService.Tables[0].Rows.Find(e.Keys[gvServiceInformation.KeyFieldName])));

            gvServiceInformation.DataSource = dsAdditionalService.Tables[0];
            gvServiceInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] = dsAdditionalService;

        }

        protected void gvServiceInformation_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsAdditionalService = Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsAdditionalService.Tables[0].NewRow();

            Random rd = new Random();
            e.NewValues["ReservationAdditionalServiceId"] = rd.Next();

            Random rd1 = new Random();
            e.NewValues["ReservationId"] = rd1.Next();


            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
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

            dsAdditionalService.Tables[0].Rows.Add(row);

            gvServiceInformation.DataSource = dsAdditionalService.Tables[0];
            gvServiceInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] = dsAdditionalService;

        }

        protected void gvServiceInformation_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsAdditionalService = Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsAdditionalService.Tables[0];
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

            gvServiceInformation.DataSource = dsAdditionalService.Tables[0];
            gvServiceInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] = dsAdditionalService;

        }

        protected void gvServiceInformation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "AdditionalServiceId") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        protected void gvServiceInformation_DataBound(object sender, EventArgs e)
        {

            this.Calculate();

        }

        #endregion

        #region Payment Information

        private void LoadPaymentInformation(Int64 reservationId)
        {
            reservationPayments.ReservationId = reservationId;
            dsPaymentInformation = reservationPayments.SelectAllDataSetByReservationID();
            gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
            gvPaymentInformation.DataBind();

            dsPaymentInformation.Tables[0].PrimaryKey = new DataColumn[] { dsPaymentInformation.Tables[0].Columns["ReservationPaymentId"] };
            Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = dsPaymentInformation;

        }

        protected void gvPaymentInformation_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

            int i = gvPaymentInformation.FindVisibleIndexByKeyValue(e.Keys[gvPaymentInformation.KeyFieldName]);
            e.Cancel = true;
            dsPaymentInformation = Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] as DataSet;

            dsPaymentInformation.Tables[0].DefaultView.Delete(dsPaymentInformation.Tables[0].Rows.IndexOf(dsPaymentInformation.Tables[0].Rows.Find(e.Keys[gvPaymentInformation.KeyFieldName])));

            gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
            gvPaymentInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = dsPaymentInformation;

        }

        protected void gvPaymentInformation_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsPaymentInformation = Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsPaymentInformation.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["ReservationPaymentId"] = rd.Next();

            Random rd1 = new Random();
            e.NewValues["ReservationId"] = rd.Next();
            e.NewValues["StatusId"] = (int)Enums.HBMStatus.Active;
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

            dsPaymentInformation.Tables[0].Rows.Add(row);

            gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
            gvPaymentInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = dsPaymentInformation;

        }

        protected void gvPaymentInformation_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsPaymentInformation = Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsPaymentInformation.Tables[0];
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

            gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
            gvPaymentInformation.DataBind();

            Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = dsPaymentInformation;
        }

        protected void gvPaymentInformation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (gvPaymentInformation.IsEditing)
            {
                if (e.Editor.ClientInstanceName == "ColType")
                {
                    if (((DevExpress.Web.ASPxEditors.ASPxComboBox)(e.Editor)).SelectedItem != null && ((DevExpress.Web.ASPxEditors.ASPxComboBox)(e.Editor)).SelectedItem.Text == "Credit Card")
                    {
                        ViewState["currentType"] = "Credit Card";
                    }
                    else
                    {
                        ViewState["currentType"] = string.Empty;
                    }
                }
                else
                {
                    if (ViewState["currentType"].ToString() == "Credit Card")
                    {
                        if (e.Column.FieldName == "CreditCardTypeId")
                        {
                            e.Editor.Enabled = true;
                        }
                        if (e.Column.FieldName == "CCNo")
                        {
                            e.Editor.Enabled = true;
                        }
                        if (e.Column.FieldName == "CCExpirationDate")
                        {
                            e.Editor.Enabled = true;
                        }
                        if (e.Column.FieldName == "CCNameOnCard")
                        {
                            e.Editor.Enabled = true;
                        }


                    }
                    else
                    {
                        if (e.Column.FieldName == "CreditCardTypeId")
                        {
                            e.Editor.Enabled = false;
                        }
                        if (e.Column.FieldName == "CCNo")
                        {
                            e.Editor.Enabled = false;
                        }
                        if (e.Column.FieldName == "CCExpirationDate")
                        {
                            e.Editor.Enabled = false;
                        }
                        if (e.Column.FieldName == "CCNameOnCard")
                        {
                            e.Editor.Enabled = false;
                        }
                    }

                }




            }


            if (e.Column.FieldName != "PaymentTypeId" && e.Column.FieldName != "CreditCardTypeId" && e.Column.FieldName != "CurrencyId") return;
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();







        }

        protected void gvPaymentInformation_DataBound(object sender, EventArgs e)
        {
            this.Calculate();
        }

        

        #endregion

    }

}
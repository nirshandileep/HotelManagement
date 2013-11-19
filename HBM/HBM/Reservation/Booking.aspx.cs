﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResMan = HBM.ReservationManagement;
using GenMan = HBM.GeneralManagement;
using HBM.CustomerManagement;
using System.Data;
using DevExpress.Web.ASPxGridView;
using HBM.Common;
using HBM.SessionManager;
using System.Collections;
using DevExpress.Web.ASPxEditors;
using HBM.GeneralManagement;
using GenRes = HBM.ReservationManagement;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HBM.Reservation
{
    public partial class Booking : System.Web.UI.Page
    {
        #region Variables

        DataSet dsRoomInfomation = new DataSet();
        DataSet dsAdditionalService = new DataSet();
        DataSet dsPaymentInformation = new DataSet();
        GenMan.AdditionalService additionalService = new GenMan.AdditionalService();
        GenRes.ReservationRoom reservationRoom = new GenRes.ReservationRoom();
        GenRes.ReservationAdditionalService reservationAdditionalService = new GenRes.ReservationAdditionalService();
        GenRes.ReservationPayments reservationPayments = new GenRes.ReservationPayments();

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            gvServiceInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
            gvPaymentInformation.SettingsText.ConfirmDelete = Messages.Delete_Confirm;

            gvPaymentInformation.SettingsPager.PageSize = Constants.GRID_PAGESIZE;
            gvServiceInformation.SettingsPager.PageSize = Constants.GRID_PAGESIZE;

            ((GridViewDataComboBoxColumn)gvServiceInformation.Columns["AdditionalServiceId"]).PropertiesComboBox.DataSource = new GenMan.AdditionalService() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CurrencyId"]).PropertiesComboBox.DataSource = new GenMan.CurrencyTypes().SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["PaymentTypeId"]).PropertiesComboBox.DataSource = (new GenMan.PaymentType() { CompanyId = Master.CurrentCompany.CompanyId }).SelectAllDataset().Tables[0];
            ((GridViewDataComboBoxColumn)gvPaymentInformation.Columns["CreditCardTypeId"]).PropertiesComboBox.DataSource = (new GenMan.CreditCardType() { CompanyId = Master.CurrentCompany.CompanyId }).SelectAllDataset().Tables[0];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadInitialData();
                this.LoadRoomInformation();
                this.LoadAddiotnalService();
                this.LoadPaymentInformation();
            }
        }

        #endregion

        #region Methods

        private void LoadInitialData()
        {
            //cmbResStatus.DataSource = new GenMan.Status().SelectAllList();
            //cmbResStatus.TextField = "StatusName";
            //cmbResStatus.ValueField = "StatusId";
            //cmbResStatus.DataBind();

            //cmbGuarantee.DataSource = new GenMan.Gaurantee() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset();
            //cmbGuarantee.TextField = "GuaranteeName";
            //cmbGuarantee.ValueField = "GuaranteeId";
            //cmbGuarantee.DataBind();

            cmbCustomer.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbCustomer.TextField = "CustomerName";
            cmbCustomer.ValueField = "CustomerId";
            cmbCustomer.DataBind();

            //cmbCustomerAdd.DataSource = new Customer() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            //cmbCustomerAdd.TextField = "CustomerName";
            //cmbCustomerAdd.ValueField = "CustomerId";
            //cmbCustomerAdd.DataBind();


            cmbTax.DataSource = new GenMan.TaxType() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbTax.TextField = "TaxTypeName";
            cmbTax.ValueField = "TaxTypeId";
            cmbTax.DataBind();

            cmbSource.DataSource = new GenMan.Source() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbSource.TextField = "SourceName";
            cmbSource.ValueField = "SourceId";
            cmbSource.DataBind();


            cmbRoom.DataSource = new GenMan.Room() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbRoom.TextField = "RoomName";
            cmbRoom.ValueField = "RoomId";
            cmbRoom.DataBind();

            cmbRatePlan.DataSource = new GenMan.RatePlans() { CompanyId = Master.CurrentCompany.CompanyId }.SelectAllDataset().Tables[0];
            cmbRatePlan.TextField = "RatePlanName";
            cmbRatePlan.ValueField = "RatePlansId";
            cmbRatePlan.DataBind();

        }


        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
            }
            else
            {
                //// show error msg
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] != null)
            {
                dsRoomInfomation = (DataSet)Session[Constants.SESSION_RESERVATION_ROOMINFORMATION];

                DataRow dr = dsRoomInfomation.Tables[0].NewRow();
                Random rd = new Random();
                dr["ReservationRoomId"] = rd.Next();
                dr["ReservationId"] = 0;
                dr["RoomId"] = Convert.ToInt32(cmbRoom.Value);
                dr["RoomRatePlanId"] = Convert.ToInt32(cmbRatePlan.Value);
                dr["Sharers"] = ddlShareNames.Text.Trim();
                dr["CheckInDate"] = dtCheckingDate.Text;
                dr["CheckOutDate"] = dtCheckOutDate.Text;
                dr["NumberOfAdults"] = seAdults.Text;
                dr["NumberOfChildren"] = seChildren.Text;
                dr["NumberOfInfant"] = seInfants.Text;

                TimeSpan tspan = Convert.ToDateTime(dtCheckOutDate.Text) - Convert.ToDateTime(dtCheckingDate.Text);
                double totalDays = 0;
                totalDays = tspan.TotalDays;

                dr["Days"] = totalDays;
                dr["Amount"] = totalDays * 10;
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



        }
        #endregion

        #region Reservation

        private bool SaveData()
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
                reservation.ReservationId = 0;
                reservation.CompanyId = Master.CurrentCompany.CompanyId;

                reservation.CustomerId = Convert.ToInt32(cmbCustomer.Value);
                reservation.SourceId = Convert.ToInt32(cmbSource.Value);
                reservation.CheckInDate = Convert.ToDateTime(dtCheckingDate.Text);
                reservation.CheckOutDate = Convert.ToDateTime(dtCheckOutDate.Text);
                reservation.StatusId = (int)HBM.Common.Enums.HBMStatus.Active;
                reservation.RoomTotal = Convert.ToDecimal(txtRoomTotal.Text.Trim());
                reservation.ServiceTotal = Convert.ToDecimal(txtServiceTotal.Text.Trim());
                reservation.NetTotal = Convert.ToDecimal(txtNetTotal.Text.Trim());
                reservation.Discount = Convert.ToDecimal(txtDiscount.Text.Trim());
                reservation.TaxAmount = Convert.ToDecimal(txtTaxTotal.Text.Trim());
                reservation.Total = Convert.ToDecimal(txtTotal.Text.Trim());
                reservation.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());
                reservation.Balance = Convert.ToDecimal(txtBalance.Text.Trim());
                reservation.CreatedUser = Master.LoggedUser.UsersId;
                reservation.ReservationRoomDataSet = this.dsRoomInfomation;
                reservation.ReservationAdditionalServiceDataSet = this.dsAdditionalService;
                reservation.ReservationPaymentDataSet = this.dsPaymentInformation;

                reservation.Save(db, transaction);
                transaction.Commit();
                result = true;
            }
            catch (System.Exception)
            {
                transaction.Rollback();
            }


            return result;
        }

        private bool DisplayData()
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
                reservation.ReservationId = 0;
                reservation = reservation.Select();

                cmbCustomer.Value = reservation.CustomerId;
                cmbSource.Value = reservation.SourceId;
                dtCheckingDate.Text = reservation.CheckInDate.ToString();
                dtCheckOutDate.Text = reservation.CheckOutDate.ToString();

                txtRoomTotal.Text = reservation.RoomTotal.ToString();
                txtServiceTotal.Text = reservation.ServiceTotal.ToString();
                txtNetTotal.Text = reservation.NetTotal.ToString();
                txtDiscount.Text = reservation.Discount.ToString();
                txtTaxTotal.Text = reservation.TaxAmount.ToString();
                txtTotal.Text = reservation.Total.ToString();
                txtPaidAmount.Text = reservation.PaidAmount.ToString();
                txtBalance.Text = reservation.Balance.ToString();
                this.dsRoomInfomation = reservation.ReservationRoomDataSet;
                this.dsAdditionalService = reservation.ReservationAdditionalServiceDataSet;
                this.dsPaymentInformation = reservation.ReservationPaymentDataSet;


                this.LoadAddiotnalService();
                this.LoadPaymentInformation();


                transaction.Commit();
                result = true;
            }
            catch (System.Exception)
            {
                transaction.Rollback();
            }


            return result;
        }

        #endregion

        #region Room Information

        private void LoadRoomInformation()
        {
            reservationRoom.ReservationId = 0;
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
        }

        #endregion

        #region Addtional Service

        private void LoadAddiotnalService()
        {
            reservationAdditionalService.ReservationId = 0;
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

        }

        protected void gvServiceInformation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "AdditionalServiceId") return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        #endregion

        #region Payment Information

        private void LoadPaymentInformation()
        {
            reservationPayments.ReservationId = 0;
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
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsPaymentInformation.Tables[0].DefaultView.Delete(dsPaymentInformation.Tables[0].Rows.IndexOf(dsPaymentInformation.Tables[0].Rows.Find(e.Keys[gvPaymentInformation.KeyFieldName])));

            gvPaymentInformation.DataSource = dsPaymentInformation.Tables[0];
            gvPaymentInformation.DataBind();

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
            //e.NewValues["CompanyId"] = SessionHandler.CurrentCompanyId; ;
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
        }

        protected void gvPaymentInformation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "PaymentTypeId" && e.Column.FieldName != "CreditCardTypeId" && e.Column.FieldName != "CurrencyId") return;
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

        #endregion        

    }
}
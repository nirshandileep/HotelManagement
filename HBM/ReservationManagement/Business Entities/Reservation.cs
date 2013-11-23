using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.ReservationManagement
{
    public class Reservation
    {
        #region Properies

        public Int64 ReservationId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public string ReservationCode { get; set; }
        public int StatusId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? SourceId { get; set; }
        public decimal RoomTotal { get; set; }
        public decimal ServiceTotal { get; set; }
        public decimal NetTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public ReservationRoom ReservationRoom { get; set; }
        public int TaxTypeId { get; set; }
        public DataSet ReservationAdditionalServiceDataSet { get; set; }
        public DataSet ReservationPaymentDataSet { get; set; }
        public DataSet ReservationRoomDataSet { get; set; }

        #endregion

        #region Methods

        public bool Save(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                if (this.ReservationId > 0)
                {
                    result = (new ReservationDAO()).Update(this, db,  transaction);
                }
                else
                {
                    result = (new ReservationDAO()).Insert(this, db,  transaction);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
            
        public Reservation Select()
        {
            Reservation reservation = HBM.Utility.Generic.Get<Reservation>(this.ReservationId);

            if (reservation == null)
            {
                reservation = new Reservation();
            }
            
            reservation.ReservationAdditionalServiceDataSet = (new ReservationDAO()).SelectReservationAdditionalServices(this);
            reservation.ReservationPaymentDataSet = (new ReservationDAO()).SelectReservationPayments(this);
            reservation.ReservationRoomDataSet = (new ReservationDAO()).SelectReservationRooms(this);

            return reservation;
        }

        public List<Reservation> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Reservation>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new ReservationDAO()).SelectAll(this);
        }
        #endregion
    }
}

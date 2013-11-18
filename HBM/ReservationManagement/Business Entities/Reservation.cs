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
        public Int64 ReservationId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
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

        //public DataSet DsReservationGuest { get; set; }
        public DataSet DsReservationAdditionalService { get; set; }
        public DataSet DsReservationPayment { get; set; }
        public DataSet DsReservationRoom { get; set; }

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

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.ReservationId > 0)
                {
                    result = (new ReservationDAO()).Delete(this);
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

            //reservation.DsReservationGuest = (new ReservationDAO()).SelectReservationGuests(this);
            reservation.DsReservationAdditionalService = (new ReservationDAO()).SelectReservationAdditionalServices(this);
            reservation.DsReservationPayment = (new ReservationDAO()).SelectReservationPayments(this);
            reservation.DsReservationRoom = (new ReservationDAO()).SelectReservationRooms(this);

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
    }
}

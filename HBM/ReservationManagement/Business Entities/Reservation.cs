using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.ReservationManagement
{
    public class Reservation
    {
        public Int64 ReservationId { get; set; }
        public int CompanyId { get; set; }
        public string ReservationCode { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int? SourceId { get; set; }
        public int GuaranteeId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? TotalDue { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public ReservationRoom ReservationRoom { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TaxTypeId { get; set; }

        #region Save

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.ReservationId > 0)
                {
                    result = (new ReservationDAO()).Update(this);
                }
                else
                {
                    result = (new ReservationDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        #endregion


        #region Delete

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

        #endregion


        public Reservation Select()
        {
            return HBM.Utility.Generic.Get<Reservation>(this.ReservationId);
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

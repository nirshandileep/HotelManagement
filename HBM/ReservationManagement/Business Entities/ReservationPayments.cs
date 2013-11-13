﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace HBM.ReservationManagement
{
    public class ReservationPayments
    {
        #region Properties

        public int ReservationPaymentId { get; set; }
        public int ReservationId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        public int PaymentTypeId { get; set; }
        public int CurrencyId { get; set; }
        public int CreditCardTypeId { get; set; }
        public string CCNo { get; set; }
        public DateTime CCExpirationDate { get; set; }
        public string CCNameOnCard { get; set; }
        
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new ReservationPaymentsDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public DataSet SelectAllDataSetByReservationID()
        {
            return (new ReservationPaymentsDAO()).SelectByReservationID(this);
        }
    }
}

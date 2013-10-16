using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace HBM.Data
{
    public class ReservationPayment
    {
        #region Properties

        public int ReservationPaymentId { get; set; }
        public int ReservationId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        public Int32 PaymentTypeId { get; set; }
        public Int32 CurrencyId { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        public bool Save(Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@PaymentAmount", DbType.Decimal, PaymentAmount);
            db.AddInParameter(command, "@PaymentDate", DbType.DateTime, PaymentDate);
            db.AddInParameter(command, "@ReferenceNumber", DbType.String, ReferenceNumber);
            db.AddInParameter(command, "@Notes", DbType.String, Notes);
            db.AddInParameter(command, "@PaymentTypeId", DbType.Int32, PaymentTypeId);
            db.AddInParameter(command, "@CurrencyId", DbType.Int32, CurrencyId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);


            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool Update(Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@ReservationPaymentId", DbType.Int32, ReservationPaymentId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@PaymentAmount", DbType.Decimal, PaymentAmount);
            db.AddInParameter(command, "@PaymentDate", DbType.DateTime, PaymentDate);
            db.AddInParameter(command, "@ReferenceNumber", DbType.String, ReferenceNumber);
            db.AddInParameter(command, "@Notes", DbType.String, Notes);
            db.AddInParameter(command, "@PaymentTypeId", DbType.Int32, PaymentTypeId);
            db.AddInParameter(command, "@CurrencyId", DbType.Int32, CurrencyId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool Delete(Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@ReservationPaymentId", DbType.Int32, ReservationPaymentId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);


            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public void Select(Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@ReservationPaymentId", DbType.Int32, ReservationPaymentId);
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, ReservationId);

            IDataReader reader = db.ExecuteReader(dbCommand, transaction);

            if (reader.Read())
            {
                ReservationPaymentId = Convert.ToInt32(reader["ReservationPaymentId"].ToString());
                ReservationId = Convert.ToInt32(reader["ReservationId"].ToString());

                PaymentAmount = Convert.ToDecimal( reader["PaymentAmount"] != DBNull.Value ? reader["PaymentAmount"].ToString() : "0");
                PaymentDate = Convert.ToDateTime(reader["PaymentDate"] != DBNull.Value ? reader["PaymentDate"].ToString() : DateTime.MinValue.ToString());                
                ReferenceNumber = reader["ReferenceNumber"] != DBNull.Value ? reader["ReferenceNumber"].ToString() : string.Empty;
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : string.Empty;                                                      
                PaymentTypeId = Convert.ToInt32(reader["PaymentTypeId"] != DBNull.Value ? reader["PaymentTypeId"].ToString() : "0");
                CurrencyId = Convert.ToInt32(reader["CurrencyId"] != DBNull.Value ? reader["CurrencyId"].ToString() : "0");
                CreatedUser = Convert.ToInt32(reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32(reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());

            }

        }

        #endregion

    }
}

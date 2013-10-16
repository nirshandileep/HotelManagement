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
    public class Reservation
    {
        #region Properties

        public int CompanyId { get; set; }
        public int ReservationId { get; set; }
        public string ReservationCode { get; set; }
        public DateTime BookingDate { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 SourceId { get; set; }
        public Int32 GuaranteeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save(Database db, DbTransaction transaction)
        {
         
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ReservationCode", DbType.String, ReservationCode);
            db.AddInParameter(command, "@BookingDate", DbType.Date, BookingDate);
            db.AddInParameter(command, "@CustomerId", DbType.Int32, CustomerId);
            db.AddInParameter(command, "@SourceId", DbType.Int32, SourceId);
            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, GuaranteeId);
            db.AddInParameter(command, "@TotalAmount", DbType.Decimal, TotalAmount);
            db.AddInParameter(command, "@TotalPaid", DbType.Decimal, TotalPaid);
            db.AddInParameter(command, "@TotalDue", DbType.Decimal, TotalDue);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool Update(Database db, DbTransaction transaction)
        {

           
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@ReservationCode", DbType.String, ReservationCode);
            db.AddInParameter(command, "@BookingDate", DbType.Date, BookingDate);
            db.AddInParameter(command, "@CustomerId", DbType.Int32, CustomerId);
            db.AddInParameter(command, "@SourceId", DbType.Int32, SourceId);
            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, GuaranteeId);
            db.AddInParameter(command, "@TotalAmount", DbType.Decimal, TotalAmount);
            db.AddInParameter(command, "@TotalPaid", DbType.Decimal, TotalPaid);
            db.AddInParameter(command, "@TotalDue", DbType.Decimal, TotalDue);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command,transaction);

            return true;
        }

        public bool Delete(Database db, DbTransaction transaction)
        {  
           
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);


            db.ExecuteNonQuery(command,transaction);

            return true;
        }

        public void Select(Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, ReservationId);

            IDataReader reader = db.ExecuteReader(dbCommand,transaction);

            if (reader.Read())
            {
                ReservationId = Convert.ToInt32(reader["ReservationId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                ReservationCode = reader["ReservationCode"] != DBNull.Value ? reader["ReservationCode"].ToString() : string.Empty;
                BookingDate = Convert.ToDateTime(reader["BookingDate"] != DBNull.Value ? reader["BookingDate"].ToString() : DateTime.MinValue.ToString());
                CustomerId = Convert.ToInt32(reader["CustomerId"] != DBNull.Value ? reader["CustomerId"].ToString() : "0");
                SourceId = Convert.ToInt32(reader["SourceId"] != DBNull.Value ? reader["SourceId"].ToString() : "0");
                GuaranteeId = Convert.ToInt32(reader["GuaranteeId"] != DBNull.Value ? reader["GuaranteeId"].ToString() : "0"); 
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"] != DBNull.Value ? reader["TotalAmount"].ToString() : "0");
                TotalPaid = Convert.ToDecimal(reader["TotalPaid"] != DBNull.Value ? reader["TotalPaid"].ToString() : "0");
                TotalDue = Convert.ToDecimal(reader["TotalDue"] != DBNull.Value ? reader["TotalDue"].ToString() : "0");        
                CreatedUser = Convert.ToInt32(reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32(reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");
            }

        }

        #endregion
    }

}

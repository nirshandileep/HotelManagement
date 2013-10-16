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
    public class ReservationAdditionalService
    {
        #region Properties

        public int ReservationAdditionalServiceId { get; set; }
        public int ReservationId { get; set; }
        public string Note { get; set; }    
        public decimal Amount { get; set; }
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
            db.AddInParameter(command, "@Note", DbType.String, Note);
            db.AddInParameter(command, "@Amount", DbType.Decimal, Amount);
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

            db.AddInParameter(command, "@ReservationAdditionalServiceId", DbType.Int32, ReservationAdditionalServiceId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@Note", DbType.String, Note);
            db.AddInParameter(command, "@Amount", DbType.Decimal, Amount);
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

            db.AddInParameter(command, "@ReservationAdditionalServiceId", DbType.Int32, ReservationAdditionalServiceId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);


            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public void Select(Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@ReservationAdditionalServiceId", DbType.Int32, ReservationAdditionalServiceId);
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, ReservationId);

            IDataReader reader = db.ExecuteReader(dbCommand, transaction);

            if (reader.Read())
            {
                ReservationAdditionalServiceId = Convert.ToInt32(reader["ReservationAdditionalServiceId"].ToString());
                ReservationId = Convert.ToInt32(reader["ReservationId"].ToString());

                Note = reader["Note"] != DBNull.Value ? reader["Note"].ToString() : string.Empty;
                Amount = Convert.ToDecimal(reader["Amount"] != DBNull.Value ? reader["Amount"].ToString() : "0");

                CreatedUser = Convert.ToInt32( reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32(  reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());

            }

        }

        #endregion
    }
}

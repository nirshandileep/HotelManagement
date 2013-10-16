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
    public class ReservationRoom
    {

        #region Properties

        public Int32 ReservationRoomId { get; set; }
        public Int32 ReservationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Int32 NumberOfAdults { get; set; }
        public Int32 NumberOfChildren { get; set; }
        public Int32 NumberOfInfant { get; set; }        
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

            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@Amount", DbType.Decimal, Amount);
            db.AddInParameter(command, "@CheckInDate", DbType.DateTime, CheckInDate);
            db.AddInParameter(command, "@CheckOutDate", DbType.DateTime, CheckOutDate);             
            db.AddInParameter(command, "@NumberOfAdults", DbType.Int32, NumberOfAdults);
            db.AddInParameter(command, "@NumberOfChildren", DbType.Int32, NumberOfChildren);
            db.AddInParameter(command, "@NumberOfInfant", DbType.Int32, NumberOfInfant);         
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

            db.AddInParameter(command, "@ReservationRoomId", DbType.Int32, ReservationRoomId);  
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@Amount", DbType.Decimal, Amount);
            db.AddInParameter(command, "@CheckInDate", DbType.DateTime, CheckInDate);
            db.AddInParameter(command, "@CheckOutDate", DbType.DateTime, CheckOutDate);
            db.AddInParameter(command, "@NumberOfAdults", DbType.Int32, NumberOfAdults);
            db.AddInParameter(command, "@NumberOfChildren", DbType.Int32, NumberOfChildren);
            db.AddInParameter(command, "@NumberOfInfant", DbType.Int32, NumberOfInfant);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool Delete(Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@ReservationRoomId", DbType.Int32, ReservationRoomId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public void Select(Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@ReservationRoomId", DbType.Int32, ReservationRoomId);
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, ReservationId);

            IDataReader reader = db.ExecuteReader(dbCommand, transaction);

            if (reader.Read())
            {
                ReservationRoomId = Convert.ToInt32(reader["ReservationRoomId"].ToString());
                ReservationId = Convert.ToInt32(reader["ReservationId"].ToString());

                Amount = Convert.ToDecimal(reader["Amount"] != DBNull.Value ? reader["Amount"].ToString() : "0");
                CheckInDate = Convert.ToDateTime(reader["CheckInDate"] != DBNull.Value ? reader["CheckInDate"].ToString() : DateTime.MinValue.ToString());
                CheckOutDate = Convert.ToDateTime(reader["CheckOutDate"] != DBNull.Value ? reader["CheckOutDate"].ToString() : DateTime.MinValue.ToString());
                NumberOfAdults = Convert.ToInt32(reader["NumberOfAdults"] != DBNull.Value ? reader["NumberOfAdults"].ToString() : "0");
                NumberOfChildren = Convert.ToInt32(reader["NumberOfChildren"] != DBNull.Value ? reader["NumberOfChildren"].ToString() : "0");
                NumberOfInfant = Convert.ToInt32(reader["NumberOfInfant"] != DBNull.Value ? reader["NumberOfInfant"].ToString() : "0");
                CreatedUser = Convert.ToInt32(reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32(reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());

            }

        }

        #endregion

    }
}

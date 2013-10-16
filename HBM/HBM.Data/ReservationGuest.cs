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
    public class ReservationGuest
    {

        #region Properties

        public int ReservationGuestId { get; set; }
        public int ReservationId { get; set; }
        public string GuestName { get; set; }
        public string GuestCompany { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }        
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
            db.AddInParameter(command, "@GuestName", DbType.String, GuestName);
            db.AddInParameter(command, "@GuestCompany", DbType.String, GuestCompany);
            db.AddInParameter(command, "@GuestEmail", DbType.String, GuestEmail);
            db.AddInParameter(command, "@GuestPhone", DbType.String, GuestPhone);
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

            db.AddInParameter(command, "@ReservationGuestId", DbType.Int32, ReservationGuestId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);
            db.AddInParameter(command, "@GuestName", DbType.String, GuestName);
            db.AddInParameter(command, "@GuestCompany", DbType.String, GuestCompany);
            db.AddInParameter(command, "@GuestEmail", DbType.String, GuestEmail);
            db.AddInParameter(command, "@GuestPhone", DbType.String, GuestPhone);
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

            db.AddInParameter(command, "@ReservationGuestId", DbType.Int32, ReservationGuestId);
            db.AddInParameter(command, "@ReservationId", DbType.Int32, ReservationId);


            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public void Select(Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@ReservationGuestId", DbType.Int32, ReservationGuestId);
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, ReservationId);

            IDataReader reader = db.ExecuteReader(dbCommand, transaction);

            if (reader.Read())
            {
                ReservationGuestId = Convert.ToInt32(reader["ReservationGuestId"].ToString());
                ReservationId = Convert.ToInt32(reader["ReservationId"].ToString());
                GuestName = reader["GuestName"] != DBNull.Value ? reader["GuestName"].ToString() : string.Empty;
                GuestCompany = reader["GuestCompany"] != DBNull.Value ? reader["GuestCompany"].ToString() : string.Empty;
                GuestEmail = reader["GuestEmail"] != DBNull.Value ? reader["GuestEmail"].ToString() : string.Empty;
                GuestEmail = reader["GuestPhone"] != DBNull.Value ? reader["GuestPhone"].ToString() : string.Empty;
                CreatedUser = Convert.ToInt32(reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32(reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());

            }

        }

        #endregion

    }
}

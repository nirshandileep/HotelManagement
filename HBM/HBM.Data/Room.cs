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
    public class Room
    {
        #region Properties

        public int CompanyId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public int BedTypeId { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxInfant { get; set; }
        public bool SmokingAllow { get; set; }        
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@RoomName", DbType.String, RoomName);
            db.AddInParameter(command, "@RoomNumber", DbType.String, RoomNumber);
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, BedTypeId);
            db.AddInParameter(command, "@MaxAdult", DbType.Int32, MaxAdult);
            db.AddInParameter(command, "@MaxChildren", DbType.Int32, MaxChildren);
            db.AddInParameter(command, "@MaxInfant", DbType.Int32, MaxInfant);
            db.AddInParameter(command, "@SmokingAllow", DbType.Boolean, SmokingAllow);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@RoomId", DbType.Int32, RoomId);     
            db.AddInParameter(command, "@RoomName", DbType.String, RoomName);
            db.AddInParameter(command, "@RoomNumber", DbType.String, RoomNumber);
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, BedTypeId);
            db.AddInParameter(command, "@MaxAdult", DbType.Int32, MaxAdult);
            db.AddInParameter(command, "@MaxChildren", DbType.Int32, MaxChildren);
            db.AddInParameter(command, "@MaxInfant", DbType.Int32, MaxInfant);
            db.AddInParameter(command, "@SmokingAllow", DbType.Boolean, SmokingAllow);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@RoomId", DbType.Int32, RoomId);     


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@RoomId", DbType.Int32, RoomId);     

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                RoomId = Convert.ToInt32(reader["RoomId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());

                RoomName = reader["RoomName"] != DBNull.Value ? reader["RoomName"].ToString() : string.Empty;
                RoomNumber = reader["RoomNumber"] != DBNull.Value ? reader["RoomNumber"].ToString() : string.Empty;
                BedTypeId = Convert.ToInt32(reader["BedTypeId"] != DBNull.Value ? reader["BedTypeId"].ToString() : "0");
                MaxAdult =Convert.ToInt32( reader["MaxAdult"] != DBNull.Value ? reader["MaxAdult"].ToString() :"0");
                MaxChildren = Convert.ToInt32(reader["MaxChildren"] != DBNull.Value ? reader["MaxChildren"].ToString() : "0");
                MaxInfant = Convert.ToInt32(reader["MaxInfant"] != DBNull.Value ? reader["MaxInfant"].ToString() : "0");
                SmokingAllow = Convert.ToBoolean(reader["SmokingAllow"] != DBNull.Value ? reader["SmokingAllow"].ToString() : "0");       
                CreatedBy = reader["CreatedBy"] != DBNull.Value ? reader["CreatedBy"].ToString() : "0";
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                CreatedBy = reader["UpdatedBy"] != DBNull.Value ? reader["UpdatedBy"].ToString() : "0";
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");

            }

        }

        #endregion
    }
}

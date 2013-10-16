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
    public class Company
    {
        #region Properties

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTelephone { get; set; }     
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
          
            db.AddInParameter(command, "@CompanyName", DbType.String, CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, CompanyAddress);
            db.AddInParameter(command, "@CompanyCity", DbType.String, CompanyCity);
            db.AddInParameter(command, "@CompanyEmail", DbType.String, CompanyEmail);
            db.AddInParameter(command, "@CompanyTelephone", DbType.String, CompanyTelephone);
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
            db.AddInParameter(command, "@CompanyName", DbType.String, CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, CompanyAddress);
            db.AddInParameter(command, "@CompanyCity", DbType.String, CompanyCity);
            db.AddInParameter(command, "@CompanyEmail", DbType.String, CompanyEmail);
            db.AddInParameter(command, "@CompanyTelephone", DbType.String, CompanyTelephone);
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

            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
          
            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
               
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : string.Empty;
                CompanyAddress = reader["CompanyAddress"] != DBNull.Value ? reader["CompanyAddress"].ToString() : string.Empty;
                CompanyCity = reader["CompanyCity"] != DBNull.Value ? reader["CompanyCity"].ToString() : string.Empty;
                CompanyEmail = reader["CompanyEmail"] != DBNull.Value ? reader["CompanyEmail"].ToString() : string.Empty;
                CompanyTelephone = reader["CompanyTelephone"] != DBNull.Value ? reader["CompanyTelephone"].ToString() : string.Empty;
                CompanyAddress = reader["CompanyAddress"] != DBNull.Value ? reader["CompanyAddress"].ToString() : string.Empty;
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

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
    public class BedType
    {
        #region Properties

        public int CompanyId { get; set; }
        public int BedTypeId { get; set; }
        public string BedTypeName { get; set; }
        public string BedTypeDescription { get; set; }         
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
            db.AddInParameter(command, "@BedTypeName", DbType.String, BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, BedTypeDescription);         
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

            db.AddInParameter(command, "@BedTypeId", DbType.Int32, BedTypeId);    
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@BedTypeName", DbType.String, BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, BedTypeDescription);
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
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, BedTypeId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@BedTypeId", DbType.Int32, BedTypeId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                BedTypeId = Convert.ToInt32(reader["BedTypeId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                BedTypeName = reader["BedTypeName"] != DBNull.Value ? reader["BedTypeName"].ToString() : string.Empty;
                BedTypeDescription = reader["BedTypeDescription"] != DBNull.Value ? reader["BedTypeDescription"].ToString() : string.Empty;               
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

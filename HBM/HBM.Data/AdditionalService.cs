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
    public class AdditionalService
    {
        #region Properties

        public int CompanyId { get; set; }
        public int AdditionalServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public int AdditionalServiceTypeId { get; set; }
        public decimal Rate { get; set; }   
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ServiceName", DbType.String, ServiceName);
            db.AddInParameter(command, "@ServiceCode", DbType.String, ServiceCode);  
            db.AddInParameter(command, "@Rate", DbType.Decimal, Rate);
            db.AddInParameter(command, "@AdditionalServiceTypeId", DbType.String, AdditionalServiceTypeId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@AdditionalServiceId", DbType.Int32, AdditionalServiceId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ServiceName", DbType.String, ServiceName);
            db.AddInParameter(command, "@ServiceCode", DbType.String, ServiceCode);
            db.AddInParameter(command, "@Rate", DbType.Decimal, Rate);
            db.AddInParameter(command, "@AdditionalServiceTypeId", DbType.String, AdditionalServiceTypeId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
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
            db.AddInParameter(command, "@AdditionalServiceId", DbType.Int32, AdditionalServiceId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@AdditionalServiceId", DbType.Int32, AdditionalServiceId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                AdditionalServiceId = Convert.ToInt32(reader["AdditionalServiceId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                ServiceName = reader["ServiceName"] != DBNull.Value ? reader["ServiceName"].ToString() : string.Empty;
                ServiceCode = reader["ServiceCode"] != DBNull.Value ? reader["ServiceCode"].ToString() : string.Empty;
                CreatedUser = Convert.ToInt32( reader["CreatedBy"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0";
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");

            }

        }

        #endregion
    }
}

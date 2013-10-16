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
    public class Guarantee
    {
        #region Properties

        public int CompanyId { get; set; }
        public int GuaranteeId { get; set; }
        public string GuaranteeName { get; set; }
        public string GuaranteeDescription { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@GuaranteeName", DbType.String, GuaranteeName);
            db.AddInParameter(command, "@GuaranteeDescription", DbType.String, GuaranteeDescription);   
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

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, GuaranteeId);    
            db.AddInParameter(command, "@GuaranteeName", DbType.String, GuaranteeName);
            db.AddInParameter(command, "@GuaranteeDescription", DbType.String, GuaranteeDescription);
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
            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, GuaranteeId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@GuaranteeId", DbType.Int32, GuaranteeId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                GuaranteeId = Convert.ToInt32(reader["GuaranteeId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());

                GuaranteeName = reader["GuaranteeName"] != DBNull.Value ? reader["GuaranteeName"].ToString() : string.Empty;
                GuaranteeDescription = reader["GuaranteeDescription"] != DBNull.Value ? reader["GuaranteeDescription"].ToString() : string.Empty;

                CreatedUser = Convert.ToInt32( reader["CreatedUser"] != DBNull.Value ? reader["CreatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                UpdatedUser = Convert.ToInt32( reader["UpdatedUser"] != DBNull.Value ? reader["UpdatedUser"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");

            }

        }

        #endregion
    }
}

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
    public class RatePlans
    {
        #region Properties

        public int RatePlanId { get; set; }
        public int CompanyId { get; set; }
        public string RatePlanName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public decimal Rate { get; set; }
        public decimal AdditionalAdultRate { get; set; }
        public decimal AdditionalChildrenRate { get; set; }
        public decimal AdditionalInfantRate { get; set; }
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
            db.AddInParameter(command, "@RatePlanName", DbType.String, RatePlanName);
            db.AddInParameter(command, "@EffectiveFrom", DbType.DateTime, EffectiveFrom);
            db.AddInParameter(command, "@EffectiveTo", DbType.DateTime, EffectiveTo);
            db.AddInParameter(command, "@AdditionalAdultRate", DbType.Decimal, AdditionalAdultRate);
            db.AddInParameter(command, "@AdditionalChildrenRate", DbType.Decimal, AdditionalChildrenRate);
            db.AddInParameter(command, "@AdditionalInfantRate", DbType.Decimal, AdditionalInfantRate);
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

            db.AddInParameter(command, "@RatePlanId", DbType.Int32, RatePlanId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@RatePlanName", DbType.String, RatePlanName);
            db.AddInParameter(command, "@EffectiveFrom", DbType.DateTime, EffectiveFrom);
            db.AddInParameter(command, "@EffectiveTo", DbType.DateTime, EffectiveTo);
            db.AddInParameter(command, "@AdditionalAdultRate", DbType.Decimal, AdditionalAdultRate);
            db.AddInParameter(command, "@AdditionalChildrenRate", DbType.Decimal, AdditionalChildrenRate);
            db.AddInParameter(command, "@AdditionalInfantRate", DbType.Decimal, AdditionalInfantRate);
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
            db.AddInParameter(command, "@RatePlanId", DbType.Int32, RatePlanId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "@RatePlanId", DbType.Int32, RatePlanId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                RatePlanId = Convert.ToInt32(reader["RatePlanId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());

                RatePlanName = reader["RatePlanName"] != DBNull.Value ? reader["RatePlanName"].ToString() : string.Empty;
                EffectiveFrom = Convert.ToDateTime(reader["EffectiveFrom"] != DBNull.Value ? reader["EffectiveFrom"].ToString() : DateTime.MinValue.ToString());
                EffectiveTo = Convert.ToDateTime(reader["EffectiveTo"] != DBNull.Value ? reader["EffectiveTo"].ToString() : DateTime.MinValue.ToString());
                AdditionalAdultRate = Convert.ToDecimal(reader["AdditionalAdultRate"] != DBNull.Value ? reader["AdditionalAdultRate"].ToString() : "0");
                AdditionalChildrenRate = Convert.ToDecimal(reader["AdditionalChildrenRate"] != DBNull.Value ? reader["AdditionalChildrenRate"].ToString() : "0");
                AdditionalInfantRate = Convert.ToDecimal(reader["AdditionalInfantRate"] != DBNull.Value ? reader["AdditionalInfantRate"].ToString() : "0");
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

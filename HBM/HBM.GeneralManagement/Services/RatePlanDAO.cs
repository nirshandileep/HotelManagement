using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.GeneralManagement
{
    public class RatePlansDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_RatePlansInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RatePlanName", DbType.String, "RatePlanName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@EffectiveFrom", DbType.DateTime, "EffectiveFrom", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@EffectiveTo", DbType.DateTime, "EffectiveTo", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalAdultRate", DbType.Decimal, "AdditionalAdultRate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalChildrenRate", DbType.Decimal, "AdditionalChildrenRate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalInfantRate", DbType.Decimal, "AdditionalInfantRate", DataRowVersion.Current);             
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_RatePlansUpdate");

            db.AddInParameter(commandUpdate, "@RatePlansId", DbType.String, "RatePlansId", DataRowVersion.Current);            
            db.AddInParameter(commandUpdate, "@RatePlanName", DbType.String, "RatePlanName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@EffectiveFrom", DbType.DateTime, "EffectiveFrom", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@EffectiveTo", DbType.DateTime, "EffectiveTo", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalAdultRate", DbType.Decimal, "AdditionalAdultRate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalChildrenRate", DbType.Decimal, "AdditionalChildrenRate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalInfantRate", DbType.Decimal, "AdditionalInfantRate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_RatePlansDelete");
            db.AddInParameter(commandDelete, "@RatePlansId", DbType.Int32, "RatePlansId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(RatePlans ratePlan)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RatePlansSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, ratePlan.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

    }
}

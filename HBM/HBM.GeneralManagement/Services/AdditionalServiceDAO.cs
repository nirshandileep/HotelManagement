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
    public class AdditionalServiceDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_AdditionalServiceInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceName", DbType.String, "ServiceName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceCode", DbType.String, "ServiceCode", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceMethodID", DbType.Int32, "ServiceMethodID", DataRowVersion.Current);
            

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_AdditionalServiceUpdate");
            db.AddInParameter(commandUpdate, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceName", DbType.String, "ServiceName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceCode", DbType.String, "ServiceCode", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);            
            db.AddInParameter(commandUpdate, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceMethodID", DbType.Int32, "ServiceMethodID", DataRowVersion.Current);


            DbCommand commandDelete = db.GetStoredProcCommand("usp_AdditionalServiceDelete");
            db.AddInParameter(commandDelete, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(AdditionalService additionalService)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AdditionalServiceSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, additionalService.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

        public bool IsDuplicateServiceCode(AdditionalService additionalService)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AdditionalServiceIsDuplicateTypeName");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, additionalService.CompanyId);
            db.AddInParameter(dbCommand, "@AdditionalServiceId", DbType.Int32, additionalService.AdditionalServiceId);
            db.AddInParameter(dbCommand, "@ServiceCode", DbType.String, additionalService.ServiceCode);
            db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

            db.ExecuteNonQuery(dbCommand);

            result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            return result;
        }

    }
}

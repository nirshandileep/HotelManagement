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
    public class ServiceMethodsDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_ServiceMethodsInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceMethod", DbType.String, "ServiceMethod", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_ServiceMethodsUpdate");
            db.AddInParameter(commandUpdate, "@ServiceMethodID", DbType.Int32, "ServiceMethodID", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceMethod", DbType.String, "ServiceMethod", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            
            DbCommand commandDelete = db.GetStoredProcCommand("usp_ServiceMethodsDelete");
            db.AddInParameter(commandDelete, "@ServiceMethodID", DbType.Int32, "ServiceMethodID", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(ServiceMethods serviceMethod)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServiceMethodsSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, serviceMethod.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

        public bool IsDuplicateTypeName(ServiceMethods serviceMethod)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServiceMethodsIsDuplicateServiceMethod");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, serviceMethod.CompanyId);
            db.AddInParameter(dbCommand, "@ServiceMethodID", DbType.Int32, serviceMethod.ServiceMethodID);
            db.AddInParameter(dbCommand, "@ServiceMethod", DbType.String, serviceMethod.ServiceMethod);
            db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

            db.ExecuteNonQuery(dbCommand);

            result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            return result;
        }
    }
}

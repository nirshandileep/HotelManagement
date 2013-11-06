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
    public class AdditionalServiceTypeDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_AdditionalServiceTypeInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalServiceType", DbType.String, "AdditionalServiceType", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_AdditionalServiceTypeUpdate");
            db.AddInParameter(commandUpdate, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalServiceType", DbType.String, "AdditionalServiceType", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_AdditionalServiceTypeDelete");
            db.AddInParameter(commandDelete, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }    

        public DataSet SelectAll(AdditionalServiceType additionalServiceType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AdditionalServiceTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, additionalServiceType.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

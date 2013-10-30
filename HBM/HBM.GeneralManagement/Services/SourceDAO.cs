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
    public class SourceDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_SourceInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@SourceName", DbType.String, "SourceName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_SourceUpdate");
            db.AddInParameter(commandUpdate, "@SourceId", DbType.Int32, "SourceId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@SourceName", DbType.String, "SourceName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_SourceDelete");
            db.AddInParameter(commandDelete, "@SourceId", DbType.Int32, "SourceId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(Source source)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SourceSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, source.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

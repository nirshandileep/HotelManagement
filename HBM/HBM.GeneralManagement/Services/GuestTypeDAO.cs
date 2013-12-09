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
    public class GuestTypeDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_GuestTypeInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@GuestTypeName", DbType.String, "GuestTypeName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@GuestTypeDescription", DbType.String, "GuestTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_GuestTypeUpdate");
            db.AddInParameter(commandUpdate, "@GuestTypeId", DbType.Int32, "GuestTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@GuestTypeName", DbType.String, "GuestTypeName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@GuestTypeDescription", DbType.String, "GuestTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_GuestTypeDelete");
            db.AddInParameter(commandDelete, "@GuestTypeId", DbType.Int32, "GuestTypeId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(GuestType guestType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuestTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, guestType.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

        public bool IsDuplicateTypeName(GuestType guestType)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("GuestTypeIsDuplicateTypeName");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, guestType.CompanyId);
            db.AddInParameter(dbCommand, "@GuestTypeId", DbType.Int32, guestType.GuestTypeId);
            db.AddInParameter(dbCommand, "@GuestTypeName", DbType.String, guestType.GuestTypeName);
            db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

            db.ExecuteNonQuery(dbCommand);

            result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            return result;
        }


    }
}

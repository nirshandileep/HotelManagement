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
    public class TaxTypeDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_TaxTypeInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@TaxTypeName", DbType.String, "TaxTypeName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Note", DbType.String, "Note", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@TaxPercentage", DbType.Decimal, "TaxPercentage", DataRowVersion.Current);

            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_TaxTypeUpdate");
            db.AddInParameter(commandUpdate, "@TaxTypeId", DbType.Int32, "TaxTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@TaxTypeName", DbType.String, "TaxTypeName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Note", DbType.String, "Note", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@TaxPercentage", DbType.Decimal, "TaxPercentage", DataRowVersion.Current);

            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_TaxTypeDelete");
            db.AddInParameter(commandDelete, "@TaxTypeId", DbType.Int32, "TaxTypeId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(TaxType taxType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaxTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, taxType.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

        public bool IsDuplicateTypeName(TaxType taxType)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaxTypeIsDuplicateTypeName");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, taxType.CompanyId);
            db.AddInParameter(dbCommand, "@TaxTypeId", DbType.Int32, taxType.TaxTypeId);
            db.AddInParameter(dbCommand, "@TaxTypeName", DbType.String, taxType.TaxTypeName);
            db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

            db.ExecuteNonQuery(dbCommand);

            result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            return result;
        }

    }
}

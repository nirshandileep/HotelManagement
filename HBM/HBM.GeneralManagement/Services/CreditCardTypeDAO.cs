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
    public class CreditCardTypeDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_CreditCardTypeInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Name", DbType.String, "Name", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ProcessingFee", DbType.Decimal, "ProcessingFee", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_CreditCardTypeUpdate");
            db.AddInParameter(commandUpdate, "@CreditCardTypeId", DbType.Int32, "CreditCardTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Name", DbType.String, "Name", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ProcessingFee", DbType.Decimal, "ProcessingFee", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_CreditCardTypeDelete");
            db.AddInParameter(commandDelete, "@CreditCardTypeId", DbType.Int32, "CreditCardTypeId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        public DataSet SelectAll(CreditCardType creditCardType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CreditCardTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, creditCardType.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

    }
}

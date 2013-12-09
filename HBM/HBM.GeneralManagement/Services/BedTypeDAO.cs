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
    public class BedTypeDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_BedTypeInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@BedTypeName", DbType.String,  "BedTypeName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@BedTypeDescription", DbType.String, "BedTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32,"CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            
            DbCommand commandUpdate = db.GetStoredProcCommand("usp_BedTypeUpdate");
            db.AddInParameter(commandUpdate, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@BedTypeName", DbType.String, "BedTypeName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@BedTypeDescription", DbType.String, "BedTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32,"StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_BedTypeDelete");
            db.AddInParameter(commandDelete, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);

             db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete,UpdateBehavior.Transactional);

            return true;
        }

        public bool Insert(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, bedType.CompanyId);
            db.AddInParameter(command, "@BedTypeName", DbType.String, bedType.BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, bedType.BedTypeDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, bedType.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, bedType.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, bedType.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, bedType.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, bedType.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeUpdate");

            db.AddInParameter(command, "@BedTypeId", DbType.Int32, bedType.BedTypeId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, bedType.CompanyId);
            db.AddInParameter(command, "@BedTypeName", DbType.String, bedType.BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, bedType.BedTypeDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, bedType.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, bedType.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, bedType.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, bedType.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, bedType.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeDelete");

            db.AddInParameter(command, "@BedTypeId", DbType.Int32, bedType.BedTypeId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BedTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, bedType.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

        public bool IsDuplicateTypeName(BedType bedType)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BedTypeIsDuplicateTypeName");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, bedType.CompanyId);
            db.AddInParameter(dbCommand, "@BedTypeId", DbType.Int32, bedType.BedTypeId);
            db.AddInParameter(dbCommand, "@BedTypeName", DbType.String, bedType.BedTypeName);
            db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

            db.ExecuteNonQuery(dbCommand);

            result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            return result;
        }

    }
}

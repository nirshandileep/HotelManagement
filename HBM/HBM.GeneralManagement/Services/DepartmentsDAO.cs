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
    public class DepartmentsDAO
    {
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_DepartmentInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@DepartmentName", DbType.String, "DepartmentName", DataRowVersion.Current);            
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_DepartmentUpdate");
            db.AddInParameter(commandUpdate, "@DepartmentId", DbType.Int32, "DepartmentId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@DepartmentName", DbType.String, "DepartmentName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_DepartmentDelete");
            db.AddInParameter(commandDelete, "@DepartmentId", DbType.Int32, "DepartmentId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }


        public bool Insert(Department department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, department.CompanyId);
            db.AddInParameter(command, "@DepartmentName", DbType.String, department.DepartmentName);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, department.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, department.CreatedDate);            

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Department department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentUpdate");

            db.AddInParameter(command, "@DepartmentId", DbType.Int32, department.DepartmentId);     
            db.AddInParameter(command, "@CompanyId", DbType.Int32, department.CompanyId);
            db.AddInParameter(command, "@DepartmentName", DbType.String, department.DepartmentName);            
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, department.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, department.UpdatedDate);            

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Department department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentDelete");

            db.AddInParameter(command, "@DepartmentId", DbType.Int32, department.DepartmentId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Department department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DepartmentSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, department.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

    }
}

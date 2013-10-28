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
        public bool Insert(Departments department)
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

        public bool Update(Departments department)
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

        public bool Delete(Departments department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentDelete");

            db.AddInParameter(command, "@DepartmentId", DbType.Int32, department.DepartmentId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Departments department)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BedTypeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, department.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }

    }
}

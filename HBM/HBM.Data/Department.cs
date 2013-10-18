using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using HBM.Common;

namespace HBM.Data
{
    public class Department
    {
        #region Properties

        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Insert()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@DepartmentName", DbType.String, DepartmentName);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentUpdate");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@DepartmentId", DbType.Int32, DepartmentId);
            db.AddInParameter(command, "@DepartmentName", DbType.String, DepartmentName);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_DepartmentDelete");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@DepartmentId", DbType.Int32, DepartmentId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DepartmentSelect");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);

            return db.ExecuteDataSet(dbCommand);

        }

        #endregion
    }
}

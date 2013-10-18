using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.CompanyManagement
{
    public class CompanyDAO
    {
        public bool Insert(Company company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CompanyInsert");

            db.AddInParameter(command, "@CompanyName", DbType.String, company.CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, company.CompanyAddress);
            db.AddInParameter(command, "@CompanyCity", DbType.String, company.CompanyCity);
            db.AddInParameter(command, "@CompanyEmail", DbType.String, company.CompanyEmail);
            db.AddInParameter(command, "@CompanyTelephone", DbType.String, company.CompanyTelephone);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, company.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, company.CreatedDate);            
            db.AddInParameter(command, "@StatusId", DbType.Int32, company.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Company company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CompanyUpdate");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, company.CompanyId);
            db.AddInParameter(command, "@CompanyName", DbType.String, company.CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, company.CompanyAddress);
            db.AddInParameter(command, "@CompanyCity", DbType.String, company.CompanyCity);
            db.AddInParameter(command, "@CompanyEmail", DbType.String, company.CompanyEmail);
            db.AddInParameter(command, "@CompanyTelephone", DbType.String, company.CompanyTelephone);            
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, company.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, company.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, company.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Company company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CompanyDelete");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, company.CompanyId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Company company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CompanySelectAll");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, company.CompanyId);

            return db.ExecuteDataSet(command);
        }

    }

}

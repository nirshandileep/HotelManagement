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
        #region Methods

        public bool Insert(Company company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CompanyInsert");

            db.AddInParameter(command, "@CompanyName", DbType.String, company.CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, company.CompanyAddress);
            db.AddInParameter(command, "@CompanyCity", DbType.String, company.CompanyCity);
            db.AddInParameter(command, "@CompanyEmail", DbType.String, company.CompanyEmail);
            db.AddInParameter(command, "@CompanyTelephone", DbType.String, company.CompanyTelephone);
            db.AddInParameter(command, "@CompanyTypeId", DbType.Int32, company.CompanyTypeId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, company.CreatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, company.StatusId);
            db.AddInParameter(command, "@CompanyFax", DbType.String, company.CompanyFax);
            db.AddInParameter(command, "@CompanyLogo", DbType.Binary, company.CompanyLogo);
            db.AddInParameter(command, "@WebURL", DbType.String, company.WebURL);
            db.AddInParameter(command, "@RegistrationNo", DbType.String, company.RegistrationNo);
            db.AddInParameter(command, "@VATNo", DbType.String, company.VATNo);
            db.AddInParameter(command, "@AdditionalDetails1", DbType.String, company.AdditionalDetails1);
            db.AddInParameter(command, "@AdditionalDetails2", DbType.String, company.AdditionalDetails2);

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
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, company.UpdatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, company.StatusId);
            db.AddInParameter(command, "@CompanyFax", DbType.String, company.CompanyFax);
            db.AddInParameter(command, "@CompanyLogo", DbType.Binary, company.CompanyLogo);
            db.AddInParameter(command, "@WebURL", DbType.String, company.WebURL);
            db.AddInParameter(command, "@RegistrationNo", DbType.String, company.RegistrationNo);
            db.AddInParameter(command, "@VATNo", DbType.String, company.VATNo);
            db.AddInParameter(command, "@AdditionalDetails1", DbType.String, company.AdditionalDetails1);
            db.AddInParameter(command, "@AdditionalDetails2", DbType.String, company.AdditionalDetails2);

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
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CompanySelectAll");

            return db.ExecuteDataSet(dbCommand);

        }       

        #endregion

    }

}

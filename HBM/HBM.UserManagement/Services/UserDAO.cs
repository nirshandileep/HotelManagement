using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.UserManagement
{
    public class UserDAO
    {
        public bool Insert(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_UsersInsert");

            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, users.CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, users.CreatedDate);            
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_UsersUpdate");

            db.AddInParameter(command, "@UserId", DbType.String, users.UserId);
            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, users.UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, users.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_UsersDelete");

            db.AddInParameter(command, "@UserId", DbType.String, users.UserId);            
            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Users users)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsersSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.String, users.CompanyId);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}

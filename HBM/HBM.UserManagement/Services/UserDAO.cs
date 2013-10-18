using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace HBM.UserManagement
{
    public class UserDAO
    {
        public bool Insert(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, users.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, users.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, users.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, users.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@UserId", DbType.String, users.UserId);
            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, users.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, users.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, users.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, users.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@UserId", DbType.String, users.UserId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@UserId", DbType.String, users.UserId);
            return db.ExecuteDataSet(dbCommand);


        }
    }
}

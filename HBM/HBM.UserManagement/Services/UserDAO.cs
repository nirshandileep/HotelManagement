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
            db.AddInParameter(command, "@Password", DbType.String, users.Password.GetHashCode());
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, users.CreatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);
            db.AddInParameter(command, "@RolesId", DbType.Int32, users.RolesId);
            db.AddInParameter(command, "@DepartmentId", DbType.Int32, users.DepartmentId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, users.CompanyId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_UsersUpdate");

            db.AddInParameter(command, "@UsersId", DbType.String, users.UsersId);
            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password.GetHashCode());
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, users.UpdatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, users.StatusId);
            db.AddInParameter(command, "@RolesId", DbType.Int32, users.RolesId);
            db.AddInParameter(command, "@DepartmentId", DbType.Int32, users.DepartmentId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, users.CompanyId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Users users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_UsersDelete");

            db.AddInParameter(command, "@UsersId", DbType.String, users.UsersId);
            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Users users)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsersSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, users.CompanyId);
            return db.ExecuteDataSet(dbCommand);
        }

        public bool IsUserAuthenticated(string userName, string password, out int UsersId, out int compnayId)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UsersIsAuthenticated");

                db.AddInParameter(dbCommand, "@UserName", DbType.String, userName);
                db.AddInParameter(dbCommand, "@Password", DbType.String, password.GetHashCode());
                db.AddOutParameter(dbCommand, "@UsersId", DbType.Int32, 8);
                db.AddOutParameter(dbCommand, "@CompanyId", DbType.Int32, 8);

                db.ExecuteNonQuery(dbCommand);

                UsersId = Convert.ToInt32(db.GetParameterValue(dbCommand, "@UsersId").ToString());
                compnayId = Convert.ToInt32(db.GetParameterValue(dbCommand, "@CompanyId").ToString());

                if (UsersId > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception)
            {
                UsersId = 0;
                compnayId = 0;

            }

            return result;



        }

        public bool IsUserIsDuplicateUserName(string userName, int compnayId)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UsersIsDuplicateUserName");

                db.AddInParameter(dbCommand, "@UserName", DbType.String, userName);
                db.AddInParameter(dbCommand, "@CompanyId", DbType.String, compnayId);
                db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

                db.ExecuteNonQuery(dbCommand);

                result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());
                

            }
            catch (Exception)
            {
                result = false;
            }

            return result;



        }

        public bool IsDuplicateEmail(string email, int compnayId)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UsersIsDuplicateEmail");

                db.AddInParameter(dbCommand, "@EmailAddress", DbType.String, email);
                db.AddInParameter(dbCommand, "@CompanyId", DbType.String, compnayId);
                db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

                db.ExecuteNonQuery(dbCommand);

                result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());


            }
            catch (Exception)
            {
                result = false;
            }

            return result;



        }


    }
}

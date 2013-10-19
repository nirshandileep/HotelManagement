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
    public class RolesDAO
    {
        public bool Insert(Roles roles, Database db, DbTransaction transaction)
        {            
            DbCommand command = db.GetStoredProcCommand("usp_RolesInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, roles.CompanyId);
            db.AddInParameter(command, "@RoleName", DbType.String, roles.RoleName);
            db.AddInParameter(command, "@RoleDescription", DbType.String, roles.RoleDescription);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, roles.CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, roles.CreatedDate);
            
            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Roles roles, Database db, DbTransaction transaction)
        {           
            DbCommand command = db.GetStoredProcCommand("usp_RolesUpdate");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, roles.CompanyId);
            db.AddInParameter(command, "@RoleName", DbType.String, roles.RoleName);
            db.AddInParameter(command, "@RoleDescription", DbType.String, roles.RoleDescription);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, roles.UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, roles.UpdatedDate);
            
            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Roles roles)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RolesDelete");

            db.AddInParameter(command, "@RoleId", DbType.String, roles.RoleId);
            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Roles roles)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RolesSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.String, roles.CompanyId);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}

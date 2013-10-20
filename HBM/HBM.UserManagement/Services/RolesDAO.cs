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
            db.AddOutParameter(command, "@RoleId", DbType.Int32, 8);

            db.ExecuteNonQuery(command, transaction);

            roles.RoleId = Convert.ToInt32(db.GetParameterValue(command, "@RoleId").ToString());

            return true;
        }

        public bool Update(Roles roles, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_RolesUpdate");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, roles.CompanyId);
            db.AddInParameter(command, "@RoleName", DbType.String, roles.RoleName);
            db.AddInParameter(command, "@RoleDescription", DbType.String, roles.RoleDescription);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, roles.UpdatedUser);

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
            //db.AddInParameter(dbCommand, "@CompanyId", DbType.String, roles.CompanyId);
            return db.ExecuteDataSet(dbCommand);
        }

        public bool InsertRoleRights(Roles roles, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_RoleRightsInsert");
                        
            db.AddInParameter(command, "@RoleId", DbType.String, roles.RoleId);
            db.AddInParameter(command, "@RightId", DbType.String, roles.RightId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, roles.CreatedUser);
            
            db.ExecuteNonQuery(command, transaction);
            
            return true;
        }

    }
}

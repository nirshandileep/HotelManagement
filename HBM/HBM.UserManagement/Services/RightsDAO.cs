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
    public class RightsDAO
    {
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RightsSelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet SelectByRolesId(Rights rights)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RightsSelectByRolesId");
            db.AddInParameter(dbCommand, "@RolesId", DbType.Int32, rights.RolesId);
            return db.ExecuteDataSet(dbCommand);
        }


      

    }
}

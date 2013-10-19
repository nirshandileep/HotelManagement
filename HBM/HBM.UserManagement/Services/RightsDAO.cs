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
    }
}

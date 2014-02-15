using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.GeneralManagement
{
    public class StatusDAO
    {
        public DataSet SelectByModule(string moduleName)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StatusSelectByModule");
            db.AddInParameter(dbCommand, "@Module", DbType.String, moduleName);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

namespace HBM.Reporting
{
    public class ReportsDAO
    {
        public Dictionary<int, string> GetReportTypes()
        {
            Dictionary<int, string> dictionary = new Dictionary<int,string>();
            dictionary.Add(0, "Customer List");
            dictionary.Add(1, "Reservation List");
            dictionary.Add(2, "Reservation Payment");
            dictionary.Add(3, "Dirty Room List");

            return dictionary;
        }

        public DataSet GetCustomerList(int companyID)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_ReportsCustomerList");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, companyID);

            return db.ExecuteDataSet(command);
        }
    }
}

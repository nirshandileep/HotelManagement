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
            dictionary.Add(0, "Guest Report");
            dictionary.Add(1, "Reservation Report");
            dictionary.Add(2, "Reservation Payment Report");            
            dictionary.Add(3, "Dirty Room Report");
            dictionary.Add(4, "Reservation Services Report");
            dictionary.Add(5, "Rooms Report");
            dictionary.Add(6, "Occupancy Report");
                        
            return dictionary;
        }

        public DataSet GetCustomerList(int companyID)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_ReportsCustomerList");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, companyID);

            return db.ExecuteDataSet(command);
        }

        public DataSet GetReservationList(int companyID)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_ReportsReservationList");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, companyID);

            return db.ExecuteDataSet(command);
        }

    }
}

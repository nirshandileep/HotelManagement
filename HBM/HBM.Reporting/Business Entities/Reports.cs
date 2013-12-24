using System.Collections.Generic;
using System.Data;

namespace HBM.Reporting
{
    public class Reports
    {
        public Dictionary<int, string> GetReportTypes()
        {
            return (new ReportsDAO()).GetReportTypes();
        }

        public DataSet GetCustomerList(int companyID)
        {
            return (new ReportsDAO()).GetCustomerList(companyID);
        }

        public DataSet GetReservationList(int companyID)
        {
            return (new ReportsDAO()).GetReservationList(companyID);
        }
    }
}

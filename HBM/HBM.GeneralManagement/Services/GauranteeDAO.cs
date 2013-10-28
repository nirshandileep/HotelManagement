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
    public class GauranteeDAO
    {
        public bool Insert(Gaurantee gaurantee)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_GuaranteeInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, gaurantee.CompanyId);
            db.AddInParameter(command, "@GuaranteeName", DbType.String, gaurantee.GuaranteeName);
            db.AddInParameter(command, "@GuaranteeDescription", DbType.String, gaurantee.GuaranteeDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, gaurantee.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, gaurantee.CreatedDate);
            
            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Gaurantee gaurantee)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_GuaranteeUpdate");

            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, gaurantee.GuaranteeId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, gaurantee.CompanyId);
            db.AddInParameter(command, "@GuaranteeName", DbType.String, gaurantee.GuaranteeName);
            db.AddInParameter(command, "@GuaranteeDescription", DbType.String, gaurantee.GuaranteeDescription);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, gaurantee.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, gaurantee.UpdatedDate);
            

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Gaurantee gaurantee)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_GuaranteeDelete");

            db.AddInParameter(command, "@GuaranteeId", DbType.Int32, gaurantee.GuaranteeId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Gaurantee gaurantee)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuaranteeSelectAll");
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, gaurantee.CompanyId);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

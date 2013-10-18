using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using HBM.Common;

namespace HBM.Data
{
    public class AdditionalService
    {
        #region Properties

        public int CompanyId { get; set; }
        public int AdditionalServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public int AdditionalServiceTypeId { get; set; }
        public decimal Rate { get; set; }   
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Insert()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_AdditionalServiceInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ServiceName", DbType.String, ServiceName);
            db.AddInParameter(command, "@ServiceCode", DbType.String, ServiceCode);  
            db.AddInParameter(command, "@Rate", DbType.Decimal, Rate);
            db.AddInParameter(command, "@AdditionalServiceTypeId", DbType.String, AdditionalServiceTypeId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_AdditionalServiceUpdate");

            db.AddInParameter(command, "@AdditionalServiceId", DbType.Int32, AdditionalServiceId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@ServiceName", DbType.String, ServiceName);
            db.AddInParameter(command, "@ServiceCode", DbType.String, ServiceCode);
            db.AddInParameter(command, "@Rate", DbType.Decimal, Rate);
            db.AddInParameter(command, "@AdditionalServiceTypeId", DbType.String, AdditionalServiceTypeId);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_AdditionalServiceDelete");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@AdditionalServiceId", DbType.Int32, AdditionalServiceId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll()
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AdditionalServiceSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);            

            return db.ExecuteDataSet(dbCommand);                      

        }

        #endregion
    }
}

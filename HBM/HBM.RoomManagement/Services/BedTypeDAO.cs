using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;


namespace HBM.RoomManagement
{
    public class BedTypeDAO
    {


        public bool Insert(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, bedType.CompanyId);
            db.AddInParameter(command, "@BedTypeName", DbType.String, bedType.BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, bedType.BedTypeDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, bedType.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, bedType.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, bedType.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, bedType.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, bedType.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeUpdate");

            db.AddInParameter(command, "@BedTypeId", DbType.Int32, bedType.BedTypeId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, bedType.CompanyId);
            db.AddInParameter(command, "@BedTypeName", DbType.String, bedType.BedTypeName);
            db.AddInParameter(command, "@BedTypeDescription", DbType.String, bedType.BedTypeDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, bedType.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, bedType.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, bedType.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, bedType.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, bedType.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_BedTypeDelete");
            
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, bedType.BedTypeId);
            
            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(BedType bedType)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BedTypeSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, bedType.CompanyId);            

            return db.ExecuteDataSet(dbCommand);


        }


    }
}

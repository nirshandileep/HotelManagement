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
    public class RoomDAO
    {

        public bool Insert(Room room)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, room.CompanyId);
            db.AddInParameter(command, "@RoomName", DbType.String, room.RoomName);
            db.AddInParameter(command, "@RoomNumber", DbType.String, room.RoomNumber);
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, room.BedTypeId);
            db.AddInParameter(command, "@MaxAdult", DbType.Int32, room.MaxAdult);
            db.AddInParameter(command, "@MaxChildren", DbType.Int32, room.MaxChildren);
            db.AddInParameter(command, "@MaxInfant", DbType.Int32, room.MaxInfant);
            db.AddInParameter(command, "@SmokingAllow", DbType.Boolean, room.SmokingAllow);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, room.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, room.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, room.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, room.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, room.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Room room)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomUpdate");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, room.CompanyId);
            db.AddInParameter(command, "@RoomId", DbType.Int32, room.RoomId);
            db.AddInParameter(command, "@RoomName", DbType.String, room.RoomName);
            db.AddInParameter(command, "@RoomNumber", DbType.String, room.RoomNumber);
            db.AddInParameter(command, "@BedTypeId", DbType.Int32, room.BedTypeId);
            db.AddInParameter(command, "@MaxAdult", DbType.Int32, room.MaxAdult);
            db.AddInParameter(command, "@MaxChildren", DbType.Int32, room.MaxChildren);
            db.AddInParameter(command, "@MaxInfant", DbType.Int32, room.MaxInfant);
            db.AddInParameter(command, "@SmokingAllow", DbType.Boolean, room.SmokingAllow);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, room.CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, room.CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, room.UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, room.UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, room.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Room room)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomDelete");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, room.CompanyId);
            db.AddInParameter(command, "@RoomId", DbType.Int32, room.RoomId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Room room)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RoomSelectAll");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, room.CompanyId);

            return db.ExecuteDataSet(dbCommand);

        }

    }
}

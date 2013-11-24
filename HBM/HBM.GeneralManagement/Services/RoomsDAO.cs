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
        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_RoomInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RoomName", DbType.String, "RoomName",DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RoomCode", DbType.String, "RoomCode", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RoomNumber", DbType.String, "RoomNumber",DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@MaxAdult", DbType.Int32, "MaxAdult", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@MaxChildren", DbType.Int32, "MaxChildren", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@MaxInfant", DbType.Int32, "MaxInfant",DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@SmokingAllow", DbType.Boolean, "SmokingAllow",DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser",DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId",DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_RoomUpdate");

            db.AddInParameter(commandUpdate, "@RoomId", DbType.Int32, "RoomId", DataRowVersion.Current);          
            db.AddInParameter(commandUpdate, "@RoomName", DbType.String, "RoomName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@RoomNumber", DbType.String, "RoomNumber", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@RoomCode", DbType.String, "RoomCode", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@MaxAdult", DbType.Int32, "MaxAdult", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@MaxChildren", DbType.Int32, "MaxChildren", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@MaxInfant", DbType.Int32, "MaxInfant", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@SmokingAllow", DbType.Boolean, "SmokingAllow", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            
            DbCommand commandDelete = db.GetStoredProcCommand("usp_RoomDelete");
            db.AddInParameter(commandDelete, "@RoomId", DbType.Int32, "RoomId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }


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

        public DataSet SelectAllDirtyRooms(int Company)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dashboard_Room_DirtySelect");

            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, Company);

            return db.ExecuteDataSet(dbCommand);

        }

        public bool DashboardUpdateDirtyRooms(DataSet dsDirtyRooms)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandUpdate = db.GetStoredProcCommand("usp_Dashboard_RoomDirtyUpdate");

            db.AddInParameter(commandUpdate, "@RoomId", DbType.Int32, "RoomId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@IsDirty", DbType.Boolean, "IsDirty", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CleaningNote", DbType.String, "CleaningNote", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CleanedBy", DbType.Int32, "CleanedBy", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CleanedDate", DbType.DateTime, "CleanedDate", DataRowVersion.Current);

            db.UpdateDataSet(dsDirtyRooms, dsDirtyRooms.Tables[0].TableName, null, commandUpdate, null, UpdateBehavior.Transactional);

            return true;
        }

        public bool UpdateRoomAsDirty(Room room)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomMarkDirty");

            db.AddInParameter(command, "@RoomId", DbType.Int32, room.RoomId);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, room.UpdatedBy);

            db.ExecuteNonQuery(command);

            return true;
        }

    }
}

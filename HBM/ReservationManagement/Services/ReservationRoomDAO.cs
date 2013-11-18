using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;
namespace HBM.ReservationManagement
{
    public class ReservationRoomDAO
    {
        public bool InsertUpdateDelete(DataSet ds, Database db, DbTransaction transaction)
        {          
            DbCommand commandInsert = db.GetStoredProcCommand("usp_ReservationRoomInsert");

            db.AddInParameter(commandInsert, "@ReservationId", DbType.Int32, "ReservationId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RoomId", DbType.Int32, "RoomId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@RoomRatePlanId", DbType.Int32, "RoomRatePlanId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Sharers", DbType.String, "Sharers", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CheckInDate", DbType.DateTime, "CheckInDate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CheckOutDate", DbType.DateTime, "CheckOutDate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@NumberOfAdults", DbType.Int32, "NumberOfAdults", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@NumberOfChildren", DbType.Int32, "NumberOfChildren", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@NumberOfInfant", DbType.Int32, "NumberOfInfant", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Days", DbType.Decimal, "Days", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Amount", DbType.Decimal, "Amount", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Decimal, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_ReservationRoomUpdate");

            db.AddInParameter(commandUpdate, "@ReservationReservationId", DbType.Int32, "ReservationReservationId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@RoomId", DbType.Int32, "RoomId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@RoomRatePlanId", DbType.Int32, "RoomRatePlanId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Sharers", DbType.String, "Sharers", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CheckInDate", DbType.DateTime, "CheckInDate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CheckOutDate", DbType.DateTime, "CheckOutDate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@NumberOfAdults", DbType.Int32, "NumberOfAdults", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@NumberOfChildren", DbType.Int32, "NumberOfChildren", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@NumberOfInfant", DbType.Int32, "NumberOfInfant", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Days", DbType.Decimal, "Days", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Amount", DbType.Decimal, "Amount", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_ReservationRoomDelete");
            db.AddInParameter(commandDelete, "@ReservationReservationId", DbType.Int32, "ReservationReservationId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, transaction);

            return true;
        }

        public DataSet SelectByReseervationId(ReservationRoom reservationRoom)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationRoomSelectByReservationId");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservationRoom.ReservationId);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

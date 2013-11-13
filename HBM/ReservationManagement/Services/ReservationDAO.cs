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
    public class ReservationDAO
    {
        internal System.Data.DataSet SelectAll(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_AdditionalServiceInsert");
            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceName", DbType.String, "ServiceName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@ServiceCode", DbType.String, "ServiceCode", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_AdditionalServiceUpdate");
            db.AddInParameter(commandUpdate, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceName", DbType.String, "ServiceName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@ServiceCode", DbType.String, "ServiceCode", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalServiceTypeId", DbType.Int32, "AdditionalServiceTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Rate", DbType.Decimal, "Rate", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_AdditionalServiceDelete");
            db.AddInParameter(commandDelete, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }

        internal bool Delete(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        internal bool Insert(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        internal bool Update(Reservation reservation)
        {
            throw new NotImplementedException();
        }



        internal DataSet SelectReservationGuests(Reservation reservation)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationGuests_SelectByReservationId");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservation.ReservationId);
            return db.ExecuteDataSet(dbCommand);
        }

        internal DataSet SelectReservationAdditionalServices(Reservation reservation)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationAdditionalServiceSelectByReservationID");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservation.ReservationId);
            return db.ExecuteDataSet(dbCommand);
        }

        internal DataSet SelectReservationPayments(Reservation reservation)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationReservationPayments_SelectByReservationId");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservation.ReservationId);
            return db.ExecuteDataSet(dbCommand);
        }

        internal DataSet SelectReservationRooms(Reservation reservation)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationReservationRooms_SelectByReservationId");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservation.ReservationId);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}

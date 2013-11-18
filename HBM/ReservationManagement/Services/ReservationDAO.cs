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

        public bool Insert(Reservation reservation, Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("usp_ReservationInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, reservation.CompanyId);
            db.AddInParameter(command, "@CustomerId", DbType.Int32, reservation.CustomerId);
            db.AddInParameter(command, "@StatusId", DbType.Int32, reservation.StatusId);
            db.AddInParameter(command, "@BookingDate", DbType.DateTime, reservation.BookingDate);
            db.AddInParameter(command, "@CheckInDate", DbType.DateTime, reservation.CheckInDate);
            db.AddInParameter(command, "@CheckOutDate", DbType.DateTime, reservation.CheckOutDate);
            db.AddInParameter(command, "@SourceId", DbType.Int32, reservation.SourceId);
            db.AddInParameter(command, "@RoomTotal", DbType.Decimal, reservation.RoomTotal);
            db.AddInParameter(command, "@ServiceTotal", DbType.Decimal, reservation.ServiceTotal);
            db.AddInParameter(command, "@NetTotal", DbType.Decimal, reservation.NetTotal);
            db.AddInParameter(command, "@Discount", DbType.Decimal, reservation.Discount);
            db.AddInParameter(command, "@TaxAmount", DbType.Decimal, reservation.TaxAmount);
            db.AddInParameter(command, "@PaidAmount", DbType.Decimal, reservation.PaidAmount);
            db.AddInParameter(command, "@Total", DbType.Decimal, reservation.Total);
            db.AddInParameter(command, "@Balance", DbType.Decimal, reservation.Balance);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, reservation.CreatedUser);
            db.AddInParameter(command, "@TaxTypeId", DbType.Int32, reservation.TaxTypeId);          

            db.ExecuteNonQuery(command);

            ReservationRoom reservationRoom = new ReservationRoom();
            reservationRoom.Save(reservation.ReservationRoomDataSet, db, transaction);


            ReservationAdditionalService reservationAddtionalService = new ReservationAdditionalService();
            reservationAddtionalService.Save(reservation.ReservationAdditionalServiceDataSet, db, transaction);

            ReservationPayments reservationPayments = new ReservationPayments();
            reservationPayments.Save(reservation.ReservationPaymentDataSet, db, transaction);

            return true;
        }

        public bool Update(Reservation reservation, Database db, DbTransaction transaction)
        {

            DbCommand command = db.GetStoredProcCommand("usp_ReservationUpdate");

            db.AddInParameter(command, "@ReservationId", DbType.Int32, reservation.ReservationId);            
            db.AddInParameter(command, "@CompanyId", DbType.Int32, reservation.CompanyId);
            db.AddInParameter(command, "@CustomerId", DbType.Int32, reservation.CustomerId);
            db.AddInParameter(command, "@StatusId", DbType.Int32, reservation.StatusId);
            db.AddInParameter(command, "@BookingDate", DbType.DateTime, reservation.BookingDate);
            db.AddInParameter(command, "@CheckInDate", DbType.DateTime, reservation.CheckInDate);
            db.AddInParameter(command, "@CheckOutDate", DbType.DateTime, reservation.CheckOutDate);
            db.AddInParameter(command, "@SourceId", DbType.Int32, reservation.SourceId);
            db.AddInParameter(command, "@RoomTotal", DbType.Decimal, reservation.RoomTotal);
            db.AddInParameter(command, "@ServiceTotal", DbType.Decimal, reservation.ServiceTotal);
            db.AddInParameter(command, "@NetTotal", DbType.Decimal, reservation.NetTotal);
            db.AddInParameter(command, "@Discount", DbType.Decimal, reservation.Discount);
            db.AddInParameter(command, "@TaxAmount", DbType.Decimal, reservation.TaxAmount);
            db.AddInParameter(command, "@PaidAmount", DbType.Decimal, reservation.PaidAmount);
            db.AddInParameter(command, "@Total", DbType.Decimal, reservation.Total);
            db.AddInParameter(command, "@Balance", DbType.Decimal, reservation.Balance);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, reservation.CreatedUser);
            db.AddInParameter(command, "@TaxTypeId", DbType.Int32, reservation.TaxTypeId);

            db.ExecuteNonQuery(command);

            return true;
        }
        
        ////

    

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

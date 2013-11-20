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
    public class ReservationAdditionalServiceDAO
    {
        public bool InsertUpdateDelete(ReservationAdditionalService reservationAddtionalService, Database db, DbTransaction transaction)
        {         
            DbCommand commandInsert = db.GetStoredProcCommand("usp_ReservationAdditionalServiceInsert");

            db.AddInParameter(commandInsert, "@ReservationId", DbType.Int64,reservationAddtionalService.ReservationId);
            db.AddInParameter(commandInsert, "@Note", DbType.String, "Note", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Amount", DbType.Decimal, "Amount", DataRowVersion.Current);            
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);
                        

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_ReservationAdditionalServiceUpdate");

            db.AddInParameter(commandUpdate, "@ReservationAdditionalServiceId", DbType.Int32, "ReservationAdditionalServiceId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Note", DbType.String, "Note", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Amount", DbType.String, "Amount", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@AdditionalServiceId", DbType.Int32, "AdditionalServiceId", DataRowVersion.Current);


            DbCommand commandDelete = db.GetStoredProcCommand("usp_ReservationAdditionalServiceDelete");
            db.AddInParameter(commandDelete, "@ReservationAdditionalServiceId", DbType.Int64, "ReservationAdditionalServiceId", DataRowVersion.Current);

            db.UpdateDataSet(reservationAddtionalService.ReservationAdditionalServiceList, reservationAddtionalService.ReservationAdditionalServiceList.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, transaction);

            return true;
        }

        public DataSet SelectByReservationID(ReservationAdditionalService reservationAdditionalService)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservationAdditionalServiceSelectByReservationID");
            db.AddInParameter(dbCommand, "@ReservationId", DbType.Int32, reservationAdditionalService.ReservationId);

            return db.ExecuteDataSet(dbCommand);


        }
    }
}

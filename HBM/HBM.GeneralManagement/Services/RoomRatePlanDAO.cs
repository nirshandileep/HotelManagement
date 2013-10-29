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
    public class RoomRatePlanDAO
    {

        public bool InsertUpdateDelete(DataSet ds)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand commandInsert = db.GetStoredProcCommand("usp_RoomRatePlanInsert");

            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, "CompanyId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@BedTypeName", DbType.String, "BedTypeName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@BedTypeDescription", DbType.String, "BedTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_RoomRatePlanUpdate");
            db.AddInParameter(commandUpdate, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@BedTypeName", DbType.String, "BedTypeName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@BedTypeDescription", DbType.String, "BedTypeDescription", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, "StatusId", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_RoomRatePlanDelete");
            db.AddInParameter(commandDelete, "@BedTypeId", DbType.Int32, "BedTypeId", DataRowVersion.Current);

            db.UpdateDataSet(ds, ds.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, UpdateBehavior.Transactional);

            return true;
        }


        public bool Insert(RoomRatePlan roomRatePlan)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomRatePlanInsert");

            db.AddInParameter(command, "@RoomId", DbType.Int32, roomRatePlan.RoomId);
            db.AddInParameter(command, "@RatePlanId", DbType.Int32, roomRatePlan.RatePlanId);
            db.AddInParameter(command, "@Note", DbType.String, roomRatePlan.Note);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, roomRatePlan.CreatedUser);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, roomRatePlan.CreatedDate);


            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(RoomRatePlan roomRatePlan)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomRatePlanUpdate");

            db.AddInParameter(command, "@RoomRatePlanId", DbType.Int32, roomRatePlan.RoomRatePlanId);
            db.AddInParameter(command, "@RoomId", DbType.Int32, roomRatePlan.RoomId);
            db.AddInParameter(command, "@RatePlanId", DbType.Int32, roomRatePlan.RatePlanId);
            db.AddInParameter(command, "@Note", DbType.String, roomRatePlan.Note);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, roomRatePlan.UpdatedUser);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, roomRatePlan.UpdatedDate);


            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(RoomRatePlan roomRatePlan)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_RoomRatePlanDelete");

            db.AddInParameter(command, "@RoomRatePlanId", DbType.Int32, roomRatePlan.RoomRatePlanId);

            db.ExecuteNonQuery(command);

            return true;
        }

    }
}

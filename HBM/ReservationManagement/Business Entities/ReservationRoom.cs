using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBM.GeneralManagement;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace HBM.ReservationManagement
{
    [Serializable]
    public class ReservationRoom
    {
        #region Properties

        public int ReservationRoomId { get; set; }
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int RoomRatePlanId { get; set; }
        public string Sharers { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfant { get; set; }
        public decimal Days { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DataSet ReservationRoomList { get; set; }


        #endregion

        #region Methods

        public bool Save(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new ReservationRoomDAO()).InsertUpdateDelete(this, db, transaction);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public DataSet SelectAllDataSetByReseervationId()
        {
            return (new ReservationRoomDAO()).SelectByReseervationId(this);
        }

        public ReservationRoom Select()
        {
            return HBM.Utility.Generic.Get<ReservationRoom>(this.ReservationRoomId);
        }


        #endregion
    }
}

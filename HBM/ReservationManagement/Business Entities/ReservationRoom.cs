using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBM.GeneralManagement;


namespace HBM.ReservationManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>
    [Serializable]
    public class ReservationRoom
    {
        public int ReservationId { get; set; }
        /// <summary>
        /// This is not the Room Id, but Reservation Room Id
        /// </summary>
        public int ReservationRoomId { get; set; }
        public int RoomRatePlanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfant { get; set; }
        public int StatusId { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public RoomRatePlan RoomRatePlan { get; set; }

        public ReservationRoom Select()
        {
            return HBM.Utility.Generic.Get<ReservationRoom>(this.ReservationRoomId);
        }
    }
}

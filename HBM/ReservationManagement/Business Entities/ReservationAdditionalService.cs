using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.ReservationManagement
{
    public class ReservationAdditionalService
    {
        #region Properties

        public int ReservationAdditionalServiceId { get; set; }
        public int ReservationId { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
        public int AdditionalServiceId { get; set; }        

        #endregion

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new ReservationAdditionalServiceDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public DataSet SelectAllDataSetByReservationID()
        {
            return (new ReservationAdditionalServiceDAO()).SelectByReservationID(this);
        }


    }
}

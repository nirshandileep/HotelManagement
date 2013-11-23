using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace HBM.ReservationManagement
{
    public class ReservationAdditionalService
    {
        #region Properties

        public int ReservationAdditionalServiceId { get; set; }
        public Int64 ReservationId { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AdditionalServiceId { get; set; }
        public DataSet ReservationAdditionalServiceList { get; set; }

        #endregion

        #region Methods

        public bool Save( Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new ReservationAdditionalServiceDAO()).InsertUpdateDelete(this, db, transaction);
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

        #endregion
    }
}

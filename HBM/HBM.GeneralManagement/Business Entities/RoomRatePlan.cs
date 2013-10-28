using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class RoomRatePlan
    {
        #region Properties

        public int RoomRatePlanId { get; set; }
        public int RoomId { get; set; }
        public int RatePlanId { get; set; }
        public string Note { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.RoomRatePlanId > 0)
                {
                    result = (new RoomRatePlanDAO()).Update(this);
                }
                else
                {
                    result = (new RoomRatePlanDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.RoomRatePlanId > 0)
                {
                    result = (new RoomRatePlanDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public RoomRatePlan Select()
        {
            return HBM.Utility.Generic.Get<RoomRatePlan>(this.RoomRatePlanId, 0);
        }

        public List<RoomRatePlan> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<RoomRatePlan>(0);
        }

        #endregion
    }
}

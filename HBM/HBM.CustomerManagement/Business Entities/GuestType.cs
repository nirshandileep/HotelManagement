using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.CustomerManagement
{
    [Serializable]
    public class GuestType
    {

        #region Properties

        public int GuestTypeId { get; set; }
        public int CompanyId { get; set; }
        public string GuestTypeName { get; set; }
        public string GuestTypeDescription { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        public GuestType Select()
        {
            return HBM.Utility.Generic.Get<GuestType>(this.GuestTypeId, this.CompanyId);
        }

        public List<GuestType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<GuestType>(this.CompanyId);
        }

        #endregion

    }
}

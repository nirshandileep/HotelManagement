using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.GeneralManagement
{
    [Serializable]
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<PaymentType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<PaymentType>();
        }
    }
}

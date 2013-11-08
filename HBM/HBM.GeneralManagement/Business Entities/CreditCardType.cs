using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.GeneralManagement
{
    [Serializable]
    public class CreditCardType
    {
        public int CreditCardTypeId { get; set; }
        public string Name { get; set; }
        public decimal ProcessingFee { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<CreditCardType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<CreditCardType>(CompanyId);
        }
    }
}

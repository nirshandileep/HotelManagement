using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.CustomerManagement
{
    [Serializable]
    public class CreditCardType
    {

        #region Properties

        public int CreditCardTypeId { get; set; }
        public string Name { get; set; }
        public decimal? ProcessingFee { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        public CreditCardType Select()
        {
            return HBM.Utility.Generic.Get<CreditCardType>(this.CreditCardTypeId, this.CompanyId);
        }

        public List<CreditCardType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<CreditCardType>(this.CompanyId);
        }

        #endregion
    }
}

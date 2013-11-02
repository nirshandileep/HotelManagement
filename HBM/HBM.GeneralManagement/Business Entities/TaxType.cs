using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.GeneralManagement
{
    public class TaxType
    {
        public int TaxTypeId { get; set; }
        public string TaxTypeName { get; set; }
        public int CompanyId { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<TaxType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<TaxType>(this.CompanyId);
        }
    }
}

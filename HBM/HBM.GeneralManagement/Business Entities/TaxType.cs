using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
        public decimal TaxPercentage { get; set; }
        
        #region Methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new TaxTypeDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public List<TaxType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<TaxType>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new TaxTypeDAO()).SelectAll(this);
        }

        public bool IsDuplicateTypeName()
        {
            return (new TaxTypeDAO()).IsDuplicateTypeName(this);
        }


        #endregion
    }
}

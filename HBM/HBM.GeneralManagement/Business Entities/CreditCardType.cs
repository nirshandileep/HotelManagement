using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace HBM.GeneralManagement
{
    [Serializable]
    public class CreditCardType
    {
        #region Properties

        public int CreditCardTypeId { get; set; }
        public string Name { get; set; }
        public decimal ProcessingFee { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #endregion

        #region Methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new CreditCardTypeDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }


        public List<CreditCardType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<CreditCardType>(CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new CreditCardTypeDAO()).SelectAll(this);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    [Serializable]
    public class PaymentType
    {

        #region Properties

        public int CompanyId { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #endregion

        #region methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new PaymentTypeDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public List<PaymentType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<PaymentType>();
        }

        public DataSet SelectAllDataset()
        {
            return (new PaymentTypeDAO()).SelectAll(this);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class AdditionalService
    {
        #region Properties

        public int CompanyId { get; set; }
        public int AdditionalServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public decimal Rate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new AdditionalServiceDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }


        public DataSet SelectAllDataset()
        {
            return (new AdditionalServiceDAO()).SelectAll(this);
        }


        public List<AdditionalService> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<AdditionalService>(this.CompanyId);
        }

        #endregion
    }
}

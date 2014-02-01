using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class ServiceMethods
    {
        #region Properties

        public int ServiceMethodID { get; set; }
        public int CompanyId { get; set; }
        public string ServiceMethod { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {

                result = (new ServiceMethodsDAO()).InsertUpdateDelete(ds);

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
            return (new ServiceMethodsDAO()).SelectAll(this);
        }

        public bool IsDuplicateTypeName()
        {
            return (new ServiceMethodsDAO()).IsDuplicateTypeName(this);
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class Gaurantee
    {
        #region Properties

        public int CompanyId { get; set; }
        public int GuaranteeId { get; set; }
        public string GuaranteeName { get; set; }
        public string GuaranteeDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }        

        #endregion

        #region Methods


        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.GuaranteeId > 0)
                {
                    result = (new GauranteeDAO()).Update(this);
                }
                else
                {
                    result = (new GauranteeDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.GuaranteeId > 0)
                {
                    result = (new GauranteeDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public Gaurantee Select()
        {
            return HBM.Utility.Generic.Get<Gaurantee>(this.GuaranteeId, this.CompanyId);
        }

        public List<Gaurantee> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Gaurantee>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new GauranteeDAO()).SelectAll(this);
        }

        #endregion
    }
}

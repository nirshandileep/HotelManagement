using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace HBM.GeneralManagement
{
    public class RatePlans
    {
        #region Properties

        public int CompanyId { get; set; }
        public int RatePlansId { get; set; }
        public string RatePlanName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public decimal Rate { get; set; }
        public decimal AdditionalAdultRate { get; set; }
        public decimal AdditionalChildrenRate { get; set; }
        public decimal AdditionalInfantRate { get; set; }   
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion
        
        #region Methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new RatePlansDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public List<RatePlans> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<RatePlans>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new RatePlansDAO()).SelectAll(this);
        }

        public bool IsDuplicateTypeName()
        {
            return (new RatePlansDAO()).IsDuplicateTypeName(this);
        }


        #endregion      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.CustomerManagement
{
    [Serializable]
    public class Country
    {

        #region Properties

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int CompanyId { get; set; }

        #endregion

        #region Methods

        public Country Select()
        {
            return HBM.Utility.Generic.Get<Country>(this.CountryId);
        }

        public List<Country> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Country>();
        }

        #endregion
    }
}

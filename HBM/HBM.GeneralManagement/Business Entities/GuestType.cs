using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace HBM.GeneralManagement
{
    public class GuestType
    {
        #region Properties

        public int CompanyId { get; set; }
        public int BedTypeId { get; set; }
        public string GuestTypeName { get; set; }
        public string GuestTypeDescription { get; set; }
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
                result = (new GuestTypeDAO()).InsertUpdateDelete(ds);
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
            return (new GuestTypeDAO()).SelectAll(this);
        }

        #endregion
    }
}

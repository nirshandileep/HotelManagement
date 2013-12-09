using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class BedType
    {
        #region Properties

        public int CompanyId { get; set; }
        public int BedTypeId { get; set; }
        public string BedTypeName { get; set; }
        public string BedTypeDescription { get; set; }
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
                result = (new BedTypeDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.BedTypeId > 0)
                {
                    result = (new BedTypeDAO()).Update(this);
                }
                else
                {
                    result = (new BedTypeDAO()).Insert(this);
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
                if (this.BedTypeId > 0)
                {
                    result = (new BedTypeDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public BedType Select()
        {
            return HBM.Utility.Generic.Get<BedType>(this.BedTypeId, this.CompanyId);
        }

        public List<BedType> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<BedType>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new BedTypeDAO()).SelectAll(this);
        }

        public bool IsDuplicateTypeName()
        {
            return (new BedTypeDAO()).IsDuplicateTypeName(this);
        }


        #endregion
    }
}

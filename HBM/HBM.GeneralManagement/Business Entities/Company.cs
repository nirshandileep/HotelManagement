using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Drawing;


namespace HBM.GeneralManagement
{
   public class Company
    {
        #region Properties

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTelephone { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }
        public string CompanyFax { get; set; }
        public Image CompanyLogo { get; set; }       

        #endregion

        #region Methods               

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.CompanyId > 0)
                {
                    result = (new CompanyDAO()).Update(this);
                }
                else
                {
                    result = (new CompanyDAO()).Insert(this);
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
                if (this.CompanyId > 0)
                {
                    result = (new CompanyDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public Company Select()
        {
            return HBM.Utility.Generic.Get<Company>(this.CompanyId, this.CompanyId);
        }

        public List<Company> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Company>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new CompanyDAO()).SelectAll(this);
        }

        #endregion
    }
}

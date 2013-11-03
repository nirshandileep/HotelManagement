using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace HBM.UserManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>
    [Serializable]
    public class Roles
    {
        #region Properties

        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int RightId { get; set; }        
        public int CompanyId { get; set; }        
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }


        #endregion

        #region Methods

        #region Save

        public bool Save(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                if (this.RolesId > 0)
                {
                    result = (new RolesDAO()).Update(this,db,transaction);
                }
                else
                {
                    result = (new RolesDAO()).Insert(this,db,transaction);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ;
            }
            return result;
        }

        public bool SaveRoleRights(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new RolesDAO()).InsertRoleRights(this, db, transaction);                
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ;
            }
            return result;
        }

        public bool DeleteByRolesId(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new RolesDAO()).DeleteByRolesId(this, db, transaction);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ;
            }
            return result;
        }


        #endregion
        
        #region Delete

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.RolesId > 0)
                {
                    result = (new RolesDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ;
            }
            return result;
        }

        #endregion
        
        public Roles Select()
        {
            return HBM.Utility.Generic.Get<Roles>(this.RolesId, this.CompanyId);
        }

        public List<Roles> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Roles>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new RolesDAO()).SelectAll(this);
        }

        public bool IsDuplicateRoleName(string roleName, int compnayId)
        {
            return (new RolesDAO()).IsDuplicateRoleName(roleName, compnayId);
        }

        #endregion
    }
}

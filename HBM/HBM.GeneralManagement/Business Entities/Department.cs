﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class Department
    {
        #region Properties

        public int DepartmentId { get; set; }      
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {

                result = (new DepartmentsDAO()).InsertUpdateDelete(ds);
               
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
                if (this.DepartmentId > 0)
                {
                    result = (new DepartmentsDAO()).Update(this);
                }
                else
                {
                    result = (new DepartmentsDAO()).Insert(this);
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
                if (this.DepartmentId > 0)
                {
                    result = (new DepartmentsDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public Department Select()
        {
            return HBM.Utility.Generic.Get<Department>(this.DepartmentId, this.CompanyId);
        }

        public List<Department> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Department>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new DepartmentsDAO()).SelectAll(this);
        }

        public bool IsDuplicateName()
        {
            return (new DepartmentsDAO()).IsDuplicateTypeName(this);
        }


        #endregion

    }
}

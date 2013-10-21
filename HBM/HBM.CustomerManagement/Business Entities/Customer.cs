using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace HBM.CustomerManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>
    [Serializable]
    public class Customer
    {

        #region Properties

        public Int32 CustomerId { get; set; }
        public Int32 CompanyId { get; set; }
        public string CustomerName { get; set; }
        public string MemberCode { get; set; }
        public string Gender { get; set; }
        public Int32 GuestTypeId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNotes { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public int? BillingCountryId { get; set; }
        public string BillingPostCode { get; set; }
        public string PassportNumber { get; set; }
        public int? PassportCountryOfIssue { get; set; }
        public DateTime? PassportExpirationDate { get; set; }
        public Int32? CCType { get; set; }
        public Int32? CCNo { get; set; }
        public DateTime? CCExpirationDate { get; set; }
        public string CCNameOnCard { get; set; }
        public string Car { get; set; }
        public string CarLicensePlate { get; set; }
        public string DriverLicense { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.CustomerId > 0)
                {
                    result = (new CustomerDAO()).Update(this);
                }
                else
                {
                    result = (new CustomerDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
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
                if (this.CustomerId > 0)
                {
                    result = (new CustomerDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        #endregion


        public Customer Select()
        {
            return HBM.Utility.Generic.Get<Customer>(this.CustomerId, this.CompanyId);
        }

        public List<Customer> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Customer>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new CustomerDAO()).SelectAll(this);
        }

        #endregion


    }
}

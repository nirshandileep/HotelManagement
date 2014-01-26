using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HBM.Common;

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
        public string GuestTypeName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddressLine1 { get; set; }
        public string CompanyAddressLine2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyPostCode { get; set; }
        public int? CompanyCountryId { get; set; }
        public string CompanyNotes { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public int? BillingCountryId { get; set; }
        public string BillingPostCode { get; set; }
        public string PassportNumber { get; set; }
        public int? PassportCountryOfIssue { get; set; }
        public DateTime? PassportExpirationDate { get; set; }
        public Int32? CreditCardTypeId { get; set; }
        public string CCNo { get; set; }
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
        public string CardSecurityCode { get; set; }
        public DateTime? CardStartDate { get; set; }
        public string CardIssueNo { get; set; }
        public bool UseSameBillingAddress { get; set; }
        public int? GroupId { get; set; }
        public bool? IsGroupCustomer { get; set; }
        /// <summary>
        /// CustomerId
        /// CustomerName
        /// MemberCode
        /// Gender
        /// GuestTypeId
        /// Phone
        /// </summary>
        public DataSet DsGroupCustomers { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save()
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbConnection connection = db.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();

            try
            {
                if (this.CustomerId > 0)
                {
                    result = (new CustomerDAO()).Update(this, db, transaction);
                }
                else
                {
                    result = (new CustomerDAO()).Insert(this, db, transaction);
                }

                if (this.IsGroupCustomer.HasValue && this.IsGroupCustomer.Value)
                {
                    (new CustomerDAO()).InsertUpdateDelete(this, db, transaction);

                }
                transaction.Commit();
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                result = false;
                throw ex;
            }
            finally
            {
                connection.Close();
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
            Customer customer = HBM.Utility.Generic.Get<Customer>(this.CustomerId, this.CompanyId);

            //Check if group customer record
            if (customer != null && customer.IsGroupCustomer.HasValue && customer.IsGroupCustomer.Value && customer.GroupId.HasValue == false)
            {
                //customer.DsGroupCustomers = new DataSet();
                customer.DsGroupCustomers = (new CustomerDAO()).SelectGroupByGroupId(customer.CustomerId);
            }

            return customer;
        }

        public List<Customer> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Customer>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new CustomerDAO()).SelectAll(this);
        }


        public DataSet SelectGroupByGroupId(int groupId)
        {
            return (new CustomerDAO()).SelectGroupByGroupId(groupId);
        }

        #endregion


    }
}

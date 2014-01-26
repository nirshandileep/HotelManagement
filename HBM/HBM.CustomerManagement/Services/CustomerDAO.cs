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
    public class CustomerDAO
    {
        public bool Insert(Customer customer, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_CustomerInsert");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, customer.CompanyId);
            db.AddInParameter(command, "@CustomerName", DbType.String, customer.CustomerName);
            db.AddInParameter(command, "@MemberCode", DbType.String, customer.MemberCode);
            db.AddInParameter(command, "@Gender", DbType.String, customer.Gender);
            db.AddInParameter(command, "@GuestTypeId", DbType.Int32, customer.GuestTypeId);
            db.AddInParameter(command, "@Phone", DbType.String, customer.Phone);
            db.AddInParameter(command, "@Fax", DbType.String, customer.Fax);
            db.AddInParameter(command, "@Mobile", DbType.String, customer.Mobile);
            db.AddInParameter(command, "@Email", DbType.String, customer.Email);
            db.AddInParameter(command, "@CompanyName", DbType.String, customer.CompanyName);
            db.AddInParameter(command, "@CompanyAddressLine1", DbType.String, customer.CompanyAddressLine1);
            db.AddInParameter(command, "@CompanyAddressLine2", DbType.String, customer.CompanyAddressLine2);
            db.AddInParameter(command, "@CompanyCity", DbType.String, customer.CompanyCity);
            db.AddInParameter(command, "@CompanyState", DbType.String, customer.CompanyState);
            db.AddInParameter(command, "@CompanyPostCode", DbType.String, customer.CompanyPostCode);
            db.AddInParameter(command, "@CompanyCountryId", DbType.Int32, customer.CompanyCountryId);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, customer.CompanyNotes);
            db.AddInParameter(command, "@BillingAddressLine1", DbType.String, customer.BillingAddressLine1);
            db.AddInParameter(command, "@BillingAddressLine2", DbType.String, customer.BillingAddressLine2);
            db.AddInParameter(command, "@BillingCity", DbType.String, customer.BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, customer.BillingState);
            db.AddInParameter(command, "@BillingCountryId", DbType.Int32, customer.BillingCountryId);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, customer.BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, customer.PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.Int32, customer.PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, customer.PassportExpirationDate);
            db.AddInParameter(command, "@CreditCardTypeId", DbType.Int32, customer.CreditCardTypeId);
            db.AddInParameter(command, "@CCNo", DbType.String, customer.CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, customer.CCExpirationDate);
            db.AddInParameter(command, "@CCNameOnCard", DbType.String, customer.CCNameOnCard);
            db.AddInParameter(command, "@Car", DbType.String, customer.Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, customer.CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, customer.DriverLicense);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, customer.CreatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, customer.StatusId);
            db.AddInParameter(command, "@CardSecurityCode", DbType.String, customer.CardSecurityCode);
            db.AddInParameter(command, "@CardStartDate", DbType.DateTime, customer.CardStartDate);
            db.AddInParameter(command, "@CardIssueNo", DbType.String, customer.CardIssueNo);
            db.AddInParameter(command, "@UseSameBillingAddress", DbType.Boolean, customer.UseSameBillingAddress);
            db.AddInParameter(command, "@IsGroupCustomer", DbType.Boolean, customer.IsGroupCustomer);
            db.AddOutParameter(command, "@CustomerId", DbType.Int32, 8);

            db.ExecuteNonQuery(command, transaction);

            customer.CustomerId = int.Parse(db.GetParameterValue(command, "@CustomerId").ToString());

            return true;
        }

        public bool Update(Customer customer, Database db, DbTransaction transacion)
        {

            DbCommand command = db.GetStoredProcCommand("usp_CustomerUpdate");

            db.AddInParameter(command, "@CustomerId", DbType.Int32, customer.CustomerId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, customer.CompanyId);
            db.AddInParameter(command, "@CustomerName", DbType.String, customer.CustomerName);
            db.AddInParameter(command, "@MemberCode", DbType.String, customer.MemberCode);
            db.AddInParameter(command, "@Gender", DbType.String, customer.Gender);
            db.AddInParameter(command, "@GuestTypeId", DbType.Int32, customer.GuestTypeId);
            db.AddInParameter(command, "@Phone", DbType.String, customer.Phone);
            db.AddInParameter(command, "@Fax", DbType.String, customer.Fax);
            db.AddInParameter(command, "@Mobile", DbType.String, customer.Mobile);
            db.AddInParameter(command, "@Email", DbType.String, customer.Email);
            db.AddInParameter(command, "@CompanyName", DbType.String, customer.CompanyName);
            db.AddInParameter(command, "@CompanyAddressLine1", DbType.String, customer.CompanyAddressLine1);
            db.AddInParameter(command, "@CompanyAddressLine2", DbType.String, customer.CompanyAddressLine2);
            db.AddInParameter(command, "@CompanyCity", DbType.String, customer.CompanyCity);
            db.AddInParameter(command, "@CompanyState", DbType.String, customer.CompanyState);
            db.AddInParameter(command, "@CompanyPostCode", DbType.String, customer.CompanyPostCode);
            db.AddInParameter(command, "@CompanyCountryId", DbType.Int32, customer.CompanyCountryId);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, customer.CompanyNotes);
            db.AddInParameter(command, "@BillingAddressLine1", DbType.String, customer.BillingAddressLine1);
            db.AddInParameter(command, "@BillingAddressLine2", DbType.String, customer.BillingAddressLine2);
            db.AddInParameter(command, "@BillingCity", DbType.String, customer.BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, customer.BillingState);
            db.AddInParameter(command, "@BillingCountryId", DbType.Int32, customer.BillingCountryId);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, customer.BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, customer.PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.Int32, customer.PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, customer.PassportExpirationDate);
            db.AddInParameter(command, "@CreditCardTypeId", DbType.Int32, customer.CreditCardTypeId);
            db.AddInParameter(command, "@CCNo", DbType.String, customer.CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, customer.CCExpirationDate);
            db.AddInParameter(command, "@CCNameOnCard", DbType.String, customer.CCNameOnCard);
            db.AddInParameter(command, "@Car", DbType.String, customer.Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, customer.CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, customer.DriverLicense);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, customer.UpdatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, customer.StatusId);
            db.AddInParameter(command, "@CardSecurityCode", DbType.String, customer.CardSecurityCode);
            db.AddInParameter(command, "@CardStartDate", DbType.DateTime, customer.CardStartDate);
            db.AddInParameter(command, "@CardIssueNo", DbType.String, customer.CardIssueNo);
            db.AddInParameter(command, "@UseSameBillingAddress", DbType.Boolean, customer.UseSameBillingAddress);

            db.ExecuteNonQuery(command, transacion);

            return true;
        }

        public bool Delete(Customer customer)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CustomerDelete");

            db.AddInParameter(command, "@CustomerId", DbType.Int32, customer.CustomerId);            

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectAll(Customer customer)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CustomerSelectAll");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, customer.CompanyId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectGroupByGroupId(int groupId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CustomerGroupSelectByGroupId");

            db.AddInParameter(command, "@GroupId", DbType.Int32, groupId);

            return db.ExecuteDataSet(command);
        }

        public bool InsertUpdateDelete(Customer customer, Database db, DbTransaction transaction)
        {
            DbCommand commandInsert = db.GetStoredProcCommand("usp_CustomerGroupInsert");
            db.AddInParameter(commandInsert, "@GroupId", DbType.Int32, customer.CustomerId);
            db.AddInParameter(commandInsert, "@CompanyId", DbType.Int32, customer.CompanyId);
            db.AddInParameter(commandInsert, "@CustomerName", DbType.String, "CustomerName", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@MemberCode", DbType.String, "MemberCode", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Gender", DbType.String, "Gender", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@GuestTypeId", DbType.Int32, "GuestTypeId", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@Phone", DbType.String, "Phone", DataRowVersion.Current);
            db.AddInParameter(commandInsert, "@StatusId", DbType.Int32, (int)HBM.Common.Enums.HBMStatus.Active);
            db.AddInParameter(commandInsert, "@IsGroupCustomer", DbType.Boolean, customer.IsGroupCustomer);
            db.AddInParameter(commandInsert, "@CreatedUser", DbType.Int32, "CreatedUser", DataRowVersion.Current);

            DbCommand commandUpdate = db.GetStoredProcCommand("usp_CustomerGroupUpdate");
            db.AddInParameter(commandUpdate, "@CustomerId", DbType.Int32, "CustomerId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@CustomerName", DbType.String, "CustomerName", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@MemberCode", DbType.String, "MemberCode", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Gender", DbType.String, "Gender", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@GuestTypeId", DbType.Int32, "GuestTypeId", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@Phone", DbType.String, "Phone", DataRowVersion.Current);
            db.AddInParameter(commandUpdate, "@StatusId", DbType.Int32, (int)HBM.Common.Enums.HBMStatus.Active);
            db.AddInParameter(commandUpdate, "@UpdatedUser", DbType.Int32, "UpdatedUser", DataRowVersion.Current);

            DbCommand commandDelete = db.GetStoredProcCommand("usp_CustomerDelete");
            db.AddInParameter(commandDelete, "@CustomerId", DbType.Int32, "CustomerId", DataRowVersion.Current);

            db.UpdateDataSet(customer.DsGroupCustomers, customer.DsGroupCustomers.Tables[0].TableName, commandInsert, commandUpdate, commandDelete, transaction);

            return true;
        }
    }
}

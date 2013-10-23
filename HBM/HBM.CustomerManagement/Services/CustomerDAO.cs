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
        public bool Insert(Customer customer)
        {
            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
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
            db.AddInParameter(command, "@CompanyAddress", DbType.String, customer.CompanyAddress);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, customer.CompanyNotes);
            db.AddInParameter(command, "@BillingAddress", DbType.String, customer.BillingAddress);
            db.AddInParameter(command, "@BillingCity", DbType.String, customer.BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, customer.BillingState);
            db.AddInParameter(command, "@BillingCountryId", DbType.Int32, customer.BillingCountryId);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, customer.BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, customer.PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.Int32, customer.PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, customer.PassportExpirationDate);
            db.AddInParameter(command, "@CreditCardTypeId", DbType.Int32, customer.CreditCardTypeId);
            db.AddInParameter(command, "@CCNo", DbType.Int64, customer.CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, customer.CCExpirationDate);
            db.AddInParameter(command, "@CCNameOnCard", DbType.String, customer.CCNameOnCard);
            db.AddInParameter(command, "@Car", DbType.String, customer.Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, customer.CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, customer.DriverLicense);
            db.AddInParameter(command, "@CreatedUser", DbType.Int32, customer.CreatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, customer.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(Customer customer)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
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
            db.AddInParameter(command, "@CompanyAddress", DbType.String, customer.CompanyAddress);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, customer.CompanyNotes);
            db.AddInParameter(command, "@BillingAddress", DbType.String, customer.BillingAddress);
            db.AddInParameter(command, "@BillingCity", DbType.String, customer.BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, customer.BillingState);
            db.AddInParameter(command, "@BillingCountryId", DbType.Int32, customer.BillingCountryId);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, customer.BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, customer.PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.Int32, customer.PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, customer.PassportExpirationDate);
            db.AddInParameter(command, "@CreditCardTypeId", DbType.Int32, customer.CreditCardTypeId);
            db.AddInParameter(command, "@CCNo", DbType.Int64, customer.CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, customer.CCExpirationDate);
            db.AddInParameter(command, "@CCNameOnCard", DbType.String, customer.CCNameOnCard);
            db.AddInParameter(command, "@Car", DbType.String, customer.Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, customer.CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, customer.DriverLicense);
            db.AddInParameter(command, "@UpdatedUser", DbType.Int32, customer.UpdatedUser);
            db.AddInParameter(command, "@StatusId", DbType.Int32, customer.StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Customer customer)
        {

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand command = db.GetStoredProcCommand("usp_CustomerDelete");

            db.AddInParameter(command, "@CustomerId", DbType.Int32, customer.CustomerId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, customer.CompanyId);

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


    }
}

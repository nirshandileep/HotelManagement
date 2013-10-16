using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;


namespace HBM.Data
{
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
        public string BillingCountry { get; set; }
        public string BillingPostCode { get; set; }
        public string PassportNumber { get; set; }
        public string PassportCountryOfIssue { get; set; }
        public DateTime? PassportExpirationDate { get; set; }
        public Int32? CCType { get; set; }
        public Int32? CCNo { get; set; }
        public DateTime? CCExpirationDate { get; set; }
        public DateTime? CCNameDate { get; set; }
        public string Car { get; set; }
        public string CarLicensePlate { get; set; }
        public string DriverLicense { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@CustomerName", DbType.String, CustomerName);
            db.AddInParameter(command, "@MemberCode", DbType.String, MemberCode);
            db.AddInParameter(command, "@Gender", DbType.String, Gender);
            db.AddInParameter(command, "@GuestTypeId", DbType.Int32, GuestTypeId);
            db.AddInParameter(command, "@Phone", DbType.String, Phone);
            db.AddInParameter(command, "@Fax", DbType.String, Fax);
            db.AddInParameter(command, "@Mobile", DbType.String, Mobile);
            db.AddInParameter(command, "@Email", DbType.String, Email);
            db.AddInParameter(command, "@CompanyName", DbType.String, CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, CompanyAddress);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, CompanyNotes);
            db.AddInParameter(command, "@BillingAddress", DbType.String, BillingAddress);
            db.AddInParameter(command, "@BillingCity", DbType.String, BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, BillingState);
            db.AddInParameter(command, "@BillingCountry", DbType.String, BillingCountry);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.String, PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, PassportExpirationDate);
            db.AddInParameter(command, "@CCType", DbType.Int32, CCType);
            db.AddInParameter(command, "@CCNo", DbType.Int32, CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, CCExpirationDate);
            db.AddInParameter(command, "@CCNameDate", DbType.DateTime, CCNameDate);
            db.AddInParameter(command, "@Car", DbType.String, Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, DriverLicense);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CustomerId", DbType.Int32, CustomerId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(command, "@CustomerName", DbType.String, CustomerName);
            db.AddInParameter(command, "@MemberCode", DbType.String, MemberCode);
            db.AddInParameter(command, "@Gender", DbType.String, Gender);
            db.AddInParameter(command, "@GuestTypeId", DbType.Int32, GuestTypeId);
            db.AddInParameter(command, "@Phone", DbType.String, Phone);
            db.AddInParameter(command, "@Fax", DbType.String, Fax);
            db.AddInParameter(command, "@Mobile", DbType.String, Mobile);
            db.AddInParameter(command, "@Email", DbType.String, Email);
            db.AddInParameter(command, "@CompanyName", DbType.String, CompanyName);
            db.AddInParameter(command, "@CompanyAddress", DbType.String, CompanyAddress);
            db.AddInParameter(command, "@CompanyNotes", DbType.String, CompanyNotes);
            db.AddInParameter(command, "@BillingAddress", DbType.String, BillingAddress);
            db.AddInParameter(command, "@BillingCity", DbType.String, BillingCity);
            db.AddInParameter(command, "@BillingState", DbType.String, BillingState);
            db.AddInParameter(command, "@BillingCountry", DbType.String, BillingCountry);
            db.AddInParameter(command, "@BillingPostCode", DbType.String, BillingPostCode);
            db.AddInParameter(command, "@PassportNumber", DbType.String, PassportNumber);
            db.AddInParameter(command, "@PassportCountryOfIssue", DbType.String, PassportCountryOfIssue);
            db.AddInParameter(command, "@PassportExpirationDate", DbType.DateTime, PassportExpirationDate);
            db.AddInParameter(command, "@CCType", DbType.Int32, CCType);
            db.AddInParameter(command, "@CCNo", DbType.Int32, CCNo);
            db.AddInParameter(command, "@CCExpirationDate", DbType.DateTime, CCExpirationDate);
            db.AddInParameter(command, "@CCNameDate", DbType.DateTime, CCNameDate);
            db.AddInParameter(command, "@Car", DbType.String, Car);
            db.AddInParameter(command, "@CarLicensePlate", DbType.String, CarLicensePlate);
            db.AddInParameter(command, "@DriverLicense", DbType.String, DriverLicense);
            db.AddInParameter(command, "@CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(command, "@CreatedDate", DbType.DateTime, CreatedDate);
            db.AddInParameter(command, "@UpdatedBy", DbType.Int32, UpdatedBy);
            db.AddInParameter(command, "@UpdatedDate", DbType.DateTime, UpdatedDate);
            db.AddInParameter(command, "@StatusId", DbType.Int32, StatusId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@CustomerId", DbType.Int32, CustomerId);
            db.AddInParameter(command, "@CompanyId", DbType.Int32, CompanyId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@CustomerId", DbType.Int32, CustomerId);
            db.AddInParameter(dbCommand, "@CompanyId", DbType.Int32, CompanyId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                CustomerName = reader["CustomerName"] != DBNull.Value ? reader["CustomerName"].ToString() : string.Empty;
                MemberCode = reader["MemberCode"] != DBNull.Value ? reader["MemberCode"].ToString() : string.Empty;
                Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                GuestTypeId = Convert.ToInt32(reader["GuestTypeId"] != DBNull.Value ? reader["GuestTypeId"].ToString() : "0");
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty;
                Fax = reader["Fax"] != DBNull.Value ? reader["Fax"].ToString() : string.Empty;
                Mobile = reader["Mobile"] != DBNull.Value ? reader["Mobile"].ToString() : string.Empty;
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : string.Empty;
                CompanyAddress = reader["CompanyAddress"] != DBNull.Value ? reader["CompanyAddress"].ToString() : string.Empty;
                CompanyNotes = reader["CompanyNotes"] != DBNull.Value ? reader["CompanyNotes"].ToString() : string.Empty;
                BillingAddress = reader["BillingAddress"] != DBNull.Value ? reader["BillingAddress"].ToString() : string.Empty;
                BillingCity = reader["BillingCity"] != DBNull.Value ? reader["BillingCity"].ToString() : string.Empty;
                BillingState = reader["BillingState"] != DBNull.Value ? reader["BillingState"].ToString() : string.Empty;
                BillingCountry = reader["BillingCountry"] != DBNull.Value ? reader["BillingCountry"].ToString() : string.Empty;
                BillingPostCode = reader["BillingPostCode"] != DBNull.Value ? reader["BillingPostCode"].ToString() : string.Empty;
                PassportNumber = reader["PassportNumber"] != DBNull.Value ? reader["PassportNumber"].ToString() : string.Empty;
                PassportCountryOfIssue = reader["PassportCountryOfIssue"] != DBNull.Value ? reader["PassportCountryOfIssue"].ToString() : string.Empty;
                PassportExpirationDate = Convert.ToDateTime(reader["PassportExpirationDate"] != DBNull.Value ? reader["PassportExpirationDate"].ToString() : DateTime.MinValue.ToString());
                CCType = Convert.ToInt32(reader["CCType"] != DBNull.Value ? reader["CCType"].ToString() : "0");
                CCNo = Convert.ToInt32(reader["CCNo"] != DBNull.Value ? reader["CCNo"].ToString() : "0");
                CCExpirationDate = Convert.ToDateTime(reader["CCExpirationDate"] != DBNull.Value ? reader["CCExpirationDate"].ToString() : DateTime.MinValue.ToString());
                CCNameDate = Convert.ToDateTime(reader["CCNameDate"] != DBNull.Value ? reader["CCNameDate"].ToString() : DateTime.MinValue.ToString());
                Car = reader["Car"] != DBNull.Value ? reader["Car"].ToString() : string.Empty;
                CarLicensePlate = reader["CarLicensePlate"] != DBNull.Value ? reader["CarLicensePlate"].ToString() : string.Empty;
                DriverLicense = reader["DriverLicense"] != DBNull.Value ? reader["DriverLicense"].ToString() : string.Empty;
                CreatedBy = Convert.ToInt32(reader["CreatedBy"] != DBNull.Value ? reader["CreatedBy"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                CreatedBy = Convert.ToInt32(reader["UpdatedBy"] != DBNull.Value ? reader["UpdatedBy"].ToString() : "0");
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");

            }

        }

        #endregion

    }
}

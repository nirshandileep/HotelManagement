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
    public class Users
    {
        #region Properties

        public Int32 UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }

        #endregion

        #region Methods

        public bool Save()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand command = db.GetStoredProcCommand("");

            db.AddInParameter(command, "@UserName", DbType.String, UserName);
            db.AddInParameter(command, "@Password", DbType.String, Password);
            db.AddInParameter(command, "@FirstName", DbType.String, FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, EmailAddress);           
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

            db.AddInParameter(command, "@UserId", DbType.String, UserId);
            db.AddInParameter(command, "@UserName", DbType.String, UserName);
            db.AddInParameter(command, "@Password", DbType.String, Password);
            db.AddInParameter(command, "@FirstName", DbType.String, FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, EmailAddress);
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

            db.AddInParameter(command, "@UserId", DbType.String, UserId);


            db.ExecuteNonQuery(command);

            return true;
        }

        public void Select()
        {

            Database db = DatabaseFactory.CreateDatabase("");
            DbCommand dbCommand = db.GetStoredProcCommand("");

            db.AddInParameter(dbCommand, "@UserId", DbType.String, UserId);

            IDataReader reader = db.ExecuteReader(dbCommand);

            if (reader.Read())
            {
                UserId = Convert.ToInt32(reader["UserId"].ToString());

                UserName = reader["UserName"] != DBNull.Value ? reader["CustomerName"].ToString() : string.Empty;
                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
                FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : string.Empty;                
                LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : string.Empty;

                EmailAddress = reader["EmailAddress"] != DBNull.Value ? reader["EmailAddress"].ToString() : string.Empty;
               
                CreatedBy = reader["CreatedBy"] != DBNull.Value ? reader["CreatedBy"].ToString() : "0";
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"] != DBNull.Value ? reader["CreatedDate"].ToString() : DateTime.MinValue.ToString());
                CreatedBy = reader["UpdatedBy"] != DBNull.Value ? reader["UpdatedBy"].ToString() : "0";
                CreatedDate = Convert.ToDateTime(reader["UpdatedDate"] != DBNull.Value ? reader["UpdatedDate"].ToString() : DateTime.MinValue.ToString());
                StatusId = Convert.ToInt32(reader["StatusId"] != DBNull.Value ? reader["StatusId"].ToString() : "0");

            }

        }

        #endregion

    }
}

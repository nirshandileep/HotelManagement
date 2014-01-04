using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.UserManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>   
    public class Users
    {
        #region Properties

        public Int32 UsersId { get; set; }
        public Int32 CompanyId{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }
        public Int32 RolesId { get; set; }
        public Int32 DepartmentId { get; set; }
        public List<Rights> AllRights { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.UsersId > 0)
                {
                    result = (new UserDAO()).Update(this);
                }
                else
                {
                    result = (new UserDAO()).Insert(this);
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


        #region Delete

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.UsersId > 0)
                {
                    result = (new UserDAO()).Delete(this);
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


        public Users Select()
        {
            Users user = HBM.Utility.Generic.Get<Users>(this.UsersId, this.CompanyId);
            user.AllRights = new Rights().SelectRightsByUserId(this.UsersId);
            return user;
        }

        public List<Users> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Users>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new UserDAO()).SelectAll(this);
        }

        public bool IsUserAuthenticated(string userName, string password, out int UsersId, out int compnayId)
        {
            return (new UserDAO()).IsUserAuthenticated(userName,password, out UsersId, out compnayId);
        }

        public bool IsUserIsDuplicateUserName(string userName, int compnayId)
        {
            return (new UserDAO()).IsUserIsDuplicateUserName(userName, compnayId);
        }

        public bool IsDuplicateEmail(string email, int compnayId)
        {
            return (new UserDAO()).IsDuplicateEmail(email, compnayId);

        }


        #endregion
    }
}

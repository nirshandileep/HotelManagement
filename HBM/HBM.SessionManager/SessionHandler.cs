using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;
using HBM.UserManagement;
using HBM.Common;
using HBM.CompanyManagement;


namespace HBM.SessionManager
{
    public class SessionHandler : IRequiresSessionState
    {

        public static Users LoggedUser
        {
            get 
            {
                return GetSession<Users>(Constants.SESSION_LOGGEDUSER);
            }
        }

        /// <summary>
        /// If session SESSION_CURRENTCOMPANY is null 
        /// Company id will be obtained from the logged user
        /// </summary>
        public static int CurrentCompanyId
        {
            get
            {
                int companyId;
                Company company = GetSession<Company>(Constants.SESSION_CURRENTCOMPANY);
                if (company != null)
                {
                    companyId = company.CompanyId;
                }
                else 
                {
                    companyId = LoggedUser.CompanyId;
                }

                return companyId;
            }
        }

        public static HBM.CompanyManagement.Company CurrentCompany
        {
            get
            {
                return GetSession<Company>(Constants.SESSION_CURRENTCOMPANY);                
            }
        }

        public static T GetSession<T>(string sessionName) where T : new()
        {
            T entity = default(T);

            if (HttpContext.Current.Session[sessionName] != null)
            {
                entity = (T)(HttpContext.Current.Session[sessionName]);
            }

            return entity;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;

namespace HBM.Common
{
    public class SessionHandler : IRequiresSessionState
    {


        public static T GetSession<T>(string sessionName) where T : new()
        {
            T entity = default(T);

            string TypeName = typeof(T).Name;

            if (HttpContext.Current.Session[sessionName] != null)
            {
                entity = (T)(HttpContext.Current.Session[sessionName]);
            }

            return entity;
        }

        public void getSession(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                string sessionID = HttpContext.Current.Session[key].ToString();
            }
        }
    }
}

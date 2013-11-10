using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.Utility
{
    public static class CommonTools
    {
        public static string CreateURLQueryString(string urlToNavigate, object mykey)
        {
            string url = urlToNavigate + ((object)Cryptography.Encrypt(mykey.ToString()).ToString());
            return url;
        }
    }
}

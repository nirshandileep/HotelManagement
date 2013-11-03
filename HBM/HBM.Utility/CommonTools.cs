using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.Utility
{
    public static class CommonTools
    {
        public static string CreateURLQueryString(string urltoFormat, object mykey)
        {
            string url =urltoFormat+ (object)Cryptography.Encrypt(mykey.ToString());
            return url;
        }
    }
}

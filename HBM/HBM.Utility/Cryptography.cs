using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace HBM.Utility
{
    public class Cryptography 
    {
        #region Properties

        private static byte[] key = { };
        private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };
        private static string stringKey = "!5609SN67773a#KN";

        #endregion

        #region Methods
     
        public static string Encrypt(string text)
        {

            try
            {

                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Encoding.UTF8.GetBytes(text);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);

                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());

            }

            catch (Exception ex)
            {

                // Handle Exception Here

            }



            return string.Empty;

        }
        
        public static string Decrypt(string text)
        {

            try
            {

                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Convert.FromBase64String(text);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);

                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());

            }

            catch (Exception ex)
            {

                // Handle Exception Here

            }



            return string.Empty;

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.CustomerManagement
{
    /// <summary>
    /// Make all business logic here
    /// </summary>
    [Serializable]
    public class CustomerManager
    {

        /// <summary>
        /// Pass the customer object to this method and check if its valid to be saved.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool IsValidToSave(Customer customer, out string errorMSG)
        {
            bool isValid = true;
            errorMSG = string.Empty;



            return isValid;
        }
    }
}

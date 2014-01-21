using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.Common
{
    public class Enums
    {
        /// <summary>
        /// Types of status
        /// </summary>
        public enum HBMStatus
        {
            Active = 1,
            InActive = 2,
            Confirmed = 3,
            Modify = 4,
            CheckIn = 5,
            Cancel = 6,
            NoShow = 7,
        }

        /// <summary>
        /// Types of Companies
        /// </summary>
        public enum HBMCompanyTypes
        {
            Hote=1
        }

        /// <summary>
        /// Different types of customers
        /// </summary>
        public enum CustomerModes
        {
            Individual = 1,
            Group = 2,
        }
       
    }
}

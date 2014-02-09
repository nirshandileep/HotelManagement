using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.UserManagement
{
    public class UserManager
    {
        public bool IsUserAuthorised(Common.Enums.Rights right,Users user)
        {
            bool returnValue = false;
            if (user.AllRights.Select(e => e.RightId == (int)right).Count() > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }
    }
}

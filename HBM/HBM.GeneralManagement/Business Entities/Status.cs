using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.GeneralManagement
{
    public class Status
    {

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<Status> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Status>();
        }
    }
}

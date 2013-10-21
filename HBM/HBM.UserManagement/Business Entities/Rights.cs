using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.UserManagement
{
    public class Rights
    {
        #region Properties

        public int RightId { get; set; }
        public int RolesId { get; set; }
        public string RightName { get; set; }
        public string RightDescription { get; set; }
        public Int32 CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods
        
        public Rights Select()
        {
            return HBM.Utility.Generic.Get<Rights>(this.RightId,0 );
        }

        public List<Rights> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Rights>(0);
        }

        public DataSet SelectAllDataset()
        {
            return (new RightsDAO()).SelectAll();
        }

        public DataSet SelectByRolesId()
        {
            return (new RightsDAO()).SelectByRolesId(this);
        }

       

        #endregion
    }
}

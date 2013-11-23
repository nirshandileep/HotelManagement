using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>
    [Serializable]
    public class Room
    {
        #region Properties

        public int CompanyId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public int BedTypeId { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxInfant { get; set; }
        public bool SmokingAllow { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 StatusId { get; set; }
        public bool IsDirty { get; set; }
        public string CleaningNote { get; set; }
        public int CleanedBy { get; set; }
        public DateTime CleanedDate { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save(DataSet ds)
        {
            bool result = false;
            try
            {
                result = (new RoomDAO()).InsertUpdateDelete(ds);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.BedTypeId > 0)
                {
                    result = (new RoomDAO()).Update(this);
                }
                else
                {
                    result = (new RoomDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        #endregion


        #region Delete

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.BedTypeId > 0)
                {
                    result = (new RoomDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        #endregion


        public Room Select()
        {
            return HBM.Utility.Generic.Get<Room>(this.BedTypeId, this.CompanyId);
        }

        public List<Room> SelectAllList()
        {
            return HBM.Utility.Generic.GetAll<Room>(this.CompanyId);
        }

        public DataSet SelectAllDataset()
        {
            return (new RoomDAO()).SelectAll(this);
        }

        public bool MarkRoomAsDirty()
        {
            return (new RoomDAO()).UpdateRoomAsDirty(this);
        }


        #endregion
    }
}

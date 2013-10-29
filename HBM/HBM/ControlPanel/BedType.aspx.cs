using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenMan = HBM.GeneralManagement;
using DevExpress.Web.ASPxGridView;
using System.Data;
using HBM.Common;
using System.Collections;

namespace HBM.ControlPanel
{
    public partial class BedType : System.Web.UI.Page
    {

        DataSet dsData = new DataSet();
        GenMan.BedType bedType = new GenMan.BedType();

        protected void Page_Load(object sender, EventArgs e)
        {

            try 
            {                   

                gvBedTypes.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
                this.LoadBedTypes();
                dsData.Tables[0].PrimaryKey = new DataColumn[] { dsData.Tables[0].Columns["BedTypeId"] };
                Session[Constants.SESSION_BEDTYPES] = dsData;
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadBedTypes()
        {
            try
            {
                bedType.CompanyId = 1;
                dsData=bedType.SelectAllDataset();
                gvBedTypes.DataSource = dsData.Tables[0];
                gvBedTypes.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

        protected void gvBedTypes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session[Constants.SESSION_BEDTYPES] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["BedTypeId"] = rd.Next();
            e.NewValues["StatusId"]= (int)Enums.BHMStatus.Active;
            e.NewValues["CompanyId"] = 1;
            e.NewValues["CreatedUser"] = 1;

            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString() != "Count")
                {
                    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
                }
            }
            gridView.CancelEdit();
            e.Cancel = true;

            dsData.Tables[0].Rows.Add(row);
            
            if (bedType.Save(dsData))
            {
                this.LoadBedTypes();
            }


        }

        protected void gvBedTypes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            dsData = Session[Constants.SESSION_BEDTYPES] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataTable dataTable = dsData.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[0]);
            e.NewValues["StatusId"] = (int)Enums.BHMStatus.Modify;
            e.NewValues["UpdatedUser"] = 1;
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            }

            gridView.CancelEdit();
            e.Cancel = true;
            
            if (bedType.Save(dsData))
            {
                this.LoadBedTypes();
            }

        }

        protected void gvBedTypes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvBedTypes.FindVisibleIndexByKeyValue(e.Keys[gvBedTypes.KeyFieldName]);
            e.Cancel = true;
            dsData = Session[Constants.SESSION_BEDTYPES] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvBedTypes.KeyFieldName])));

            GenMan.BedType bedType = new GenMan.BedType();

            if (bedType.Save(dsData))
            {
                this.LoadBedTypes();
            }



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.UserManagement;
using System.Data;
using UM = HBM.UserManagement;

namespace HBM
{
    public partial class HBMMaster : System.Web.UI.MasterPage
    {

        /// <summary>
        /// Returns CompanyId of the logged session
        /// </summary>
        public int CompanyId
        {
            get 
            {
                return 1;
            }
        }

        /// <summary>
        /// Logged User
        /// </summary>
        public UM.Users LoggedUser
        {
            get 
            {
                UM.Users user;

                if (Session["LoggedUser"] != null)
                {
                    user = (UM.Users)Session["LoggedUser"];
                }
                else
                {
                    user = null;
                    Session["LoggedUser"] = null;
                 //   Response.Redirect("~/Login.aspx");
                }

                return user;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region Methods

        /// <summary>
        /// Clear all sessions in the system, all newly added sessions needs to be added to this method
        /// </summary>
        public void ClearSessions()
        {

            ///
            /// Customer
            ///
            Session["CustomerObj"] = null;

        }

        /// <summary>
        ///		This method binds a drop down list or a checkbox list to a given DataSet
        /// </summary>
        /// <param name="textField">
        ///		Field from the datasource to use for the option text
        /// </param>
        /// <param name="valueField">
        ///		Field from the datasource to use for the option value 
        /// </param>
        /// <param name="dsDataSet">
        ///		DataSource
        /// </param>
        /// <param name="webControl">
        ///		Name of the Control
        /// </param>
        /// <param name="dropDownListID">
        ///     The index number of the table in the dataset to be bound to the control, contains a default value of Zero
        /// </param>
        public void BindDropdown(string textField, string valueField, DataSet dsDataSet, System.Web.UI.WebControls.WebControl webControl, int tableNo = 0)
        {

            if (webControl is DropDownList)
            {
                DropDownList dropDown = (DropDownList)webControl;
                dropDown.DataSource = dsDataSet.Tables[tableNo];

                //set DataTextField property only if it is not null
                if (null != textField)
                {
                    dropDown.DataTextField = textField;
                }

                //set DataValueField property only if it is not null
                if (null != valueField)
                {
                    dropDown.DataValueField = valueField;
                }
                dropDown.DataBind();

            }
            else if (webControl is CheckBoxList)
            {
                CheckBoxList checkBoxList = (CheckBoxList)webControl;
                checkBoxList.DataSource = dsDataSet.Tables[tableNo];

                //set DataTextField property only if it is not null
                if (null != textField)
                {
                    checkBoxList.DataTextField = textField;
                }

                //set DataValueField property only if it is not null
                if (null != valueField)
                {
                    checkBoxList.DataValueField = valueField;
                }
                checkBoxList.DataBind();
            }
        }

        #endregion
    }
}
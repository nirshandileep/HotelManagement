using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.UserManagement;
using System.Data;
using UM = HBM.UserManagement;
using HBM.Common;
using HBM.SessionManager;
using HBM.CompanyManagement;

namespace HBM
{
    public partial class HBMMaster : System.Web.UI.MasterPage
    {

        #region Properties

        /// <summary>
        /// Logged User
        /// </summary>
        public UM.Users LoggedUser
        {
            get
            {
                UM.Users user;

                if (Session[Constants.SESSION_LOGGEDUSER] != null)
                {
                    user = (UM.Users)Session[Constants.SESSION_LOGGEDUSER];
                }
                else
                {
                    user = null;
                    Session[Constants.SESSION_LOGGEDUSER] = null;
                    Response.Redirect(Constants.URL_LOGIN, false);
                }

                return user;
            }
        }

        /// <summary>
        /// Logged user currenct company
        /// </summary>
        public Company CurrentCompany
        {

            get
            {
                return SessionHandler.CurrentCompany;
            }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Clear all sessions in the system, all newly added sessions needs to be added to this method
        /// </summary>
        public void ClearSessions()
        {       
            Session[Constants.SESSION_LOGGEDUSER] = null;
            Session[Constants.SESSION_BEDTYPES] = null;
            Session[Constants.SESSION_DEPARTMENT] = null;
            Session[Constants.SESSION_GAURANTEE] = null;
            Session[Constants.SESSION_ROOMS] = null;
            Session[Constants.SESSION_SOURCE] = null;
            Session[Constants.SESSION_CURRENTCOMPANY] = null;
            Session[Constants.SESSION_RATEPLANS] = null;
            Session[Constants.SESSION_TAXTYPES] = null;
            Session[Constants.SESSION_ADDITIONALSERVICETYPE] = null;
            Session[Constants.SESSION_ADDITIONALSERVICE] = null;
            Session[Constants.SESSION_CREDITCARDTYPE] = null;            
            Session[Constants.SESSION_GUESTTYPE] = null;
            Session[Constants.SESSION_PAYMENTTYPES] = null;
            Session[Constants.SESSION_RESERVATION_ADDTIONALSERVICE] = null;
            Session[Constants.SESSION_RESERVATION_PAYMENTINFORMATION] = null;
            Session[Constants.SESSION_RESERVATION_ROOMINFORMATION] = null;
            Session[Constants.SESSION_ARRIVALS] = null;
            Session[Constants.SESSION_DEPARTURES] = null;
            Session[Constants.SESSION_DIRTYROOMS] = null;
            Session[Constants.SESSION_ROOMRATEPLAN] = null;
            Session[Constants.SESSION_CURRENTREPORT] = null;
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

        #region Events

        /// <summary>
        /// Page Loadf
        /// </summary>
        /// <param name="sender">object as sender</param>
        /// <param name="e">e Event argument</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Called everytime to check it the user session is null
            if (Session[Constants.SESSION_LOGGEDUSER] == null)
            {
                ClearSessions();
                Response.Redirect(Constants.URL_LOGIN, false);
            }


            if (LoggedUser != null)
            {
                this.lblLoggedUser.Text = LoggedUser.FirstName + " " + LoggedUser.LastName;

                if (CurrentCompany.CompanyLogo.Length > 0)
                {
                    this.bimgLogo.ContentBytes = this.CurrentCompany.CompanyLogo;
                }
            }
            else
            {
                Response.Redirect(HBM.Common.Constants.URL_LOGIN, false);
            }



        }

        /// <summary>
        /// Log out Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            this.ClearSessions();
            Response.Redirect(HBM.Common.Constants.URL_LOGIN, false);
        }

        #endregion
    }
}
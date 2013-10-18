using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HBM.UserManagement;

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
        public Users User
        {
            get 
            {
                Users user;

                if (Session["LoggedUser"] != null)
                {
                    user = (Users)Session["LoggedUser"];
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

        #endregion
    }
}
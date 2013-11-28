﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBM.Reports
{
    public partial class PrintPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.ShowReservationInvoice();

        }

        private void ShowReservationInvoice()
        {
            xrReservation reservationInvoice = new xrReservation();
            rvReportViewer.Report = reservationInvoice;
        }

    }
}
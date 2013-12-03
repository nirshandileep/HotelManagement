using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using HBM.Common;
using ResMan = HBM.ReservationManagement;
using System.Data;
using DevExpress.XtraReports.UI;

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
            xrReservation reservationInvoiceReport = new xrReservation();


            ResMan.Reservation reservation = new ResMan.Reservation();
            reservation.ReservationId = 50;
            reservation = reservation.Select();

            reservationInvoiceReport.xrCellInvoiceNo.Text = "InvoiceNo - INV" + reservation.ReservationId.ToString();
            reservationInvoiceReport.xrCellInvoiceDate.Text = DateTime.Now.ToString();
            reservationInvoiceReport.xrCellReservationCode.Text = "Code - " + reservation.ReservationCode;
            reservationInvoiceReport.xrCellReservationDate.Text = reservation.BookingDate.ToString();

            reservationInvoiceReport.xrCellCustomer.Text = "";
            reservationInvoiceReport.xrCellCompanyName.Text = "";
            reservationInvoiceReport.xrCellCompnayAddress.Text = "";


            DataSet dsRoomInfo = new DataSet();
            dsRoomInfo = reservation.ReservationRoomDataSet;

            DataSet dsPaymentSection = new DataSet();
            dsPaymentSection = reservation.ReservationPaymentDataSet;

            //// Room info section
            if (dsRoomInfo != null && dsRoomInfo.Tables.Count > 0 && dsRoomInfo.Tables[0] != null && dsRoomInfo.Tables[0].Rows.Count > 0)
            {
                decimal roomInfoTotal;
                roomInfoTotal = 0;

                for (int i = 0; i <= dsRoomInfo.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        reservationInvoiceReport.xrCellCustomerName.Text = dsRoomInfo.Tables[0].Rows[i]["Sharers"] != null ? dsRoomInfo.Tables[0].Rows[i]["Sharers"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellCheckIn.Text = dsRoomInfo.Tables[0].Rows[i]["CheckInDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckInDate"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellCheckOut.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString() : string.Empty;
                        //reservationInvoiceReport.xrCellRoom.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString() : string.Empty;
                        //reservationInvoiceReport.xrCellRate.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;                   
                        reservationInvoiceReport.xrCellNights.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellAmount.Text = dsRoomInfo.Tables[0].Rows[i]["Amount"] != null ? dsRoomInfo.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;
                        roomInfoTotal = Convert.ToDecimal(reservationInvoiceReport.xrCellAmount.Text);
                    }
                    else
                    {
                        XRTableCell cell1 = new XRTableCell();
                        XRTableCell cell2 = new XRTableCell();
                        XRTableCell cell3 = new XRTableCell();
                        XRTableCell cell4 = new XRTableCell();
                        XRTableCell cell5 = new XRTableCell();
                        XRTableCell cell6 = new XRTableCell();
                        XRTableCell cell7 = new XRTableCell();

                        cell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF;
                        cell2.WidthF = reservationInvoiceReport.xrCellCheckIn.WidthF;
                        cell3.WidthF = reservationInvoiceReport.xrCellCheckOut.WidthF;
                        cell4.WidthF = reservationInvoiceReport.xrCellRoom.WidthF;
                        cell5.WidthF = reservationInvoiceReport.xrCellRate.WidthF;
                        cell6.WidthF = reservationInvoiceReport.xrCellNights.WidthF;
                        cell7.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                        cell1.TextAlignment = reservationInvoiceReport.xrCellCustomerName.TextAlignment;
                        cell2.TextAlignment = reservationInvoiceReport.xrCellCheckIn.TextAlignment;
                        cell3.TextAlignment = reservationInvoiceReport.xrCellCheckOut.TextAlignment;
                        cell4.TextAlignment = reservationInvoiceReport.xrCellRoom.TextAlignment;
                        cell5.TextAlignment = reservationInvoiceReport.xrCellRate.TextAlignment;
                        cell6.TextAlignment = reservationInvoiceReport.xrCellNights.TextAlignment;
                        cell7.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                        cell1.Text = dsRoomInfo.Tables[0].Rows[i]["Sharers"] != null ? dsRoomInfo.Tables[0].Rows[i]["Sharers"].ToString() : string.Empty;
                        cell2.Text = dsRoomInfo.Tables[0].Rows[i]["CheckInDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckInDate"].ToString() : string.Empty;
                        cell3.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString() : string.Empty;
                        //cell4.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString() : string.Empty;
                        //cell5.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;                   
                        cell6.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;
                        cell7.Text = dsRoomInfo.Tables[0].Rows[i]["Amount"] != null ? dsRoomInfo.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                        roomInfoTotal = roomInfoTotal + Convert.ToDecimal(cell7.Text);
                    }
                }

                //// Add total row
                XRTableCell cellFooter1 = new XRTableCell();
                XRTableCell cellFooter2 = new XRTableCell();
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = roomInfoTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowFooter);
            }


            //// Payment section
            if (dsPaymentSection != null && dsPaymentSection.Tables.Count > 0 && dsPaymentSection.Tables[0] != null && dsPaymentSection.Tables[0].Rows.Count > 0)
            {
                //decimal paymentTotal;
                //paymentTotal = 0;

                for (int i = 0; i <= dsRoomInfo.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == 0)
                    {

                    }
                    else
                    {

                    }

                }

            }

            rvReportViewer.Report = reservationInvoiceReport;
        }

    }
}
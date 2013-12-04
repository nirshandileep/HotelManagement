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
            reservation.ReservationId = 49;
            reservation = reservation.Select();

            reservationInvoiceReport.xrCellInvoiceNo.Text = "Invoice No - INV" + reservation.ReservationId.ToString();
            reservationInvoiceReport.xrCellInvoiceDate.Text = "Invoice Date - "+ DateTime.Now.ToString();
            reservationInvoiceReport.xrCellReservationCode.Text = "Code - " + reservation.ReservationCode;
            reservationInvoiceReport.xrCellReservationDate.Text = "Booking Date - "+reservation.BookingDate.ToString();

            reservationInvoiceReport.xrCellCustomer.Text = "";
            reservationInvoiceReport.xrCellCompanyName.Text = "";
            reservationInvoiceReport.xrCellCompnayAddress.Text = "";


            DataSet dsRoomInfo = new DataSet();
            dsRoomInfo = reservation.ReservationRoomDataSet;


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
                        reservationInvoiceReport.xrCellCheckIn.Text = dsRoomInfo.Tables[0].Rows[i]["CheckInDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckInDate"].ToString()).ToShortDateString() : string.Empty;
                        reservationInvoiceReport.xrCellCheckOut.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString()).ToShortDateString() : string.Empty;
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
                        cell2.Text = dsRoomInfo.Tables[0].Rows[i]["CheckInDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckInDate"].ToString()).ToShortDateString() : string.Empty;
                        cell3.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString()).ToShortDateString() : string.Empty;
                        //cell4.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString() : string.Empty;
                        //cell5.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;                   
                        cell6.Text = dsRoomInfo.Tables[0].Rows[i]["Days"] != null ? dsRoomInfo.Tables[0].Rows[i]["Days"].ToString() : string.Empty;
                        cell7.Text = dsRoomInfo.Tables[0].Rows[i]["Amount"] != null ? dsRoomInfo.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                        roomInfoTotal = roomInfoTotal + Convert.ToDecimal(cell7.Text);

                        XRTableRow dataRow = new XRTableRow();
                        dataRow.Cells.Add(cell1);
                        dataRow.Cells.Add(cell2);
                        dataRow.Cells.Add(cell3);
                        dataRow.Cells.Add(cell4);
                        dataRow.Cells.Add(cell5);
                        dataRow.Cells.Add(cell6);
                        dataRow.Cells.Add(cell7);

                        cell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF;
                        cell2.WidthF = reservationInvoiceReport.xrCellCheckIn.WidthF;
                        cell3.WidthF = reservationInvoiceReport.xrCellCheckOut.WidthF;
                        cell4.WidthF = reservationInvoiceReport.xrCellRoom.WidthF;
                        cell5.WidthF = reservationInvoiceReport.xrCellRate.WidthF;
                        cell6.WidthF=reservationInvoiceReport.xrCellNights.WidthF;
                        cell7.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                        cell1.TextAlignment = reservationInvoiceReport.xrCellCustomerName.TextAlignment;
                        cell2.TextAlignment = reservationInvoiceReport.xrCellCheckIn.TextAlignment;
                        cell3.TextAlignment = reservationInvoiceReport.xrCellCheckOut.TextAlignment;
                        cell4.TextAlignment = reservationInvoiceReport.xrCellRoom.TextAlignment;
                        cell5.TextAlignment = reservationInvoiceReport.xrCellRate.TextAlignment;
                        cell6.TextAlignment = reservationInvoiceReport.xrCellNights.TextAlignment;
                        cell7.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                        reservationInvoiceReport.xrTableRoomInfo.Rows.Add(dataRow);

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

            //// Additional Service section

            DataSet dsAdditionalService = new DataSet();
            dsAdditionalService = reservation.ReservationAdditionalServiceDataSet;



            if (dsAdditionalService != null && dsAdditionalService.Tables.Count > 0 && dsAdditionalService.Tables[0] != null && dsAdditionalService.Tables[0].Rows.Count > 0)
            {
                XRTableCell blankCell = new XRTableCell();
                blankCell.Text = " ";
                XRTableRow blankRow = new XRTableRow();
                blankRow.Cells.Add(blankCell);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(blankRow);

                XRTableCell cell1 = new XRTableCell();
                XRTableCell cell2 = new XRTableCell();
                XRTableCell cell3 = new XRTableCell();

                cell1.Text = "Service Type";
                cell2.Text = "Note";
                cell3.Text = "Amount";

                cell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF;
                cell2.WidthF = reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cell3.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                XRTableRow headerRow = new XRTableRow();
                headerRow.Cells.Add(cell1);
                headerRow.Cells.Add(cell2);
                headerRow.Cells.Add(cell3);

                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(headerRow);

                decimal serviceTotal;
                serviceTotal = 0;

                for (int i = 0; i <= dsAdditionalService.Tables[0].Rows.Count - 1; i++)
                {
                    XRTableCell dataCell1 = new XRTableCell();
                    XRTableCell dataCell2 = new XRTableCell();
                    XRTableCell dataCell3 = new XRTableCell();

                    //dataCell1.Text = dsAdditionalService.Tables[0].Rows[i]["ServiceType"] != null ? dsAdditionalService.Tables[0].Rows[i]["ServiceType"].ToString() : string.Empty;
                    dataCell2.Text = dsAdditionalService.Tables[0].Rows[i]["Note"] != null ? dsAdditionalService.Tables[0].Rows[i]["Note"].ToString() : string.Empty;
                    dataCell3.Text = dsAdditionalService.Tables[0].Rows[i]["Amount"] != null ? dsAdditionalService.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                    serviceTotal = serviceTotal + Convert.ToDecimal(dataCell3.Text);


                    dataCell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF ;
                    dataCell2.WidthF =  reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                    dataCell3.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                    dataCell3.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                    XRTableRow dataRow = new XRTableRow();
                    dataRow.Cells.Add(dataCell1);
                    dataRow.Cells.Add(dataCell2);
                    dataRow.Cells.Add(dataCell3);

                    reservationInvoiceReport.xrTableRoomInfo.Rows.Add(dataRow);

                }

                XRTableCell cellFooter1 = new XRTableCell();
                XRTableCell cellFooter2 = new XRTableCell();
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = serviceTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellPaidAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowFooter);

            }


            //// Payment section
            DataSet dsPaymentSection = new DataSet();
            dsPaymentSection = reservation.ReservationPaymentDataSet;

            if (dsPaymentSection != null && dsPaymentSection.Tables.Count > 0 && dsPaymentSection.Tables[0] != null && dsPaymentSection.Tables[0].Rows.Count > 0)
            {
                decimal paymentTotal;
                paymentTotal = 0;

                for (int i = 0; i <= dsPaymentSection.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        //reservationInvoiceReport.xrCellPaymentType.Text = dsPaymentSection.Tables[0].Rows[i]["Sharers"] != null ? dsPaymentSection.Tables[0].Rows[i]["Sharers"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellPaymentDate.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentDate"] != null ? Convert.ToDateTime(dsPaymentSection.Tables[0].Rows[i]["PaymentDate"].ToString()).ToShortDateString() : string.Empty;
                        //reservationInvoiceReport.xrCellCardType.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentDate"] != null ? dsPaymentSection.Tables[0].Rows[i]["PaymentDate"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellCardNo.Text = dsPaymentSection.Tables[0].Rows[i]["CCNo"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNo"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellNameOnCard.Text = dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellPaidAmount.Text = dsPaymentSection.Tables[0].Rows[i]["Amount"] != null ? dsPaymentSection.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;
                        paymentTotal = Convert.ToDecimal(reservationInvoiceReport.xrCellPaidAmount.Text);

                    }
                    else
                    {
                        XRTableCell cell1 = new XRTableCell();
                        XRTableCell cell2 = new XRTableCell();
                        XRTableCell cell3 = new XRTableCell();
                        XRTableCell cell4 = new XRTableCell();
                        XRTableCell cell5 = new XRTableCell();
                        XRTableCell cell6 = new XRTableCell();

                        cell1.WidthF = reservationInvoiceReport.xrCellPaymentType.WidthF;
                        cell2.WidthF = reservationInvoiceReport.xrCellPaymentDate.WidthF;
                        cell3.WidthF = reservationInvoiceReport.xrCellCardType.WidthF;
                        cell4.WidthF = reservationInvoiceReport.xrCellCardNo.WidthF;
                        cell5.WidthF = reservationInvoiceReport.xrCellNameOnCard.WidthF;
                        cell6.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                        cell1.TextAlignment = reservationInvoiceReport.xrCellPaymentType.TextAlignment;
                        cell2.TextAlignment = reservationInvoiceReport.xrCellPaymentDate.TextAlignment;
                        cell3.TextAlignment = reservationInvoiceReport.xrCellCardType.TextAlignment;
                        cell4.TextAlignment = reservationInvoiceReport.xrCellCardNo.TextAlignment;
                        cell5.TextAlignment = reservationInvoiceReport.xrCellNameOnCard.TextAlignment;
                        cell6.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                        //cell1.Text = dsPaymentSection.Tables[0].Rows[i]["Sharers"] != null ? dsPaymentSection.Tables[0].Rows[i]["Sharers"].ToString() : string.Empty;
                        cell2.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentDate"] != null ? Convert.ToDateTime(dsPaymentSection.Tables[0].Rows[i]["PaymentDate"].ToString()).ToShortDateString() : string.Empty;
                        //cell3.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentDate"] != null ? dsPaymentSection.Tables[0].Rows[i]["PaymentDate"].ToString() : string.Empty;
                        cell4.Text = dsPaymentSection.Tables[0].Rows[i]["CCNo"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNo"].ToString() : string.Empty;
                        cell5.Text = dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"].ToString() : string.Empty;
                        cell6.Text = dsPaymentSection.Tables[0].Rows[i]["Amount"] != null ? dsPaymentSection.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                        paymentTotal = paymentTotal + Convert.ToDecimal(cell6.Text);

                    }

                }

                //// Add total row
                XRTableCell cellFooter1 = new XRTableCell();
                XRTableCell cellFooter2 = new XRTableCell();
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellPaymentType.WidthF + reservationInvoiceReport.xrCellPaymentDate.WidthF + reservationInvoiceReport.xrCellCardType.WidthF + reservationInvoiceReport.xrCellCardNo.WidthF + reservationInvoiceReport.xrCellNameOnCard.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = paymentTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellPaidAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTablePayment.Rows.Add(tableRowFooter);

            }

            rvReportViewer.Report = reservationInvoiceReport;
        }

    }
}
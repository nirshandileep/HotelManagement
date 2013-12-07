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
using System.Text;
using HBM.CompanyManagement;
using HBM.SessionManager;

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

            if (Request.QueryString["ReservationID"] != null && Request.QueryString["ReservationID"] != string.Empty)
            {
                reservation.ReservationId = Convert.ToInt32(Request.QueryString["ReservationID"].ToString());
            }
            else
            {
                return;
            }
            
            reservation = reservation.Select();

            reservationInvoiceReport.xrCellInvoiceNo.Text = "Invoice No - INV" + reservation.ReservationId.ToString();
            reservationInvoiceReport.xrCellInvoiceDate.Text = "Invoice Date - " + DateTime.Now.ToString();
            reservationInvoiceReport.xrCellReservationCode.Text = "Code - " + reservation.ReservationCode;
            reservationInvoiceReport.xrCellReservationDate.Text = "Booking Date - " + reservation.BookingDate.ToString();

            StringBuilder sbCustomer = new StringBuilder();
            sbCustomer.Append(reservation.CustomerName + Environment.NewLine);
            sbCustomer.Append(reservation.BillingAddressLine1 + Environment.NewLine);
            sbCustomer.Append(reservation.BillingAddressLine2 + Environment.NewLine);
            sbCustomer.Append(reservation.BillingCity + ", ");
            sbCustomer.Append(reservation.BillingPostCode + Environment.NewLine);
            sbCustomer.Append(reservation.BillingState + ", " + reservation.CountryName);

            reservationInvoiceReport.xrCellCustomer.Text = sbCustomer.ToString();

            Company company = new Company();
            company.CompanyId = SessionHandler.CurrentCompanyId;
            company = company.Select();
            reservationInvoiceReport.xrCellCompanyName.Text = company.CompanyName;

            StringBuilder sbCompany = new StringBuilder();
            sbCompany.Append(company.CompanyAddress + Environment.NewLine);
            sbCompany.Append(company.CompanyCity + Environment.NewLine);
            sbCompany.Append(company.CompanyEmail + Environment.NewLine);
            sbCompany.Append("Tel - " + company.CompanyTelephone + Environment.NewLine);
            sbCompany.Append("Fax - " + company.CompanyFax);

            reservationInvoiceReport.xrCellCompnayAddress.Text = sbCompany.ToString();

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
                        reservationInvoiceReport.xrCellRoom.Text = dsRoomInfo.Tables[0].Rows[i]["RoomName"] != null ? dsRoomInfo.Tables[0].Rows[i]["RoomName"].ToString() : string.Empty;
                        reservationInvoiceReport.xrCellRate.Text = dsRoomInfo.Tables[0].Rows[i]["Rate"] != null ? dsRoomInfo.Tables[0].Rows[i]["Rate"].ToString() : string.Empty;                   
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

                        cell1.Text = dsRoomInfo.Tables[0].Rows[i]["Sharers"] != null ? dsRoomInfo.Tables[0].Rows[i]["Sharers"].ToString() : string.Empty;
                        cell2.Text = dsRoomInfo.Tables[0].Rows[i]["CheckInDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckInDate"].ToString()).ToShortDateString() : string.Empty;
                        cell3.Text = dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"] != null ? Convert.ToDateTime(dsRoomInfo.Tables[0].Rows[i]["CheckOutDate"].ToString()).ToShortDateString() : string.Empty;
                        cell4.Text = dsRoomInfo.Tables[0].Rows[i]["RoomName"] != null ? dsRoomInfo.Tables[0].Rows[i]["RoomName"].ToString() : string.Empty;
                        cell5.Text = dsRoomInfo.Tables[0].Rows[i]["Rate"] != null ? dsRoomInfo.Tables[0].Rows[i]["Rate"].ToString() : string.Empty;                   
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
                        cell6.WidthF = reservationInvoiceReport.xrCellNights.WidthF;
                        cell7.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                        cell1.TextAlignment = reservationInvoiceReport.xrCellCustomerName.TextAlignment;                        
                        cell7.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                        reservationInvoiceReport.xrTableRoomInfo.Rows.Add(dataRow);

                    }
                }

                //// Add total row
                XRTableCell cellFooter1 = new XRTableCell();
                XRTableCell cellFooter2 = new XRTableCell();

                cellFooter1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cellFooter2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Room Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = roomInfoTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowFooter);

                XRTableCell blankCell = new XRTableCell();
                blankCell.Text = " ";
                blankCell.BackColor = System.Drawing.Color.LightGray;
                XRTableRow blankRow = new XRTableRow();
                blankRow.Cells.Add(blankCell);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(blankRow);
            }

            //// Additional Service section

            DataSet dsAdditionalService = new DataSet();
            dsAdditionalService = reservation.ReservationAdditionalServiceDataSet;

            if (dsAdditionalService != null && dsAdditionalService.Tables.Count > 0 && dsAdditionalService.Tables[0] != null && dsAdditionalService.Tables[0].Rows.Count > 0)
            {            

                XRTableCell cell1 = new XRTableCell();
                XRTableCell cell2 = new XRTableCell();
                XRTableCell cell3 = new XRTableCell();

                cell1.Text = "Service Type";
                cell2.Text = "Note";
                cell3.Text = "Amount";

                cell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF;
                cell2.WidthF = reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cell3.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;

                cell1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);


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

                    dataCell1.Text = dsAdditionalService.Tables[0].Rows[i]["ServiceName"] != null ? dsAdditionalService.Tables[0].Rows[i]["ServiceName"].ToString() : string.Empty;
                    dataCell2.Text = dsAdditionalService.Tables[0].Rows[i]["Note"] != null ? dsAdditionalService.Tables[0].Rows[i]["Note"].ToString() : string.Empty;
                    dataCell3.Text = dsAdditionalService.Tables[0].Rows[i]["Amount"] != null ? dsAdditionalService.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                    serviceTotal = serviceTotal + Convert.ToDecimal(dataCell3.Text);
                    
                    dataCell1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF;
                    dataCell2.WidthF = reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
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
                
                cellFooter1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cellFooter2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Service Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = serviceTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowFooter);

                XRTableCell blankCell1 = new XRTableCell();
                blankCell1.Text = " ";
                blankCell1.BackColor = System.Drawing.Color.LightGray;
                XRTableRow blankRow1 = new XRTableRow();
                blankRow1.Cells.Add(blankCell1);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(blankRow1);
            }

            //// Display Net Total
            XRTableRow tableRowNetTotal = new XRTableRow();
            XRTableCell cellNetTotal1= new XRTableCell();
            XRTableCell cellNetTotal2= new XRTableCell();
            cellNetTotal1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellNetTotal2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellNetTotal1.Text = "Net Total";
            cellNetTotal2.Text = reservation.NetTotal.ToString();
            cellNetTotal1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellNetTotal2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;            
            cellNetTotal1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellNetTotal2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
            tableRowNetTotal.Cells.Add(cellNetTotal1);
            tableRowNetTotal.Cells.Add(cellNetTotal2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowNetTotal);
            
            //// Display Discount
            XRTableRow tableRowDiscount= new XRTableRow();
            XRTableCell cellDiscount1 = new XRTableCell();
            XRTableCell cellDiscount2 = new XRTableCell();
            cellDiscount1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellDiscount2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellDiscount1.Text = "Discount";
            cellDiscount2.Text = reservation.Discount.ToString();
            cellDiscount1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellDiscount2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
            cellDiscount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellDiscount2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
            tableRowDiscount.Cells.Add(cellDiscount1);
            tableRowDiscount.Cells.Add(cellDiscount2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowDiscount);


            //// Display Tax Amount
            XRTableRow tableRowTaxType = new XRTableRow();
            XRTableCell cellTaxType1 = new XRTableCell();
            XRTableCell cellTaxType2 = new XRTableCell();
            cellTaxType1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellTaxType2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellTaxType1.Text = "Tax Amount";
            cellTaxType2.Text = reservation.TaxAmount.ToString();
            cellTaxType1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellTaxType2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
            cellTaxType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellTaxType2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
            tableRowTaxType.Cells.Add(cellTaxType1);
            tableRowTaxType.Cells.Add(cellTaxType2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowTaxType);
            

            //// Display Total
            XRTableRow tableRowTotal = new XRTableRow();
            XRTableCell cellTotal1 = new XRTableCell();
            XRTableCell cellTotal2 = new XRTableCell();
            cellTotal1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellTotal2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellTotal1.Text = "Total";
            cellTotal2.Text = reservation.Total.ToString();
            cellTotal1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellTotal2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
            cellTotal1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellTotal2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
            tableRowTotal.Cells.Add(cellTotal1);
            tableRowTotal.Cells.Add(cellTotal2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowTotal);
            
            //// Display Paid Amount
            XRTableRow tableRowPaidAmount = new XRTableRow();
            XRTableCell cellPaidAmount1 = new XRTableCell();
            XRTableCell cellPaidAmount2 = new XRTableCell();
            cellPaidAmount1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellPaidAmount2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellPaidAmount1.Text = "Paid Amount";
            cellPaidAmount2.Text = reservation.PaidAmount.ToString();
            cellPaidAmount1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellPaidAmount2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
            cellPaidAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellPaidAmount2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
            tableRowPaidAmount.Cells.Add(cellPaidAmount1);
            tableRowPaidAmount.Cells.Add(cellPaidAmount2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowPaidAmount);
            
            //// Display Balance
            XRTableRow tableRowBalance = new XRTableRow();
            XRTableCell cellBalance1 = new XRTableCell();
            XRTableCell cellBalance2 = new XRTableCell();
            cellBalance1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellBalance2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            cellBalance1.Text = "Balance";
            cellBalance2.Text = reservation.Balance.ToString();
            cellBalance1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
            cellBalance2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
            cellBalance1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cellBalance2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
                        
            tableRowBalance.Cells.Add(cellBalance2);
            reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowBalance);           

            //// Payment section
            DataSet dsPaymentSection = new DataSet();
            dsPaymentSection = reservation.ReservationPaymentDataSet;

            if (dsPaymentSection != null && dsPaymentSection.Tables.Count > 0 && dsPaymentSection.Tables[0] != null && dsPaymentSection.Tables[0].Rows.Count > 0)
            {

                XRTableCell blankCell = new XRTableCell();
                blankCell.Text = " ";
                blankCell.BackColor = System.Drawing.Color.LightGray;
                XRTableRow blankRow = new XRTableRow();
                blankRow.Cells.Add(blankCell);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(blankRow);

                XRTableCell cell1 = new XRTableCell();
                XRTableCell cell2 = new XRTableCell();
                XRTableCell cell3 = new XRTableCell();
                XRTableCell cell4 = new XRTableCell();
                XRTableCell cell5 = new XRTableCell();
                XRTableCell cell6 = new XRTableCell();

                cell1.Text = "Type";
                cell2.Text = "Payment Date";
                cell3.Text = "Card Type";
                cell4.Text = "Card No";
                cell5.Text = "Name on Card";
                cell6.Text = "Amount";

                cell1.WidthF = 110;
                cell2.WidthF = 126;
                cell3.WidthF = 99;
                cell4.WidthF = 161;
                cell5.WidthF = 168;
                cell6.WidthF = 117;

                cell1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cell6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                
                XRTableRow headerRow = new XRTableRow();
                headerRow.Cells.Add(cell1);
                headerRow.Cells.Add(cell2);
                headerRow.Cells.Add(cell3);
                headerRow.Cells.Add(cell4);
                headerRow.Cells.Add(cell5);
                headerRow.Cells.Add(cell6);

                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(headerRow);
                
                decimal paymentTotal;
                paymentTotal = 0;

                for (int i = 0; i <= dsPaymentSection.Tables[0].Rows.Count - 1; i++)
                {
                    
                        XRTableCell dataCell1 = new XRTableCell();
                        XRTableCell dataCell2 = new XRTableCell();
                        XRTableCell dataCell3 = new XRTableCell();
                        XRTableCell dataCell4 = new XRTableCell();
                        XRTableCell dataCell5 = new XRTableCell();
                        XRTableCell dataCell6 = new XRTableCell();
                        
                        dataCell1.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentTypeName"] != null ? dsPaymentSection.Tables[0].Rows[i]["PaymentTypeName"].ToString() : string.Empty;
                        dataCell2.Text = dsPaymentSection.Tables[0].Rows[i]["PaymentDate"] != null ? Convert.ToDateTime(dsPaymentSection.Tables[0].Rows[i]["PaymentDate"].ToString()).ToShortDateString() : string.Empty;
                        dataCell3.Text = dsPaymentSection.Tables[0].Rows[i]["Name"] != null ? dsPaymentSection.Tables[0].Rows[i]["Name"].ToString() : string.Empty;
                        dataCell4.Text = dsPaymentSection.Tables[0].Rows[i]["CCNo"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNo"].ToString() : string.Empty;
                        dataCell5.Text = dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"] != null ? dsPaymentSection.Tables[0].Rows[i]["CCNameOnCard"].ToString() : string.Empty;
                        dataCell6.Text = dsPaymentSection.Tables[0].Rows[i]["Amount"] != null ? dsPaymentSection.Tables[0].Rows[i]["Amount"].ToString() : string.Empty;

                        paymentTotal = paymentTotal + Convert.ToDecimal(dataCell6.Text);

                        dataCell1.WidthF = 110;
                        dataCell2.WidthF = 126;
                        dataCell3.WidthF = 99;
                        dataCell4.WidthF = 161;
                        dataCell5.WidthF = 168;
                        dataCell6.WidthF = 117;

                        dataCell6.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;

                        XRTableRow dataRow = new XRTableRow();
                        dataRow.Cells.Add(dataCell1);
                        dataRow.Cells.Add(dataCell2);
                        dataRow.Cells.Add(dataCell3);
                        dataRow.Cells.Add(dataCell4);
                        dataRow.Cells.Add(dataCell5);
                        dataRow.Cells.Add(dataCell6);
                        
                        reservationInvoiceReport.xrTableRoomInfo.Rows.Add(dataRow);                    

                }

                XRTableCell cellFooter1 = new XRTableCell();
                XRTableCell cellFooter2 = new XRTableCell();

                cellFooter1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                cellFooter2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                
                XRTableRow tableRowFooter = new XRTableRow();
                cellFooter1.WidthF = reservationInvoiceReport.xrCellCustomerName.WidthF + reservationInvoiceReport.xrCellCheckIn.WidthF + reservationInvoiceReport.xrCellCheckOut.WidthF + reservationInvoiceReport.xrCellRoom.WidthF + reservationInvoiceReport.xrCellRate.WidthF + reservationInvoiceReport.xrCellNights.WidthF;
                cellFooter2.WidthF = reservationInvoiceReport.xrCellAmount.WidthF;
                cellFooter1.Text = "Total";
                cellFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellFooter2.Text = paymentTotal.ToString();
                cellFooter2.TextAlignment = reservationInvoiceReport.xrCellAmount.TextAlignment;
                tableRowFooter.Cells.Add(cellFooter1);
                tableRowFooter.Cells.Add(cellFooter2);
                reservationInvoiceReport.xrTableRoomInfo.Rows.Add(tableRowFooter);

            }

            rvReportViewer.Report = reservationInvoiceReport;
        }

    }
}
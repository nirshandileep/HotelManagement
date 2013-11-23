<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="SearchReservation.aspx.cs" Inherits="HBM.Reservation.SearchReservation" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="wrapper-inner">
        <h2>
            Reservation List</h2>
        <table width="900">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvReservation" runat="server" AutoGenerateColumns="False" 
                        KeyFieldName="ReservationId" Width="100%">
                        <Columns>                         
                            <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Customer Name" 
                                FieldName="CustomerName" Width="250px" UnboundType="String">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                                <DataItemTemplate>
                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Booking.aspx?ReservationId=",Eval("ReservationId").ToString()) %>'
                                        Text='<%# Eval("CustomerName") %>' />
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ReservationCode" VisibleIndex="2" 
                                Width="100px" Caption="Reservation Code">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="BookingDate" UnboundType="String" 
                                VisibleIndex="3" Width="150px" Caption="Booking Date">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ReservationId" Visible="False" 
                                VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Check In" FieldName="CheckInDate" UnboundType="String"
                                VisibleIndex="4" Width="150px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CheckOutDate" UnboundType="String" 
                                VisibleIndex="5" Caption="Check Out">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Settings ShowFilterRow="True" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

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
            Search Reservations</h2>
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
                            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Customer Name" 
                                FieldName="CustomerName" Width="150px" UnboundType="String">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                                <DataItemTemplate>
                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Reservation.aspx?ReservationId=",Eval("ReservationId").ToString()) %>'
                                        Text='<%# Eval("CustomerName") %>' />
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="2" Caption="Phone">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mobile" FieldName="Mobile" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Code" FieldName="ReservationCode" 
                                VisibleIndex="1" Width="100px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="BookingDate" UnboundType="String" 
                                VisibleIndex="5" Width="150px" Caption="Booking Date">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ReservationId" Visible="False" 
                                VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn Caption="Check In" FieldName="CheckInDate" 
                                UnboundType="String" VisibleIndex="6" Width="100px">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="Check Out" FieldName="CheckOutDate" 
                                UnboundType="String" VisibleIndex="7" Width="100px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn Caption="Status" 
                                FieldName="StatusName" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="Control" />
                        <Settings ShowFilterRow="True" HorizontalScrollBarMode="Visible" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

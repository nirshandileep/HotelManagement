<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Reservation.aspx.cs" Inherits="HBM.Reservation.Reservation" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            Code
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtResCode" runat="server" Width="170px">
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            Status
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbResStatus" runat="server" ValueType="System.Int32">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            Source
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbSource" runat="server" ValueType="System.Int32">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnAddSource" runat="server" Text="..." Visible="False">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnReservationId" runat="server" Value="0" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnFromURL" runat="server" />
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td title="Reservation">&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Booking Time
                        </td>
                        <td>
                            <dx:ASPxTimeEdit ID="teBookingTime" runat="server" EditFormat="DateTime">
                            </dx:ASPxTimeEdit>
                        </td>
                        <td>
                            User
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtUser" runat="server" Width="170px" Enabled="False">
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            Guarantee
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbGuarantee" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnAddGuarantee" runat="server" Text="..." Visible="False">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                        <td>&nbsp;
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <dx:ASPxRoundPanel ID="rpRoomInformation" runat="server" Width="98%" 
                                HeaderText="Room Information" HorizontalAlign="Justify">
                                <PanelCollection>
                                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                        <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                Customer
                                                            </td>
                                                            <td valign="top">
                                                                <dx:ASPxComboBox ID="cmbCustomerName" runat="server" ValueType="System.Int32" 
                                                                    TextFormatString="{0} ({2})" DropDownStyle="DropDown" 
                                                                    IncrementalFilteringMode="Contains">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="CustomerId" Visible="False" />
                                                                        <dx:ListBoxColumn FieldName="CustomerName" />
                                                                        <dx:ListBoxColumn FieldName="MemberCode" />
                                                                        <dx:ListBoxColumn FieldName="GuestTypeName" />
                                                                        <dx:ListBoxColumn FieldName="Email" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;</td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Check In
                                                            </td>
                                                            <td valign="top">
                                                                <dx:ASPxTimeEdit ID="teCheckIn" runat="server" EditFormat="DateTime">
                                                                </dx:ASPxTimeEdit>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Check Out
                                                            </td>
                                                            <td valign="top">
                                                                <dx:ASPxTimeEdit ID="teCheckOut" runat="server" EditFormat="DateTime">
                                                                </dx:ASPxTimeEdit>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;</td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                            <td>&nbsp;
                                                                </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxGridView ID="gvRoomDetails" runat="server" Width="100%">
                                                    </dx:ASPxGridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxRoundPanel>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td valign="top">
                                    <div style="margin-bottom:10px;">
                                        <dx:ASPxRoundPanel ID="rpPaymentInformation" runat="server" Width="100%" HeaderText="Payment Information">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvPaymentInformation" runat="server" Width="100%">
                                                    </dx:ASPxGridView>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxRoundPanel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxRoundPanel ID="rpServiceInformation" runat="server" Width="100%" HeaderText="Service Information">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvServiceInformation" runat="server" Width="100%">
                                                    </dx:ASPxGridView>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxRoundPanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
            <div style="margin-top:10px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" title="Room" width="100%">
                                <tr>
                                    <td>
                                        Room Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtRoomTotal" runat="server" Width="170px" ReadOnly="True">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Service Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtServiceTotal" runat="server" Width="170px" ReadOnly="True">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Net Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNetTotal" runat="server" Width="170px" ReadOnly="True">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" title="Guest" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" title="Room" width="100%">
                                            <tr>
                                                <td>
                                                    Discount
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="txtDiscount" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tax
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox ID="cmbTax" runat="server" ValueType="System.String">
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tax Total
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="txtTaxTotal" runat="server" Width="170px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" title="Billing" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" title="Room" width="100%">
                                            <tr>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" Width="170px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Paid
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" Width="170px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Balance
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" Width="170px" ReadOnly="True">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                    
                                                </td>
                                                <td>&nbsp;
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
            <table>
            <tr>
            	<td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" ImageSpacing="15px">
                </dx:ASPxButton>
                <Image Url="~/Images/Save.png" width="16" height="16">
                        </Image>
                </td>
                <td>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel">
                </dx:ASPxButton>
                </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxPopupControl ID="ppcPageLoader" runat="server">
                </dx:ASPxPopupControl>
            </td>
        </tr>
    </table>
</asp:Content>

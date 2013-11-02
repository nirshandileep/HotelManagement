<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Reservation.aspx.cs" Inherits="HBM.Reservation.Reservation" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ MasterType VirtualPath="~/HBMMaster.Master" %>
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
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HiddenField ID="hdnReservationId" runat="server" Value="0" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnFromURL" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td title="Reservation">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" title="Room Information" width="100%">
                                <tr>
                                    <td>
                                        Check In
                                    </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="dtpCheckIn" runat="server">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Check Out
                                    </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="dtpCheckOut" runat="server">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Adult No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="seNumberOfAdults" runat="server" Height="21px" Number="0" 
                                            NumberType="Integer">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Child No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="seNumberOfChildren" runat="server" Height="21px" 
                                            Number="0" NumberType="Integer">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Infant No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="seNumberOfInfants" runat="server" Height="21px" Number="0" 
                                            NumberType="Integer">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Room
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbRooms" runat="server" ValueType="System.Int32">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Rate Plan</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbRatePlan" runat="server" ValueType="System.Int32">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <div>
                                <dx:ASPxGridView ID="gvRooms" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTimeEditColumn Caption="Date" FieldName="CheckInDate" UnboundType="DateTime"
                                            VisibleIndex="0">
                                            <PropertiesTimeEdit DisplayFormatString="" EditFormat="DateTime">
                                            </PropertiesTimeEdit>
                                        </dx:GridViewDataTimeEditColumn>
                                        <dx:GridViewDataTextColumn FieldName="Rate" UnboundType="Decimal" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsPager Mode="ShowAllRecords">
                                    </SettingsPager>
                                </dx:ASPxGridView>
                            </div>
                        </td>
                        <td>
                            <table title="Guest Information" width="100%">
                                <tr>
                                    <td>
                                        Guest Name
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtGuestName" runat="server" Width="170px" Enabled="False">
                                        </dx:ASPxTextBox>
                                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="CustomerName" />
                                                <dx:ListBoxColumn FieldName="MemberCode" />
                                                <dx:ListBoxColumn FieldName="GuestTypeName" />
                                                <dx:ListBoxColumn FieldName="Phone" />
                                                <dx:ListBoxColumn FieldName="CompanyName" />
                                                <dx:ListBoxColumn FieldName="Email" />
                                                <dx:ListBoxColumn FieldName="DriverLicense" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                        <dx:ASPxButton ID="txtSelectGuest" runat="server" Text="...">
                                        </dx:ASPxButton>
                                        <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Company
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtGuestCompany" runat="server" Width="170px" Enabled="False">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                                            <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                <RegularExpression ErrorText="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Phone
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtPhone" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Special Requirement
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtSpecialRequirement" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <div>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" title="Payment Information">
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnAddPayment" runat="server" Text="Add Payment">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="gvPayments" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <dx:GridViewDataTimeEditColumn Caption="Date" FieldName="PaymentDate" UnboundType="DateTime"
                                                        VisibleIndex="0">
                                                        <PropertiesTimeEdit DisplayFormatString="" EditFormat="DateTime">
                                                        </PropertiesTimeEdit>
                                                    </dx:GridViewDataTimeEditColumn>
                                                    <dx:GridViewDataTextColumn Caption="Payment Type" FieldName="PaymentTypeName" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Total" FieldName="PaymentAmount" UnboundType="Decimal"
                                                        VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager Mode="ShowAllRecords">
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" title="Billing Address" width="100%">
                                <tr>
                                    <td>
                                        Address
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtAddress" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        City
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtCity" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        State
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtState" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Country
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbCountry" runat="server" ValueType="System.Int32">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Post Code
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtPostCode" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <div>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnAddServices" runat="server" Text="Add Service">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="gvServices" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <dx:GridViewDataTimeEditColumn Caption="Date" VisibleIndex="0">
                                                        <PropertiesTimeEdit DisplayFormatString="" EditFormat="DateTime">
                                                        </PropertiesTimeEdit>
                                                    </dx:GridViewDataTimeEditColumn>
                                                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Rate" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataSpinEditColumn Caption="Qty" VisibleIndex="3">
                                                        <PropertiesSpinEdit DisplayFormatString="g" NumberType="Integer">
                                                        </PropertiesSpinEdit>
                                                    </dx:GridViewDataSpinEditColumn>
                                                    <dx:GridViewDataTextColumn Caption="Sub Total" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager Visible="False">
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save">
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel">
                </dx:ASPxButton>
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

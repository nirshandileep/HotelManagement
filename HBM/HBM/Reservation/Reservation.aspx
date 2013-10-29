<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Reservation.aspx.cs" Inherits="HBM.Reservation.Reservation" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
                            <dx:ASPxTextBox ID="txtCode" runat="server" Width="170px">
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            Status
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbStatus" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            Source
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbSource" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnAddSource" runat="server" Text="...">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Booking Time
                        </td>
                        <td>
                            <dx:ASPxTimeEdit ID="teBookingTime" runat="server">
                            </dx:ASPxTimeEdit>
                        </td>
                        <td>
                            User
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="tstUser" runat="server" Width="170px">
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
                            <dx:ASPxButton ID="btnAddGuarantee" runat="server" Text="...">
                            </dx:ASPxButton>
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
                            <table border="0" cellpadding="0" cellspacing="0" title="Room Information" width="100%">
                                <tr>
                                    <td>
                                        Check In
                                    </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Check Out
                                    </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server">
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Adult No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Height="21px" Number="0">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Child No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="ASPxSpinEdit2" runat="server" Height="21px" Number="0">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Infant No.
                                    </td>
                                    <td>
                                        <dx:ASPxSpinEdit ID="ASPxSpinEdit3" runat="server" Height="21px" Number="0">
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Room
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="...">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table title="Guest Information" width="100%">
                                <tr>
                                    <td>
                                        Guest Name
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="...">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Company
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phone
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Special Requirement
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
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
                                        City
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtCity" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
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
                                        Country
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbCountry" runat="server" ValueType="System.String">
                                        </dx:ASPxComboBox>
                                    </td>
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
                            </table>
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
                                    <td>Room Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtRoomTotal" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Service Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtServiceTotal" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Net Total
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNetTotal" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
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
                                                <td>Discount
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Tax
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String">
                                                    </dx:ASPxComboBox>
                                                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="...">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Tax Total
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
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
                                                <td>Total
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Paid
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Balance
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </td>
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
    </table>
</asp:Content>

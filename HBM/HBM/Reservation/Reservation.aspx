﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
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
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnReservationId" runat="server" Value="0" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnFromURL" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td title="Reservation">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Booking Time
                        </td>
                        <td>
                            <dx:ASPxDateEdit ID="dtpBookingTime" runat="server" EditFormat="DateTime">
                                <TimeSectionProperties Visible="True">
                                </TimeSectionProperties>
                            </dx:ASPxDateEdit>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
                            <dx:ASPxRoundPanel ID="rpRoomInformation" runat="server" Width="100%" HeaderText="Room Information"
                                HorizontalAlign="Justify">
                                <PanelCollection>
                                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                Customer
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbCustomerName" runat="server" ValueType="System.Int32" TextFormatString="{0}; {1}; {2}; {3}"
                                                                    DropDownStyle="DropDown" IncrementalFilteringMode="Contains">
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
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Check In
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpCheckIn" runat="server" EditFormat="DateTime">
                                                                    <TimeSectionProperties Visible="True">
                                                                    </TimeSectionProperties>
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Check Out
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpCheckOut" runat="server" EditFormat="DateTime">
                                                                    <TimeSectionProperties Visible="True">
                                                                    </TimeSectionProperties>
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                <dx:ASPxButton ID="btnAddRoomShow" runat="server" AutoPostBack="False" 
                                                                    Text="..." UseSubmitBehavior="False">
                                                                    <ClientSideEvents Click="function(s, e) { ShowPopupWindow(ppcAddRoom); }" />
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
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
                                    <td>
                                        <dx:ASPxRoundPanel ID="rpPaymentInformation" runat="server" Width="100%" HeaderText="Payment Information">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvPaymentInformation" runat="server" Width="100%" 
                                                        AutoGenerateColumns="False" KeyFieldName="ReservationPaymentId">
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                                VisibleIndex="0" Width="55px" Caption="Action">
                                                                <EditButton Visible="True">
                                                                    <Image ToolTip="Edit" Url="~/Images/update.png">
                                                                    </Image>
                                                                </EditButton>
                                                                <NewButton Visible="True">
                                                                    <Image ToolTip="Add" Url="~/Images/new.png">
                                                                    </Image>
                                                                </NewButton>
                                                                <DeleteButton Visible="True">
                                                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                                                    </Image>
                                                                </DeleteButton>
                                                                <CancelButton Visible="True">
                                                                    <Image Url="~/Images/Close.png">
                                                                    </Image>
                                                                </CancelButton>
                                                                <UpdateButton Visible="True">
                                                                    <Image ToolTip="Save" Url="~/Images/Apply.png">
                                                                    </Image>
                                                                </UpdateButton>
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="Amount" FieldName="PaymentAmount" 
                                                                ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="1">
                                                                <EditFormSettings Caption="Amount" Visible="True" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataDateColumn FieldName="PaymentDate" 
                                                                ShowInCustomizationForm="True" UnboundType="DateTime" VisibleIndex="2">
                                                                <PropertiesDateEdit DisplayFormatString="">
                                                                    <TimeSectionProperties Visible="True">
                                                                    </TimeSectionProperties>
                                                                </PropertiesDateEdit>
                                                                <EditFormSettings Caption="Payment Date" Visible="True" />
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn FieldName="ReferenceNumber" 
                                                                ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" 
                                                                UnboundType="String" VisibleIndex="4" Visible="False">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Payment Type" FieldName="PaymentTypeId" 
                                                                ShowInCustomizationForm="True" UnboundType="Integer" VisibleIndex="5">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Card Type" FieldName="CreditCardTypeId" 
                                                                ShowInCustomizationForm="True" UnboundType="Integer" Visible="False" 
                                                                VisibleIndex="6">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn Caption="Card No." FieldName="CCNo" 
                                                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataDateColumn Caption="Expiration Date" FieldName="ExpirationDate" 
                                                                ShowInCustomizationForm="True" UnboundType="DateTime" Visible="False" 
                                                                VisibleIndex="8">
                                                                <PropertiesDateEdit DisplayFormatString="">
                                                                </PropertiesDateEdit>
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn Caption="Name On Card" FieldName="CCNameOnCard" 
                                                                ShowInCustomizationForm="True" UnboundType="String" Visible="False" 
                                                                VisibleIndex="9">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior AllowGroup="False" ConfirmDelete="True" 
                                                            EnableCustomizationWindow="True" SortMode="DisplayText" />
                                                        <Settings ShowGroupButtons="False" />
                                                    </dx:ASPxGridView>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxRoundPanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxRoundPanel ID="rpServiceInformation" runat="server" Width="100%" HeaderText="Service Information">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvServiceInformation" runat="server" Width="100%" 
                                                        AutoGenerateColumns="False">
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" Caption="Action" 
                                                                ShowInCustomizationForm="True" VisibleIndex="0">
                                                                <EditButton Visible="True">
                                                                    <Image ToolTip="Edit" Url="~/Images/update.png">
                                                                    </Image>
                                                                </EditButton>
                                                                <NewButton Visible="True">
                                                                    <Image ToolTip="New" Url="~/Images/new.png">
                                                                    </Image>
                                                                </NewButton>
                                                                <DeleteButton Visible="True">
                                                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                                                    </Image>
                                                                </DeleteButton>
                                                                <CancelButton Visible="True">
                                                                    <Image Url="~/Images/Close.png">
                                                                    </Image>
                                                                </CancelButton>
                                                                <UpdateButton Visible="True">
                                                                    <Image ToolTip="Save" Url="~/Images/Apply.png">
                                                                    </Image>
                                                                </UpdateButton>
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Service Name" 
                                                                ShowInCustomizationForm="True" VisibleIndex="1">
                                                                <PropertiesComboBox DropDownStyle="DropDown" 
                                                                    TextFormatString="{0}; {1}; {2}; {3}" ValueType="System.Int32">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="AdditionalServiceId" Visible="False" />
                                                                        <dx:ListBoxColumn FieldName="ServiceName" />
                                                                        <dx:ListBoxColumn Caption="Code" FieldName="ServiceCode" />
                                                                        <dx:ListBoxColumn FieldName="Rate" />
                                                                        <dx:ListBoxColumn Caption="Type" FieldName="AdditionalServiceType" />
                                                                    </Columns>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn FieldName="ServiceCode" 
                                                                ShowInCustomizationForm="True" VisibleIndex="2" UnboundType="String">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Type" FieldName="AdditionalServiceType" 
                                                                ShowInCustomizationForm="True" VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Rate" ShowInCustomizationForm="True" 
                                                                VisibleIndex="4" UnboundType="Decimal">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Note" ShowInCustomizationForm="True" 
                                                                VisibleIndex="5" UnboundType="String">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior AllowGroup="False" SortMode="DisplayText" />
                                                        <Settings ShowGroupButtons="False" />
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
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
                <dx:ASPxPopupControl ID="ppcAddRoom" runat="server" 
                    ClientInstanceName="ppcAddRoom" HeaderText="Add Rooms" 
                    AllowDragging="True" AllowResize="True" Modal="True">
                    <ContentCollection>
                        <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            Adult No.
                                                                        </td>
                                                                        <td>
                                                                            <dx:ASPxSpinEdit ID="seAdultNumber" runat="server" Height="21px" Number="0">
                                                                            </dx:ASPxSpinEdit>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Child No.
                                                                        </td>
                                                                        <td>
                                                                            <dx:ASPxSpinEdit ID="seChildNumber" runat="server" Height="21px" Number="0">
                                                                            </dx:ASPxSpinEdit>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Infant No.
                                                                        </td>
                                                                        <td>
                                                                            <dx:ASPxSpinEdit ID="seInfantNumber" runat="server" Height="21px" Number="0">
                                                                            </dx:ASPxSpinEdit>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxGridView ID="gvCustomers" runat="server">
                                                                </dx:ASPxGridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            Room
                                                                        </td>
                                                                        <td>
                                                                            <dx:ASPxComboBox ID="cmbRoom" runat="server" ValueType="System.Int32" 
                                                                                DropDownStyle="DropDown" TextFormatString="{0}; {1}; {2}; {3}; {4}">
                                                                                <Columns>
                                                                                    <dx:ListBoxColumn FieldName="RoomName" />
                                                                                    <dx:ListBoxColumn FieldName="RoomCode" />
                                                                                    <dx:ListBoxColumn FieldName="RoomNumber" />
                                                                                    <dx:ListBoxColumn FieldName="MaxAdult" />
                                                                                    <dx:ListBoxColumn FieldName="MaxChildren" />
                                                                                </Columns>
                                                                            </dx:ASPxComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Rate Plan
                                                                        </td>
                                                                        <td>
                                                                            <dx:ASPxComboBox ID="cmbRatePlan" runat="server" ValueType="System.String">
                                                                            </dx:ASPxComboBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxGridView ID="gvRoomRates" runat="server">
                                                                </dx:ASPxGridView>
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
                                        <dx:ASPxButton ID="btnAddRoom" runat="server" Text="Ok">
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnCancelRoom" runat="server" Text="Cancel">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
            </td>
        </tr>
    </table>
</asp:Content>

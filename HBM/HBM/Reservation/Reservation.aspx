<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Reservation.aspx.cs" Inherits="HBM.Reservation.Reservation" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            <asp:HiddenField ID="hdnReservationId" runat="server" />
            Reservation<asp:Literal ID="ltlReservationCode" runat="server"></asp:Literal></h2>
        <table width="100%">
            <tr>
                <td align="left">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="400px" HeaderText="Reservation">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%">
                                    <tr valign="middle">
                                        <td align="left" width="80px">
                                            Customer
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCustomer" runat="server" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextFormatString="{1}">
                                                <Columns>
                                                    <dx:ListBoxColumn Caption="Code" FieldName="MemberCode" />
                                                    <dx:ListBoxColumn Caption="Name" FieldName="CustomerName" />
                                                    <dx:ListBoxColumn Caption="Phone" FieldName="Phone" />
                                                    <dx:ListBoxColumn Caption="Mobile" FieldName="Mobile" />
                                                </Columns>
                                                <ValidationSettings ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
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
                                    <tr valign="middle">
                                        <td>
                                            Source
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbSource" runat="server">
                                                <ValidationSettings ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="400px" HeaderText="Booking Time">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%">
                                    <tr valign="middle">
                                        <td align="left" width="80px">
                                            Check In
                                        </td>
                                        <td align="left">
                                            <dx:ASPxDateEdit ID="dtCheckingDate" runat="server" Width="150px" ClientInstanceName="checkindate">
                                                <ValidationSettings ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
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
                                    <tr valign="middle">
                                        <td align="left">
                                            Check Out
                                        </td>
                                        <td align="left">
                                            <dx:ASPxDateEdit ID="dtCheckOutDate" runat="server" Width="150px" ClientInstanceName="checkoutdate">
                                                <ClientSideEvents Validation="function(s, e) {
	
	var checkindateText=new Date(checkindate.GetText());
    var checkoutdateText =new Date(checkoutdate.GetText());
    e.isValid = (checkoutdateText  &gt;= checkindateText );

}" />
                                                <ValidationSettings ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip"
                                                    EnableCustomValidation="True" ErrorText="Checkout date must be recent">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
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
            </tr>
            <tr>
                <td colspan="3">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Booking information">
                        <PanelCollection>
                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
                                    Width="100%">
                                    <TabPages>
                                        <dx:TabPage Text="Room Info">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <table width="100%">
                                                        <tr valign="middle">
                                                            <td height="22" valign="middle">
                                                                Sharers
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDropDownEdit ID="ddlShareNames" runat="server" DropDownWindowHeight="200px"
                                                                    DropDownWindowWidth="350px" ClientInstanceName="ddlShareNames" MaxLength="255">
                                                                    <DropDownWindowTemplate>
                                                                        <dx:ASPxMemo ID="memSharesNames" runat="server" Height="200px" Width="100%" ClientInstanceName="memSharesNames">
                                                                        </dx:ASPxMemo>
                                                                    </DropDownWindowTemplate>
                                                                    <ClientSideEvents CloseUp="function(s, e) {
    
	ddlShareNames.SetValue(memSharesNames.GetValue());
}" DropDown="function(s, e) {

memSharesNames.SetValue(ddlShareNames.GetValue());

}" />
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxDropDownEdit>
                                                            </td>
                                                            <td valign="middle">
                                                                Room
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbRoom" runat="server" ValueType="System.String" TextFormatString="{1}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Code" FieldName="RoomCode" Width="50px" />
                                                                        <dx:ListBoxColumn Caption="Name" FieldName="RoomName" Width="125px" />
                                                                        <dx:ListBoxColumn Caption="Room Number" FieldName="RoomNumber" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Max Adult" FieldName="MaxAdult" Width="50px" />
                                                                        <dx:ListBoxColumn Caption="Max Children" FieldName="MaxChildren" Width="90px" />
                                                                        <dx:ListBoxColumn Caption="Max Infant" FieldName="MaxInfant" Width="90px" />
                                                                        <dx:ListBoxColumn Caption="Smoking Allow" FieldName="SmokingAllow" Width="90px" />
                                                                        <dx:ListBoxColumn Caption="Bed Type" FieldName="BedTypeName" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Description" FieldName="BedTypeDescription" Width="100px" />
                                                                    </Columns>
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td valign="middle">
                                                                Rate Plan
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbRatePlan" runat="server" ValueType="System.String" TextFormatString="{0}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Plan Name" FieldName="RatePlanName" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Effective From" FieldName="EffectiveFrom" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Effective To" FieldName="EffectiveTo" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Rate" FieldName="Rate" Width="50px" />
                                                                        <dx:ListBoxColumn Caption="Adult Rate" FieldName="AdditionalAdultRate" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Children Rate" FieldName="AdditionalChildrenRate" Width="100px" />
                                                                        <dx:ListBoxColumn Caption="Infant Rate" FieldName="AdditionalInfantRate" Width="100px" />
                                                                    </Columns>
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td rowspan="3">
                                                                <dx:ASPxButton ID="btnAdd" runat="server" Text="Add" Height="40px" ValidationGroup="vgAdd"
                                                                    OnClick="btnAdd_Click">
                                                                    <Image Url="~/Images/Add.png">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="22">
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
                                                        <tr valign="middle">
                                                            <td height="22" valign="middle">
                                                                # Adults
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seAdults" runat="server" Height="21px" Number="0" MaxLength="3"
                                                                    MaxValue="100" NullText="0">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </td>
                                                            <td valign="middle">
                                                                # Children
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seChildren" runat="server" Height="21px" Number="0" MaxLength="3"
                                                                    MaxValue="100" NullText="0">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </td>
                                                            <td valign="middle">
                                                                # Infants
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seInfants" runat="server" Height="21px" Number="0" MaxLength="3"
                                                                    MaxValue="100" NullText="0">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgAdd">
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxSpinEdit>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <dx:ASPxGridView ID="gvRoomInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        OnCellEditorInitialize="gvRoomInfo_CellEditorInitialize" KeyFieldName="ReservationRoomId"
                                                        OnRowDeleting="gvRoomInfo_RowDeleting" OnRowInserting="gvRoomInfo_RowInserting"
                                                        OnRowUpdating="gvRoomInfo_RowUpdating" OnDataBound="gvRoomInfo_DataBound">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="Total : {0:F2}" />
                                                        </TotalSummary>
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0" ButtonType="Image">
                                                                <DeleteButton Visible="True">
                                                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                                                    </Image>
                                                                </DeleteButton>
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="Sharers" ShowInCustomizationForm="True" VisibleIndex="1"
                                                                FieldName="Sharers" Width="150px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="In" ShowInCustomizationForm="True" VisibleIndex="2"
                                                                FieldName="CheckInDate" Width="80px">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Out" ShowInCustomizationForm="True" VisibleIndex="3"
                                                                FieldName="CheckOutDate" Width="80px">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Room" ShowInCustomizationForm="True" VisibleIndex="4"
                                                                FieldName="RoomId" Width="100px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Rate Plan" ShowInCustomizationForm="True" VisibleIndex="5"
                                                                FieldName="RatePlanId" Width="60px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="# Adults" ShowInCustomizationForm="True"
                                                                VisibleIndex="6" FieldName="NumberOfAdults" Width="60px">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="# Childrens" ShowInCustomizationForm="True"
                                                                VisibleIndex="7" FieldName="NumberOfChildren" Width="60px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="# Infant" ShowInCustomizationForm="True" VisibleIndex="8"
                                                                FieldName="NumberOfInfant" Width="60px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Amount" ShowInCustomizationForm="True" VisibleIndex="10"
                                                                FieldName="Amount" Width="80px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="Days" FieldName="Days" ShowInCustomizationForm="True"
                                                                VisibleIndex="9" Width="50px">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                        </Columns>
                                                        <SettingsBehavior ConfirmDelete="True" />
                                                        <Settings ShowFooter="True" ShowPreview="True" />
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Additional Service">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvServiceInformation" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        KeyFieldName="ReservationAdditionalServiceId" OnCellEditorInitialize="gvServiceInformation_CellEditorInitialize"
                                                        OnRowDeleting="gvServiceInformation_RowDeleting" OnRowInserting="gvServiceInformation_RowInserting"
                                                        OnRowUpdating="gvServiceInformation_RowUpdating" 
                                                        OnDataBound="gvServiceInformation_DataBound" EnableCallBacks="False">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="Total : {0:F2}" />
                                                        </TotalSummary>
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" Caption="Action" ShowInCustomizationForm="True"
                                                                VisibleIndex="0" Width="120px">
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
                                                            <dx:GridViewDataComboBoxColumn Caption="Service Type" FieldName="AdditionalServiceId"
                                                                ShowInCustomizationForm="True" VisibleIndex="1" Width="150px">
                                                                <PropertiesComboBox TextField="ServiceName" ValueField="AdditionalServiceId" ValueType="System.Int32"
                                                                    IncrementalFilteringMode="StartsWith" TextFormatString="{0}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Service Name" FieldName="ServiceName" />
                                                                        <dx:ListBoxColumn Caption="Service Code" FieldName="ServiceCode" />
                                                                        <dx:ListBoxColumn Caption="Rate" FieldName="Rate" />
                                                                    </Columns>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="Amount" FieldName="Amount" ShowInCustomizationForm="True"
                                                                VisibleIndex="3" Width="80px">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="Note" FieldName="Note" ShowInCustomizationForm="True"
                                                                VisibleIndex="2">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior AllowGroup="False" SortMode="DisplayText" ConfirmDelete="True" />
                                                        <Settings ShowGroupButtons="False" ShowFooter="True" />
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Payments">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvPaymentInformation" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        KeyFieldName="ReservationPaymentId" OnCellEditorInitialize="gvPaymentInformation_CellEditorInitialize"
                                                        OnRowDeleting="gvPaymentInformation_RowDeleting" OnRowInserting="gvPaymentInformation_RowInserting"
                                                        OnRowUpdating="gvPaymentInformation_RowUpdating" EnableCallBacks="False" 
                                                        OnDataBound="gvPaymentInformation_DataBound">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" ShowInGroupFooterColumn="Amount"
                                                                SummaryType="Sum" DisplayFormat="Total : {0:F2}" />
                                                        </TotalSummary>
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" VisibleIndex="0"
                                                                Width="120px" Caption="Action">
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
                                                            <dx:GridViewDataDateColumn FieldName="PaymentDate" ShowInCustomizationForm="True"
                                                                VisibleIndex="2" Caption="Date" Width="60px">
                                                                <PropertiesDateEdit>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesDateEdit>
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn FieldName="ReferenceNumber" ShowInCustomizationForm="True"
                                                                VisibleIndex="4" Caption="Ref No" Visible="False" Width="50px">
                                                                <PropertiesTextEdit>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataMemoColumn Caption="Notes" FieldName="Notes" ShowInCustomizationForm="True"
                                                                VisibleIndex="10">
                                                            </dx:GridViewDataMemoColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Type" FieldName="PaymentTypeId" ShowInCustomizationForm="True"
                                                                VisibleIndex="1" Width="60px">
                                                                <PropertiesComboBox TextField="PaymentTypeName" ValueField="PaymentTypeId" ValueType="System.Int32">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Currency" FieldName="CurrencyId" ShowInCustomizationForm="True"
                                                                VisibleIndex="3" Visible="False">
                                                                <PropertiesComboBox TextField="CurrencyName" ValueField="CurrencyId" ValueType="System.Int32">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Card Type" FieldName="CreditCardTypeId" ShowInCustomizationForm="True"
                                                                VisibleIndex="5">
                                                                <PropertiesComboBox TextField="Name" ValueField="CreditCardTypeId" ValueType="System.Int32">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn Caption="Card No" FieldName="CCNo" ShowInCustomizationForm="True"
                                                                VisibleIndex="6">
                                                                <PropertiesTextEdit>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" />
                                                                    </ValidationSettings>
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataDateColumn Caption="Expire Date" FieldName="CCExpirationDate" ShowInCustomizationForm="True"
                                                                VisibleIndex="7" Width="60px">
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CCNameOnCard" ShowInCustomizationForm="True"
                                                                VisibleIndex="8" Caption="Name on Card" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="Amount" FieldName="Amount" ShowInCustomizationForm="True"
                                                                VisibleIndex="11" Width="80px">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="Ref No" FieldName="ReferenceNumber" ShowInCustomizationForm="True"
                                                                VisibleIndex="9">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior ConfirmDelete="True" EnableCustomizationWindow="True" />
                                                        <Settings ShowFooter="True" />
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                    </TabPages>
                                </dx:ASPxPageControl>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
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
            </tr>
            <tr>
                <td colspan="3">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" HeaderText="Summary">
                        <PanelCollection>
                            <dx:PanelContent>
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
                                                                    <dx:ASPxSpinEdit ID="txtDiscount" runat="server" Height="21px" Number="0" 
                                                                        AutoPostBack="True" OnValueChanged="txtDiscount_ValueChanged">
                                                                    </dx:ASPxSpinEdit>
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
                                                                    <dx:ASPxComboBox ID="cmbTax" runat="server" ValueType="System.String" 
                                                                        OnSelectedIndexChanged="cmbTax_SelectedIndexChanged" 
                                                                        TextFormatString="{0}" EnableCallbackMode="False" AutoPostBack="True">
                                                                        <Columns>
                                                                            <dx:ListBoxColumn Caption="Tax Type" FieldName="TaxTypeName" />
                                                                            <dx:ListBoxColumn Caption="(%)" FieldName="TaxPercentage" />
                                                                        </Columns>
                                                                    </dx:ASPxComboBox>
                                                                    <asp:HiddenField ID="hdnTaxPercent" runat="server" />
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
                                                                    <dx:ASPxTextBox ID="txtTotal" runat="server" Width="170px" ReadOnly="True">
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
                                                                    <dx:ASPxTextBox ID="txtPaidAmount" runat="server" Width="170px" ReadOnly="True">
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
                                                                    <dx:ASPxTextBox ID="txtBalance" runat="server" Width="170px" ReadOnly="True">
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
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
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
            </tr>
            <tr>
                <td colspan="3">
                    <table border="0" cellpadding="0" cellspacing="0" id="reservation-info-btn-tbl">
                        <tr>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"
                                    HorizontalAlign="Center" ImageSpacing="15px" VerticalAlign="Middle" TabIndex="26">
                                    <Image Url="~/Images/Save.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnNew" runat="server" Text="New" HorizontalAlign="Center" ImageSpacing="15px"
                                    VerticalAlign="Middle" TabIndex="26" OnClick="btnNew_Click">
                                    <Image Url="~/Images/NewDoc.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" HorizontalAlign="Center"
                                    ImageSpacing="15px" VerticalAlign="Middle" TabIndex="26" 
                                    AutoPostBack="False" UseSubmitBehavior="False" OnClick="btnPrint_Click">
                                    
                                    <Image Url="~/Images/Print.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                              <td width="52" align="left">
                                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" HorizontalAlign="Center"
                                    ImageSpacing="15px" VerticalAlign="Middle" TabIndex="26" OnClick="btnSearch_Click">
                                    <Image Url="~/Images/Search.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <dx:ASPxPopupControl ID="ppPrintPreview" runat="server" ContentUrl="~/Reports/PrintPreview.aspx" 
        Height="600px" Modal="True" Width="838px" AllowDragging="True"  ClientIDMode="Static"
        AllowResize="True" AppearAfter="0" AutoUpdatePosition="True" DisappearAfter="0" 
        FooterText="" HeaderText="" LoadingPanelDelay="0" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        ScrollBars="Auto" ShowPageScrollbarWhenModal="True">
    </dx:ASPxPopupControl>
</asp:Content>

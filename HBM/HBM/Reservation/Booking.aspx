<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Booking.aspx.cs" Inherits="HBM.Reservation.Booking" %>

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
            Reservation</h2>
        <table width="100%">
            <tr>
                <td align="left">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="400px" HeaderText="Reservation">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%">
                                    <tr>
                                        <td>
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
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            Source
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbSource" runat="server">
                                            </dx:ASPxComboBox>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
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
                                    <tr>
                                        <td>
                                            Check In
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtCheckingDate" runat="server" Width="150px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            Check Out
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtCheckOutDate" runat="server" Width="150px">
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
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
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
                                    Width="100%"  >
                                    <TabPages>
                                        <dx:TabPage Text="Guest Info">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <table width="100%">
                                                        <tr>
                                                            <td height="22">
                                                                Sharers' names</td>
                                                            <td>
                                                                <dx:ASPxDropDownEdit ID="ASPxDropDownEdit1" runat="server" 
                                                                    DropDownWindowHeight="200px" DropDownWindowWidth="350px">
                                                                    <DropDownWindowTemplate>
                                                                        <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="71px" Width="100%">
                                                                        </dx:ASPxMemo>
                                                                    </DropDownWindowTemplate>
                                                                </dx:ASPxDropDownEdit>
                                                            </td>
                                                            <td>
                                                                Room
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbRoom" runat="server" ValueType="System.String" TextFormatString="{1}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Code" FieldName="RoomCode" />
                                                                        <dx:ListBoxColumn Caption="Name" FieldName="RoomName" />
                                                                        <dx:ListBoxColumn Caption="Room Number" FieldName="RoomNumber" />
                                                                        <dx:ListBoxColumn Caption="Max Adult" FieldName="MaxAdult" />
                                                                        <dx:ListBoxColumn Caption="Max Children" FieldName="MaxChildren" />
                                                                        <dx:ListBoxColumn Caption="Max Infant" FieldName="MaxInfant" />
                                                                        <dx:ListBoxColumn Caption="Smoking Allow" FieldName="SmokingAllow" />
                                                                        <dx:ListBoxColumn Caption="Bed Type" FieldName="BedTypeName" />
                                                                        <dx:ListBoxColumn Caption="Description" FieldName="BedTypeDescription" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td>
                                                                Rate Plan
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cmbRatePlan" runat="server" ValueType="System.String" 
                                                                    TextFormatString="{0}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Plan Name" FieldName="RatePlanName" />
                                                                        <dx:ListBoxColumn Caption="Effective From" FieldName="EffectiveFrom" />
                                                                        <dx:ListBoxColumn Caption="Effective To" FieldName="EffectiveTo" />
                                                                        <dx:ListBoxColumn Caption="Rate" FieldName="Rate" />
                                                                        <dx:ListBoxColumn Caption="Adult Rate" FieldName="AdditionalAdultRate" />
                                                                        <dx:ListBoxColumn Caption="Children Rate" FieldName="AdditionalChildrenRate" />
                                                                        <dx:ListBoxColumn Caption="Infant Rate" FieldName="AdditionalInfantRate" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td rowspan="3">
                                                                <dx:ASPxButton ID="btnAdd" runat="server" Text="Add" Height="40px">
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
                                                        <tr>
                                                            <td height="22">
                                                                # of Adults
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seAdults" runat="server" Height="21px" Number="0">
                                                                </dx:ASPxSpinEdit>
                                                            </td>
                                                            <td>
                                                                # of Children
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seChildren" runat="server" Height="21px" Number="0">
                                                                </dx:ASPxSpinEdit>
                                                            </td>
                                                            <td>
                                                                # of Infants
                                                            </td>
                                                            <td>
                                                                <dx:ASPxSpinEdit ID="seInfants" runat="server" Height="21px" Number="0">
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
                                                            <td valign="middle">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <dx:ASPxGridView ID="gvGuestInfo" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True"
                                                                VisibleIndex="0">
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="Customer" ShowInCustomizationForm="True" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="In" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Out" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Room" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Rate Plan" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="# of Adults" ShowInCustomizationForm="True"
                                                                VisibleIndex="6">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="# of Childrens" ShowInCustomizationForm="True"
                                                                VisibleIndex="7">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="# of Infant" ShowInCustomizationForm="True" VisibleIndex="8">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Amount" ShowInCustomizationForm="True" VisibleIndex="9">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Additional Service">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvServiceInformation" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        KeyFieldName="ReservationAdditionalServiceId" 
                                                        OnCellEditorInitialize="gvServiceInformation_CellEditorInitialize" 
                                                        OnRowDeleting="gvServiceInformation_RowDeleting" 
                                                        OnRowInserting="gvServiceInformation_RowInserting" 
                                                        OnRowUpdating="gvServiceInformation_RowUpdating">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Rate" ShowInColumn="Rate" ShowInGroupFooterColumn="Rate"
                                                                SummaryType="Sum" />
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
                                                                ShowInCustomizationForm="True" VisibleIndex="1">
                                                                <PropertiesComboBox TextField="ServiceName" ValueField="AdditionalServiceId" ValueType="System.Int32"
                                                                    IncrementalFilteringMode="StartsWith" TextFormatString="{1}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Service Code" FieldName="ServiceCode" />
                                                                        <dx:ListBoxColumn Caption="Service Name" FieldName="ServiceName" />
                                                                        <dx:ListBoxColumn Caption="Rate" FieldName="Rate" />
                                                                    </Columns>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="Amount" FieldName="Amount" ShowInCustomizationForm="True"
                                                                VisibleIndex="2">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="Note" FieldName="Note" ShowInCustomizationForm="True"
                                                                VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior AllowGroup="False" SortMode="DisplayText" ConfirmDelete="True" />
                                                        <Settings ShowGroupButtons="False" />
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Payments">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvPaymentInformation" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        KeyFieldName="ReservationPaymentId" 
                                                        OnCellEditorInitialize="gvPaymentInformation_CellEditorInitialize" 
                                                        OnRowDeleting="gvPaymentInformation_RowDeleting" 
                                                        OnRowInserting="gvPaymentInformation_RowInserting" 
                                                        OnRowUpdating="gvPaymentInformation_RowUpdating">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" ShowInGroupFooterColumn="Amount"
                                                                SummaryType="Sum" />
                                                        </TotalSummary>
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" VisibleIndex="0"
                                                                Width="80px" Caption="Action">
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
                                                                VisibleIndex="2" Caption="Payment Date">
                                                                <PropertiesDateEdit>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesDateEdit>
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn FieldName="ReferenceNumber" ShowInCustomizationForm="True"
                                                                VisibleIndex="4" Caption="Ref No" Visible="False">
                                                                <PropertiesTextEdit>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataMemoColumn Caption="Notes" FieldName="Notes" ShowInCustomizationForm="True"
                                                                VisibleIndex="9">
                                                            </dx:GridViewDataMemoColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Payment Type" FieldName="PaymentTypeId" ShowInCustomizationForm="True"
                                                                VisibleIndex="1">
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
                                                                VisibleIndex="7">
                                                            </dx:GridViewDataDateColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CCNameOnCard" ShowInCustomizationForm="True"
                                                                VisibleIndex="8" Caption="Name on Card">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior ConfirmDelete="True" EnableCustomizationWindow="True" />
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
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Save">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Settle">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

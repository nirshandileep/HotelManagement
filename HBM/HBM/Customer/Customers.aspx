<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Customers.aspx.cs" Inherits="HBM.Customers" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            Add Customer</h2>
        <table>
            <tr runat="server" id="trCustomerMode">
                <td align="center">
                    <%--        <dx:ASPxRoundPanel ID="ASPxRoundPanel8" runat="server" Width="850px" HeaderText="Customer Type">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent7" runat="server" SupportsDisabledAttribute="True">
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <table class="customers-tbl" align="center">
                        <tr>
                            <td align="center" valign="middle">
                                <asp:RadioButtonList ID="rblCustomerMode" runat="server" RepeatDirection="Horizontal"
                                    OnSelectedIndexChanged="rblCustomerMode_SelectedIndexChanged" AutoPostBack="True"
                                    Width="50%" CellPadding="10" CellSpacing="10">
                                    <asp:ListItem Value="1" Selected="True">Single Customer</asp:ListItem>
                                    <asp:ListItem Value="2">Group Customer</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:HiddenField ID="hdnCustomerMode" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                                <asp:HiddenField ID="hdnFromURL" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table id="tblGroupCustomer" runat="server" visible="false">
            <tr>
                <td>
                    <%--       <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="800px" HeaderText="Group Information">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent3" runat="server" SupportsDisabledAttribute="True">
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <h2>
                        Group information
                    </h2>
                    <table class="customers-tbl">
                        <tr>
                            <td height="22" class="info-lbl">
                                Group Name<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtGroupName" runat="server" TabIndex="1" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer" SetFocusOnError="True">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td width="50px">
                                &nbsp;
                            </td>
                            <td>
                                CC Type
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbCCTypeGrp" runat="server" IncrementalFilteringMode="Contains"
                                    ValueType="System.Int32" TabIndex="11">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Member Code<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtMemberCodeGrp" runat="server" TabIndex="2" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                CC No
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCCNoGrp" runat="server" Width="170px" TabIndex="12">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Phone<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtPhoneGrp" runat="server" TabIndex="4" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                CC Expiry Date (mm/yyyy)
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCCExpiryDateMonthGrp" runat="server" ValueType="System.Int32"
                                                IncrementalFilteringMode="Contains" Width="50px" TabIndex="13">
                                                <Items>
                                                    <dx:ListEditItem Text="1" Value="1" />
                                                    <dx:ListEditItem Text="2" Value="2" />
                                                    <dx:ListEditItem Text="3" Value="3" />
                                                    <dx:ListEditItem Text="4" Value="4" />
                                                    <dx:ListEditItem Text="5" Value="5" />
                                                    <dx:ListEditItem Text="6" Value="6" />
                                                    <dx:ListEditItem Text="7" Value="7" />
                                                    <dx:ListEditItem Text="8" Value="8" />
                                                    <dx:ListEditItem Text="9" Value="9" />
                                                    <dx:ListEditItem Text="10" Value="10" />
                                                    <dx:ListEditItem Text="11" Value="11" />
                                                    <dx:ListEditItem Text="12" Value="12" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            /
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCCExpiryDateYearGrp" runat="server" ValueType="System.Int32"
                                                IncrementalFilteringMode="Contains" Width="114px" TabIndex="14">
                                                <Items>
                                                    <dx:ListEditItem Text="2012" Value="2012" />
                                                    <dx:ListEditItem Text="2013" Value="2013" />
                                                    <dx:ListEditItem Text="2014" Value="2014" />
                                                    <dx:ListEditItem Text="2015" Value="2015" />
                                                    <dx:ListEditItem Text="2016" Value="2016" />
                                                    <dx:ListEditItem Text="2017" Value="2017" />
                                                    <dx:ListEditItem Text="2018" Value="2018" />
                                                    <dx:ListEditItem Text="2019" Value="2019" />
                                                    <dx:ListEditItem Text="2020" Value="2020" />
                                                    <dx:ListEditItem Text="2021" Value="2021" />
                                                    <dx:ListEditItem Text="2022" Value="2022" />
                                                    <dx:ListEditItem Text="2023" Value="2023" />
                                                    <dx:ListEditItem Text="2024" Value="2024" />
                                                    <dx:ListEditItem Text="2025" Value="2025" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Fax
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtFaxGrp" runat="server" TabIndex="5" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Name on card
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtNameOnCardGrp" runat="server" Width="170px" TabIndex="15">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Email
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtEmailGrp" runat="server" TabIndex="6" Width="170px">
                                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        SetFocusOnError="True" ValidationGroup="vgCustomer">
                                        <RegularExpression ErrorText="Incorrect Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Card Security code
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCardSecurityCodeGrp" runat="server" MaxLength="3" TabIndex="16"
                                    Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Guest Type<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbGuestTypeGrp" runat="server" ClientInstanceName="cmbGuestTypeGrp"
                                    DropDownStyle="DropDown" TabIndex="7" ValueType="System.Int32">
                                    <ClientSideEvents ButtonClick="function(s, e) {
  	ShowPopupWindow(ppcGuestType);
}" />
                                    <Buttons>
                                        <dx:EditButton Position="Left" ToolTip="Add/Edit guest type">
                                        </dx:EditButton>
                                    </Buttons>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgCustomer">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Card Start Date
                            </td>
                            <td>
                                <dx:ASPxDateEdit ID="dtStartDateGrp" runat="server" TabIndex="17">
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Card Issue No
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCardIssueNoGrp" runat="server" TabIndex="18" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <%--          <dx:ASPxRoundPanel ID="ASPxRoundPanel5" runat="server" Width="850px" HeaderText="Company Information Group">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent4" runat="server" SupportsDisabledAttribute="True">
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <h2>
                        Company Information Group
                    </h2>
                    <table class="customers-tbl">
                        <tr>
                            <td height="22" class="info-lbl">
                                Company Name
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyNameGrp" runat="server" Width="170px" TabIndex="21">
                                </dx:ASPxTextBox>
                            </td>
                            <td width="50px">
                                &nbsp;
                            </td>
                            <td height="22" class="info-lbl" width="50px">
                                State/County
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyStateGrp" runat="server" Width="170px" TabIndex="26"
                                    MaxLength="50">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Company Address Line 1
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyAddressLine1Grp" runat="server" Width="170px" TabIndex="22"
                                    MaxLength="150">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Country
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbCompanyCountryGrp" runat="server" ValueType="System.Int32"
                                    IncrementalFilteringMode="Contains" TabIndex="27">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Company Address Line 2
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyAddressLine2Grp" runat="server" Width="170px" TabIndex="23"
                                    MaxLength="150">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Zip Code/Post code
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyPostCodeGrp" runat="server" MaxLength="50" TabIndex="28"
                                    Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                City
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtCompanyCityGrp" runat="server" Width="170px" TabIndex="24"
                                    MaxLength="50">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Notes
                            </td>
                            <td rowspan="2">
                                <dx:ASPxMemo ID="txtCompanyNotesGrp" runat="server" Height="71px" Width="170px" TabIndex="29">
                                </dx:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td class="info-lbl" height="22">
                                &nbsp;
                            </td>
                            <td>
                                <dx:ASPxCheckBox ID="chkUseSameBillingAddressGrp" runat="server" Text="Use Same Billing Address"
                                    AutoPostBack="True" OnCheckedChanged="chkUseSameBillingAddressGrp_CheckedChanged">
                                </dx:ASPxCheckBox>
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
             <%--       <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" Width="200px" HeaderText="Billing Information Group">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent5" runat="server" SupportsDisabledAttribute="True">
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <h2>
                        Billing Information Group
                    </h2>
                    <table class="customers-tbl">
                        <tr>
                            <td height="22" class="info-lbl">
                                Billing Address Line 1<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtBillingAddressLine1Grp" runat="server" Width="170px" TabIndex="30">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer" SetFocusOnError="True">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td width="50px">
                                &nbsp;
                            </td>
                            <td>
                                State/County
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtBillingStateGrp" runat="server" TabIndex="33" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Billing Address Line 2<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtBillingAddressLine2Grp" runat="server" TabIndex="31" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer" SetFocusOnError="True">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Country
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cmbBillingCountryGrp" runat="server" IncrementalFilteringMode="Contains"
                                    TabIndex="34" ValueType="System.Int32">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="info-lbl">
                                Billing City<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtBillingCityGrp" runat="server" TabIndex="32" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                        ValidationGroup="vgCustomer" SetFocusOnError="True">
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Zip Code/Post code &nbsp;
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtBillingZipPostalCodeGrp" runat="server" TabIndex="35" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                 <%--   <dx:ASPxRoundPanel ID="ASPxRoundPanel7" runat="server" Width="850px" HeaderText="Group Members">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent6" runat="server" SupportsDisabledAttribute="True">
                                
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>

                    <h2>Group Members</h2>
<table class="customers-tbl">
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="gvGroupMembers" runat="server" AutoGenerateColumns="False" KeyFieldName="CustomerId"
                                                OnRowInserting="gvGroupMembers_RowInserting" OnRowDeleting="gvGroupMembers_RowDeleting"
                                                OnRowUpdating="gvGroupMembers_RowUpdating" OnCellEditorInitialize="gvGroupMembers_CellEditorInitialize"
                                                Width="97%">
                                                <Columns>
                                                    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Width="120px" Caption="Actions"
                                                        FixedStyle="Left">
                                                        <DeleteButton Visible="True">
                                                            <Image ToolTip="Delete" Url="~/Images/delete.png">
                                                            </Image>
                                                        </DeleteButton>
                                                        <EditButton Visible="True">
                                                            <Image ToolTip="Edit" Url="~/Images/update.png">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image ToolTip="New" Url="~/Images/new.png">
                                                            </Image>
                                                        </NewButton>
                                                        <UpdateButton Visible="True">
                                                            <Image Url="~/Images/Apply.png">
                                                            </Image>
                                                        </UpdateButton>
                                                        <CancelButton Visible="True">
                                                            <Image Url="~/Images/Close.png" ToolTip="Cancel">
                                                            </Image>
                                                        </CancelButton>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="Member Code" FieldName="MemberCode" VisibleIndex="2">
                                                        <PropertiesTextEdit MaxLength="50">
                                                            <ValidationSettings Display="Dynamic">
                                                                <RequiredField ErrorText="Required" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Customer Name" FieldName="CustomerName" VisibleIndex="1"
                                                        UnboundType="String">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings Display="Dynamic">
                                                                <RequiredField ErrorText="Required" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Gender" FieldName="Gender" VisibleIndex="3">
                                                        <PropertiesComboBox ValueField="Gender">
                                                            <Items>
                                                                <dx:ListEditItem Text="Male" Value="Male" />
                                                                <dx:ListEditItem Text="Female" Value="Female" />
                                                            </Items>
                                                            <ValidationSettings Display="Dynamic">
                                                                <RequiredField ErrorText="Required" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Guest Type" FieldName="GuestTypeId" ShowInCustomizationForm="True"
                                                        UnboundType="Integer" VisibleIndex="4">
                                                        <PropertiesComboBox TextField="GuestTypeName" ValueField="GuestTypeId" ValueType="System.Int32">
                                                            <ValidationSettings Display="Dynamic">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Phone" ShowInCustomizationForm="True" UnboundType="String"
                                                        VisibleIndex="5">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsBehavior ConfirmDelete="True" />
                                                <SettingsText ConfirmDelete="" />
                                                <SettingsEditing NewItemRowPosition="Bottom" />
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                </table>
                </td>
            </tr>
        </table>
        <table id="tblIndividualCustomer" runat="server">
            <tr>
                <td>
                  <%--  <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="800px" HeaderText="Personnel Information">
                        <PanelCollection>
                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>

                    <h2>Personnel Information</h2>
<table class="customers-tbl">
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Customer Name<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCustomerName" runat="server" TabIndex="1" Width="170px">
                                                <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidationGroup="vgCustomer" SetFocusOnError="True">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td width="50px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            CC Type
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCCType" runat="server" IncrementalFilteringMode="Contains"
                                                ValueType="System.Int32" TabIndex="11">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Member Code<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMemberCode" runat="server" TabIndex="2" Width="170px">
                                                <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidationGroup="vgCustomer">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            CC No
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCCNumber" runat="server" Width="170px" TabIndex="12">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Gender<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbGender" runat="server" IncrementalFilteringMode="Contains"
                                                TabIndex="3">
                                                <Items>
                                                    <dx:ListEditItem Text="Male" Value="Male" />
                                                    <dx:ListEditItem Text="Female" Value="Female" />
                                                </Items>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgCustomer">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            CC Expiry Date (mm/yyyy)
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxComboBox ID="cmbCCExpiryDateMonth" runat="server" ValueType="System.Int32"
                                                            IncrementalFilteringMode="Contains" Width="50px" TabIndex="13">
                                                            <Items>
                                                                <dx:ListEditItem Text="1" Value="1" />
                                                                <dx:ListEditItem Text="2" Value="2" />
                                                                <dx:ListEditItem Text="3" Value="3" />
                                                                <dx:ListEditItem Text="4" Value="4" />
                                                                <dx:ListEditItem Text="5" Value="5" />
                                                                <dx:ListEditItem Text="6" Value="6" />
                                                                <dx:ListEditItem Text="7" Value="7" />
                                                                <dx:ListEditItem Text="8" Value="8" />
                                                                <dx:ListEditItem Text="9" Value="9" />
                                                                <dx:ListEditItem Text="10" Value="10" />
                                                                <dx:ListEditItem Text="11" Value="11" />
                                                                <dx:ListEditItem Text="12" Value="12" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td>
                                                        /
                                                    </td>
                                                    <td>
                                                        <dx:ASPxComboBox ID="cmbCCExpiryDateYear" runat="server" ValueType="System.Int32"
                                                            IncrementalFilteringMode="Contains" Width="114px" TabIndex="14">
                                                            <Items>
                                                                <dx:ListEditItem Text="2012" Value="2012" />
                                                                <dx:ListEditItem Text="2013" Value="2013" />
                                                                <dx:ListEditItem Text="2014" Value="2014" />
                                                                <dx:ListEditItem Text="2015" Value="2015" />
                                                                <dx:ListEditItem Text="2016" Value="2016" />
                                                                <dx:ListEditItem Text="2017" Value="2017" />
                                                                <dx:ListEditItem Text="2018" Value="2018" />
                                                                <dx:ListEditItem Text="2019" Value="2019" />
                                                                <dx:ListEditItem Text="2020" Value="2020" />
                                                                <dx:ListEditItem Text="2021" Value="2021" />
                                                                <dx:ListEditItem Text="2022" Value="2022" />
                                                                <dx:ListEditItem Text="2023" Value="2023" />
                                                                <dx:ListEditItem Text="2024" Value="2024" />
                                                                <dx:ListEditItem Text="2025" Value="2025" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Phone<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtPhone" runat="server" Width="170px" TabIndex="4">
                                                <ValidationSettings EnableCustomValidation="True" ValidationGroup="vgCustomer" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField IsRequired="True" ErrorText="Required" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Name on card
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtNameOnCard" runat="server" Width="170px" TabIndex="15">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Fax
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtFax" runat="server" Width="170px" TabIndex="5">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Card Security code
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCardSecurityCode" runat="server" MaxLength="3" TabIndex="16"
                                                Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Email
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" TabIndex="6">
                                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    SetFocusOnError="True" ValidationGroup="vgCustomer">
                                                    <RegularExpression ErrorText="Incorrect Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Card Start Date
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtStartDate" runat="server" TabIndex="17">
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Guest Type<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbGuestType" runat="server" ValueType="System.Int32" DropDownStyle="DropDown"
                                                TabIndex="7" ClientInstanceName="cmbGuestType">
                                                <ClientSideEvents ButtonClick="function(s, e) {
  	ShowPopupWindow(ppcGuestType);
}" />
                                                <Buttons>
                                                    <dx:EditButton Position="Left" ToolTip="Add/Edit guest type">
                                                    </dx:EditButton>
                                                </Buttons>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgCustomer"
                                                    Display="Dynamic">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Card Issue No
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCardIssueNo" runat="server" TabIndex="18" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Passport Number
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtPassportNumber" runat="server" TabIndex="8" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Car
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCar" runat="server" AnimationType="Fade" IncrementalFilteringMode="Contains"
                                                TabIndex="19">
                                                <Items>
                                                    <dx:ListEditItem Text="No" Value="No" />
                                                    <dx:ListEditItem Text="Yes" Value="Yes" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Country of Issue
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbPassportCountryOfIssue" runat="server" ValueType="System.Int32"
                                                IncrementalFilteringMode="Contains" TabIndex="9">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            License Plate &nbsp;
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtLicensePlate" runat="server" TabIndex="20" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Expiry Date
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtpExpiryDate" runat="server" TabIndex="10">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Drive License
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtDriveLicense" runat="server" TabIndex="21" Width="170px">
                                            </dx:ASPxTextBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
               <%--     <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="850px" HeaderText="Company Information">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                                
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <h2>Company Information</h2>
<table class="customers-tbl">
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Company Name
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="170px" TabIndex="21">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td width="50px">
                                            &nbsp;
                                        </td>
                                        <td height="22" class="info-lbl" width="50px">
                                            State/County
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyState" runat="server" Width="170px" TabIndex="26" MaxLength="50">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Company Address Line 1
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyAddressLine1" runat="server" Width="170px" TabIndex="22"
                                                MaxLength="150">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCompanyCountry" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains"
                                                TabIndex="27">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Company Address Line 2
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyAddressLine2" runat="server" Width="170px" TabIndex="23"
                                                MaxLength="150">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Zip Code/Post code
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyPostCode" runat="server" MaxLength="50" TabIndex="28"
                                                Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            City
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtCompanyCity" runat="server" Width="170px" TabIndex="24" MaxLength="50">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Notes
                                        </td>
                                        <td rowspan="2">
                                            <dx:ASPxMemo ID="txtNotes" runat="server" Height="71px" Width="170px" TabIndex="29">
                                            </dx:ASPxMemo>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info-lbl" height="22">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <dx:ASPxCheckBox ID="chkUseSameBillingAddress" runat="server" Text="Use Same Billing Address"
                                                AutoPostBack="True" OnCheckedChanged="chkUseSameBillingAddress_CheckedChanged">
                                            </dx:ASPxCheckBox>
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
              <%--      <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="200px" HeaderText="Billing Information">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                                
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>--%>
                    <h2>Billing Information</h2>
<table class="customers-tbl">
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Billing Address Line 1<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtBillingAddressLine1" runat="server" Width="170px" TabIndex="30">
                                                <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidationGroup="vgCustomer" SetFocusOnError="True">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td width="50px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            State/County
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtBillingState" runat="server" TabIndex="33" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Billing Address Line 2<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtBillingAddressLine2" runat="server" TabIndex="31" Width="170px">
                                                <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidationGroup="vgCustomer" SetFocusOnError="True">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbBillingCountry" runat="server" IncrementalFilteringMode="Contains"
                                                TabIndex="34" ValueType="System.Int32">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" class="info-lbl">
                                            Billing City<span class="reqfield">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtBillingCity" runat="server" TabIndex="32" Width="170px">
                                                <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidationGroup="vgCustomer" SetFocusOnError="True">
                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            Zip Code/Post code &nbsp;
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtBillingPostCode" runat="server" TabIndex="35" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="info-lbl" height="22">
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
                                        </td>
                                    </tr>
                                </table>
                </td>
            </tr>
        </table>
        <table class="customers-tbl">
            <tr>
                <td>
                </td>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" id="customer-info-btn-tbl">
                        <tr>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgCustomer"
                                    HorizontalAlign="Center" ImageSpacing="15px" VerticalAlign="Middle" TabIndex="36"
                                    UseSubmitBehavior="false">
                                    <Image Url="~/Images/Save.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" HorizontalAlign="Center"
                                    ImageSpacing="15px" VerticalAlign="Middle" UseSubmitBehavior="False" AutoPostBack="false"
                                    OnClick="btnClear_Click" TabIndex="37">
                                    <Image Url="~/Images/Clear.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" HorizontalAlign="Center"
                                    ImageSpacing="15px" VerticalAlign="Middle" UseSubmitBehavior="False" AutoPostBack="false"
                                    OnClick="btnSearch_Click" TabIndex="38">
                                    <Image Url="~/Images/Search.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td width="52" align="left">
                                <dx:ASPxButton ID="btnReservation" runat="server" Text="Reservation" HorizontalAlign="Center"
                                    ImageSpacing="15px" VerticalAlign="Middle" UseSubmitBehavior="False" AutoPostBack="false"
                                    OnClick="btnReservation_Click" TabIndex="39" Visible="false">
                                    <Image Url="../Images/Reservation.png">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
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
    </div>
    <div>
        <dx:ASPxPopupControl ID="pcGuestType" runat="server" HeaderText="Guest Type" AllowDragging="True"
            ClientInstanceName="ppcGuestType" Modal="True" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" ContentUrl="~/ControlPanel/GuestTypes.aspx"
            Width="700px" Height="350px">
            <ClientSideEvents CloseUp="function(s, e) {
	cmbGuestType.PerformCallback();
}" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</asp:Content>

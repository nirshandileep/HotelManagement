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
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divErrorMsg" runat="server" visible="false">
    </div>
    <table class="style1">
        <tr>
            <td>
                Customer Name
            </td>
            <td>
                <dx:ASPxTextBox ID="txtCustomerName" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" SetFocusOnError="True"
                        ValidationGroup="vgCustomer" ErrorDisplayMode="Text">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Passport Number
            </td>
            <td>
                <dx:ASPxTextBox ID="txtPassportNumber" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Member Code
            </td>
            <td>
                <dx:ASPxTextBox ID="txtMemberCode" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" SetFocusOnError="True"
                        ValidationGroup="vgCustomer" ErrorDisplayMode="Text">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Country of Issue
            </td>
            <td>
                            <dx:ASPxComboBox ID="cmbPassportCountryOfIssue" runat="server" 
                    ValueType="System.Int32">
                            </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender
            </td>
            <td>
                <dx:ASPxComboBox ID="cmbGender" runat="server">
                    <Items>
                        <dx:ListEditItem Text="Male" Value="Male" />
                        <dx:ListEditItem Text="Female" Value="Female" />
                    </Items>
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" 
                        SetFocusOnError="True" ValidationGroup="vgCustomer">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Expiry Date
            </td>
            <td>
                <dx:ASPxDateEdit ID="dtpExpiryDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Phone
            </td>
            <td>
                <dx:ASPxTextBox ID="txtPhone" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" SetFocusOnError="True"
                        ValidationGroup="vgCustomer" ErrorDisplayMode="Text">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
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
                Fax
            </td>
            <td>
                <dx:ASPxTextBox ID="txtFax" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                CC Type</td>
            <td>
                <dx:ASPxComboBox ID="cmbCCType" runat="server">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                        ErrorDisplayMode="Text" SetFocusOnError="True" ValidationGroup="vgCustomer">
                        <RegularExpression ErrorText="Incorrect Email" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                CC No</td>
            <td>
                <dx:ASPxTextBox ID="txtCCNumber" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Guest Type
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <dx:ASPxComboBox ID="cmbGuestType" runat="server" ValueType="System.Int32">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnAddGuestType" runat="server" Text="..." 
                                ToolTip="Add/Edit Guest Types" Visible="False">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                CC Expiry Date (mm/yyyy)</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <dx:ASPxComboBox ID="cmbCCExpiryDateMonth" runat="server" ValueType="System.Int32"
                                SelectedIndex="0">
                                <Items>
                                    <dx:ListEditItem Selected="True" />
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
                                SelectedIndex="0">
                                <Items>
                                    <dx:ListEditItem Selected="True" />
                                    <dx:ListEditItem Text="2012" Value="2012" />
                                    <dx:ListEditItem Text="2013" Value="2013" />
                                    <dx:ListEditItem Text="2014" Value="2014" />
                                    <dx:ListEditItem Text="2015" Value="2015" />
                                    <dx:ListEditItem Text="2016" Value="2016" />
                                    <dx:ListEditItem Text="2017" Value="2017" />
                                    <dx:ListEditItem Text="2018" Value="2018" />
                                    <dx:ListEditItem Text="2019" Value="2019" />
                                    <dx:ListEditItem Text="2020" Value="2020" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                </table>
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
        <tr>
            <td>
                Company Name
            </td>
            <td>
                <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Name on card
            </td>
            <td>
                <dx:ASPxTextBox ID="txtNameOnCard" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Company Address
            </td>
            <td>
                <dx:ASPxTextBox ID="txtCompanyAddress" runat="server" Width="170px">
                </dx:ASPxTextBox>
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
                Notes
            </td>
            <td>
                <dx:ASPxTextBox ID="txtNotes" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Car</td>
            <td>
                <dx:ASPxComboBox ID="cmbCar" runat="server">
                    <Items>
                        <dx:ListEditItem Text="No" Value="No" />
                        <dx:ListEditItem Text="Yes" Value="Yes" />
                    </Items>
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                License Plate</td>
            <td>
                <dx:ASPxTextBox ID="txtLicensePlate" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Billing Address</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingAddress" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" SetFocusOnError="True"
                        ValidationGroup="vgCustomer" ErrorDisplayMode="Text">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Drive License</td>
            <td>
                <dx:ASPxTextBox ID="txtDriveLicense" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Billing City</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingCity" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" SetFocusOnError="True"
                        ValidationGroup="vgCustomer" ErrorDisplayMode="Text" ErrorText="Required">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
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
                State</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingState" runat="server" Width="170px">
                </dx:ASPxTextBox>
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
                Country</td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <dx:ASPxComboBox ID="cmbBillingCountry" runat="server" ValueType="System.String">
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;</td>
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
        <tr>
            <td>
                Post Code</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingPostCode" runat="server" Width="170px">
                </dx:ASPxTextBox>
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
                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnFromURL" runat="server" />
            </td>
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgCustomer">
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear">
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back">
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
        </tr>
    </table>
    <div>
        <dx:ASPxPopupControl ID="pcGuestType" runat="server" HeaderText="Guest Type" AllowDragging="True"
            Modal="True" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxCallbackPanel ID="cbpCountryPannel" runat="server" Width="200px">
                        <PanelCollection>
                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <dx:ASPxTextBox ID="txtAddGuestType" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnSaveGuestType" runat="server" Text="Save" 
                                                OnClick="btnSaveCountry_Click">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
    <div>
    </div>
</asp:Content>

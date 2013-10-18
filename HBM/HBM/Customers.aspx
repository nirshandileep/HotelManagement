<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="HBM.Customers" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                Customer Name</td>
            <td>
                <dx:ASPxTextBox ID="txtCustomerName" runat="server" Width="170px">
                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                        SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Passport Number</td>
            <td>
                <dx:ASPxTextBox ID="txtPassportNumber" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Member Code</td>
            <td>
                <dx:ASPxTextBox ID="txtMemberCode" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Country of Issue</td>
            <td>
                <dx:ASPxTextBox ID="txtCountryOfIssue" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender</td>
            <td>
                <dx:ASPxComboBox ID="cmbGender" runat="server">
                    <Items>
                        <dx:ListEditItem Text="Male" Value="Male" />
                        <dx:ListEditItem Text="Female" Value="Female" />
                    </Items>
                </dx:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Expiry Date</td>
            <td>
                <dx:ASPxDateEdit ID="dtpExpiryDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Phone</td>
            <td>
                <dx:ASPxTextBox ID="txtPhone" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Fax</td>
            <td>
                <dx:ASPxTextBox ID="txtFax" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                CC Type</td>
            <td>
                <dx:ASPxComboBox ID="cmbCCType" runat="server" ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                CC No</td>
            <td>
                <dx:ASPxTextBox ID="txtCCNumber" runat="server" Width="170px">
                </dx:ASPxTextBox>
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
                CC
                Expiry Date</td>
            <td>
                <dx:ASPxDateEdit ID="dtpCCExpiryDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Company Name</td>
            <td>
                <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                CC
                Name Date</td>
            <td>
                <dx:ASPxDateEdit ID="dtpCCNameDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Company Address</td>
            <td>
                <dx:ASPxTextBox ID="txtCompanyAddress" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Notes</td>
            <td>
                <dx:ASPxTextBox ID="txtNotes" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Car</td>
            <td>
                <dx:ASPxTextBox ID="txtCar" runat="server" Width="170px">
                </dx:ASPxTextBox>
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
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Drive License</td>
            <td>
                <dx:ASPxTextBox ID="txtDriveLicense" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Billing
                City</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingCity" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                State</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingState" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Country</td>
            <td>
                <dx:ASPxComboBox ID="cmbBillingCountry" runat="server" 
                    ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Post Code</td>
            <td>
                <dx:ASPxTextBox ID="txtBillingPostCode" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnFromURL" runat="server" />
            </td>
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click">
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear">
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back">
                </dx:ASPxButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="HBM.Customers" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
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
                <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Passport Number</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox18" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Member Code</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Country of Issue</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox19" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender</td>
            <td>
                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
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
                <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Phone</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" Width="170px">
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
                <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                C Type</td>
            <td>
                <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                C No</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox21" runat="server" Width="170px">
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
                Expiry Date</td>
            <td>
                <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Company Name</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Name Date</td>
            <td>
                <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td>
                Company Address</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" Width="170px">
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
                <dx:ASPxTextBox ID="ASPxTextBox13" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Car</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox22" runat="server" Width="170px">
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
                <dx:ASPxTextBox ID="ASPxTextBox23" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Billing Address</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox14" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Drive License</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox24" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                City</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox15" runat="server" Width="170px">
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
                <dx:ASPxTextBox ID="ASPxTextBox16" runat="server" Width="170px">
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
                <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" ValueType="System.String">
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
                <dx:ASPxTextBox ID="ASPxTextBox17" runat="server" Width="170px">
                </dx:ASPxTextBox>
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

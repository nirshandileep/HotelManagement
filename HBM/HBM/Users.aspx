<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HBM.Users" %>
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
                First Name</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                User Name</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Password="True" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" Password="True" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Save">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>

</asp:Content>

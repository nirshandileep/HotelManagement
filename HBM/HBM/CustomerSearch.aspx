<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="CustomerSearch.aspx.cs" Inherits="HBM.CustomerSearch" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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
            <td>Customer Name:
            </td>
            <td>
                <dx:ASPxTextBox ID="txtCustomerName" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td> 
                &nbsp;</td>
            <td>
                Company Name:</td>
            <td>
                <dx:ASPxTextBox ID="txtCompantName" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search">
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

    <div>
        <table class="style1">
            <tr>
                <td>
Customer Search List
                </td>
            </tr>

            <tr>
                <td>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server">
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

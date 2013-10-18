<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="RoleSearch.aspx.cs" Inherits="HBM.RoleSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                Add Roles
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvRoles" runat="server">
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HBM.Dashboard" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    Dashboard Controls to be populated</div>
</asp:Content>

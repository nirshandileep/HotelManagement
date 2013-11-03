<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="HBM.Dashboard" %>

<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
$( document ).ready(function() {
  $winHeight = $( document ).height(); 
  $newHeight = $winHeight-300;
  //alert($newHeight);
  $(".page-wrapper").css("height",$newHeight);
 
});
</script>
    <div class="wrapper">
        <h2>Dashboard</h2>
        </div>
</asp:Content>

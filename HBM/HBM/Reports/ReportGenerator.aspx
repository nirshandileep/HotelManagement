<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportGenerator.aspx.cs" Inherits="HBM.Reports.ReportGenerator" %>

<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-switchboard">
        <h2>
            Report Generator</h2>
        <table width="100%">
            <tr>
                <td width="100px">
                    Report Type
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbReportType" runat="server" AutoPostBack="True" ValueType="System.Int32"
                        TextFormatString="{0}" 
                        onselectedindexchanged="cmbReportType_SelectedIndexChanged">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="100px">
                    &nbsp;</td>
                <td>
                    <dx:ASPxButton ID="btnPreview" runat="server" onclick="btnPreview_Click" 
                        Text="Preview">
                    </dx:ASPxButton>
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
                <td colspan="2">
                  <iframe id="iframePage" runat="server" width="900px" height="500px"></iframe></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>            
            
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
                </tr>
            
        </table>
    </div>
</asp:Content>

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
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxGridView ID="gvReports" runat="server" Width="100%">
                        <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" />
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxGridViewExporter ID="gvExporter" runat="server" GridViewID="gvReports" 
                        BottomMargin="20" LeftMargin="20" RightMargin="20" TopMargin="20">
                    </dx:ASPxGridViewExporter>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <dx:ASPxComboBox ID="cbmExporter" runat="server" 
                            onbuttonclick="cbmExporter_ButtonClick" Width="200px" SelectedIndex="0" 
                            Visible="False">
                            <Items>
                                <dx:ListEditItem Text="PDF" Value="PDF" Selected="True" />
                                <dx:ListEditItem Text="RTF" Value="RTF" />
                                <dx:ListEditItem Text="Excel" Value="Excel" />
                                <dx:ListEditItem Text="CSV" Value="CSV" />
                            </Items>
                            <DropDownButton Position="Left">
                            </DropDownButton>
                            <Buttons>
                                <dx:EditButton Text="Export Report" Width="100px">
                                </dx:EditButton>
                            </Buttons>
                        </dx:ASPxComboBox>
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPreview.aspx.cs" Inherits="HBM.Reports.ReportPreview" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <div class="wrapper-switchboard">
     
        <table width="100%">
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvReports" runat="server" Width="100%" 
                        EnableViewState="False">
                        <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" 
                            ShowFooter="True" />
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridViewExporter ID="gvExporter" runat="server" GridViewID="gvReports" 
                        BottomMargin="20" LeftMargin="20" RightMargin="20" TopMargin="20">
                    </dx:ASPxGridViewExporter>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                </tr>
                <tr>
                    <td>
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
    </form>
</body>
</html>

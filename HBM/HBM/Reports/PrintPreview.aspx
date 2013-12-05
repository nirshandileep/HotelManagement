<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPreview.aspx.cs" Inherits="HBM.Reports.PrintPreview" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper-printpriview">
        <h2>
            Print Preview</h2>
        <div>
            <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' ReportViewerID="rvReportViewer">
                <Items>
                    <dx:ReportToolbarButton ItemKind='Search' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='PrintReport' />
                    <dx:ReportToolbarButton ItemKind='PrintPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                    <dx:ReportToolbarLabel ItemKind='PageLabel' />
                    <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind='OfLabel' />
                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                    <dx:ReportToolbarButton ItemKind='NextPage' />
                    <dx:ReportToolbarButton ItemKind='LastPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                    <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                    <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                        <Elements>
                            <dx:ListElement Value='pdf' />
                            <dx:ListElement Value='xls' />
                            <dx:ListElement Value='xlsx' />
                            <dx:ListElement Value='rtf' />
                            <dx:ListElement Value='mht' />
                            <dx:ListElement Value='html' />
                            <dx:ListElement Value='txt' />
                            <dx:ListElement Value='csv' />
                            <dx:ListElement Value='png' />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='3px' MarginRight='3px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
        </div>
        <div>
            <dx:ReportViewer ID="rvReportViewer" runat="server">
            </dx:ReportViewer>
        </div>
    </div>
    </form>
</body>
</html>

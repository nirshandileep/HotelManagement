<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="HBM.Dashboard" %>

<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $winHeight = $(document).height();
            $newHeight = $winHeight - 300;
            //alert($newHeight);
            $(".page-wrapper").css("height", $newHeight);

        });
    </script>
    <div class="wrapper">
        <h2>
            Dashboard</h2>
        <table class="dxflInternalEditorTable">
            <tr>
                <td>
                    Today Checkins
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxGridView ID="gvTodayCheckingss" runat="server">
                        </dx:ASPxGridView>
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Dorty Rooms
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxGridView ID="gvDirtyRooms" runat="server">
                        </dx:ASPxGridView>
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

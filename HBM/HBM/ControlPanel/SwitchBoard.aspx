<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="SwitchBoard.aspx.cs" Inherits="HBM.ControlPanel.SwitchBoard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="dxflInternalEditorTable">
        <tr>
            <td>
                Swtich Board
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTabControl ID="tcCommon" runat="server" ActiveTabIndex="0" 
                    ontabclick="tcCommon_TabClick" Width="100%" RenderMode="Lightweight">
                    <Tabs>
                        <dx:Tab Text="Bed Types">
                        </dx:Tab>
                        <dx:Tab Text="Departments">
                        </dx:Tab>
                        <dx:Tab Text="Guarantee">
                        </dx:Tab>
                        <dx:Tab Text="Rooms">
                        </dx:Tab>
                        <dx:Tab Text="Source">
                        </dx:Tab>
                    </Tabs>
                </dx:ASPxTabControl>
                
            </td>
        </tr>
    </table>
    <div><iframe id="iframePage" runat="server" width="100%" height="400px"></iframe></div>
</asp:Content>

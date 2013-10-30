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
                <dx:ASPxTabControl ID="ASPxTabControl1" runat="server" ActiveTabIndex="0" 
                    RenderMode="Classic">
                    <Tabs>
                        <dx:Tab>
                            <ActiveTabTemplate>
                                <iframe src="BedType.aspx"></iframe>
                            </ActiveTabTemplate>
                        </dx:Tab>
                        <dx:Tab>
                           <ActiveTabTemplate>
                                <iframe src="Department.aspx"></iframe>
                            </ActiveTabTemplate>
                        </dx:Tab>
                    </Tabs>
                </dx:ASPxTabControl>
            </td>
        </tr>
    </table>
</asp:Content>

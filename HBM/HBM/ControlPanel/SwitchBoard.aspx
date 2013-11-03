<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="SwitchBoard.aspx.cs" Inherits="HBM.ControlPanel.SwitchBoard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
    <h2>Swtich Board</h2>
        <table class="dxflInternalEditorTable">
            <tr>
                <td>&nbsp;
                     
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td style="margin-bottom:5px;" align="left">
                    <dx:ASPxTabControl ID="tcCommon" runat="server" ActiveTabIndex="0" OnTabClick="tcCommon_TabClick"
                        Width="900px" Height="25px" TabSpacing="0px" TabAlign="left">
                        <Tabs>
                            <dx:Tab Text="Bed Types" Name="BedType">
                            </dx:Tab>
                            <dx:Tab Text="Departments" Name="Departments">
                            </dx:Tab>
                            <dx:Tab Text="Guarantee" Name="Gaurantee">
                            </dx:Tab>
                            <dx:Tab Text="Rooms" Name="Rooms">
                            </dx:Tab>
                            <dx:Tab Name="RatePlan" Text="Rate Plan">
                            </dx:Tab>
                            <dx:Tab Text="Source" Name="Source">
                            </dx:Tab>
                            <dx:Tab Name="TaxTypes" Text="Tax Types">
                            </dx:Tab>
                        </Tabs>
                    </dx:ASPxTabControl>
                </td>
            </tr>
        </table>
        <div>
            <iframe id="iframePage" runat="server" width="900px" height="400px" style="overflow-y: scroll; overflow-x:hidden;"></iframe>
        </div>
    </div>
</asp:Content>

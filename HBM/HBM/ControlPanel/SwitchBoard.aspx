<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="SwitchBoard.aspx.cs" Inherits="HBM.ControlPanel.SwitchBoard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            Swtich Board</h2>
        <table class="dxflInternalEditorTable">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTabControl ID="tcCommon" runat="server" ActiveTabIndex="11" OnTabClick="tcCommon_TabClick"
                        Width="900px" Height="25px" TabAlign="Justify" 
                        EnableTheming="True" TabSpacing="0px">
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
                             <dx:Tab Name="RoomRatePlan" Text="Room Rate Plan" NewLine="True">
                            </dx:Tab>
                            <dx:Tab Text="Source" Name="Source">
                            </dx:Tab>
                            <dx:Tab Name="TaxTypes" Text="Tax Types">
                            </dx:Tab>
                            <dx:Tab Name="AdditionalServiceType" Text="Additional Service Type">
                            </dx:Tab>
                            <dx:Tab Name="AdditionalService" Text="Additional Service">
                            </dx:Tab>
                            <dx:Tab Name="GuestType" Text="Guest Types" NewLine="True">
                            </dx:Tab>
                            <dx:Tab Name="CreditCardTypes" Text="Credit Card Types">
                            </dx:Tab>
                            <dx:Tab Name="PaymentTypes" Text="Payment Types">
                            </dx:Tab>
                            <dx:Tab Name="ServiceMethods" Text="Service Methods">
                            </dx:Tab>
                        </Tabs>
                    </dx:ASPxTabControl>
                </td>
            </tr>
        </table>
        <div>
            <iframe id="iframePage" runat="server" width="900px" height="500px"></iframe>
        </div>
    </div>
</asp:Content>

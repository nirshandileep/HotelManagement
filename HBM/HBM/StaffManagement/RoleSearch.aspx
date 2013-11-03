<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="RoleSearch.aspx.cs" Inherits="HBM.RoleSearch" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="w875">
        Search Roles</h2>
    <table class="style1">
        <tr>
            <td>
                <dx:ASPxGridView ID="gvRoles" runat="server" Width="100%" AutoGenerateColumns="False"
                    KeyFieldName="RolesId">
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Role Name" FieldName="RolesId">
                            <DataItemTemplate>
                                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/StaffManagement/Roles.aspx?RolesId=",Eval("RolesId")) %>'
                                    Text='<%# Eval("RoleName") %>' />
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Role Description" FieldName="RoleDescription"
                            VisibleIndex="2">
                        </dx:GridViewDataTextColumn>                     
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
</asp:Content>

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
    <table class="style1">
        <tr>
            <td>
                Search Roles
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvRoles" runat="server" Width="100%" AutoGenerateColumns="False"
                    KeyFieldName="RolesId" Theme="Glass">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="RolesId" FieldName="RolesId" 
                            VisibleIndex="0" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Role Name" FieldName="RoleName" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Role Description" FieldName="RoleDescription"
                            VisibleIndex="2">
                        </dx:GridViewDataTextColumn>                        
                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Edit">
                        <DataItemTemplate>
                            <a id="clickElement" target="_blank" href="Roles.aspx?RolesId=<%# Container.KeyValue%>">Edit </a>
                        </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
</asp:Content>

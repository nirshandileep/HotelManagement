<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="RoleSearch.aspx.cs" Inherits="HBM.RoleSearch" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
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
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Roles.aspx?RoleId=4">HyperLink</asp:HyperLink>
                <dx:ASPxGridView ID="gvRoles" runat="server" Width="100%" 
                    AutoGenerateColumns="False" KeyFieldName="RoleId" >
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="RoleId" FieldName="RoleId" 
                            VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Role Name" 
                            FieldName="RoleName" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="Role Description" 
                            FieldName="RoleDescription" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataHyperLinkColumn Caption="Edit" VisibleIndex="3">
                            <PropertiesHyperLinkEdit Text="Edit" 
                                NavigateUrlFormatString="&quot;/Roles.aspx&quot;">
                            </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                        
                    </Columns>
                    
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
</asp:Content>

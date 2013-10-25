<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="UserSearch.aspx.cs" Inherits="HBM.UserSearch" %>
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
            <td height="21">
                Search Users
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvUsers" runat="server" Width="100%" AutoGenerateColumns="False"
                    KeyFieldName="UsersId" Theme="Glass">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="UserId" FieldName="UserId" VisibleIndex="0" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="UserName" FieldName="UserName" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="FirstName" FieldName="FirstName" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="LastName" FieldName="LastName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="EmailAddress" FieldName="EmailAddress" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Edit">
                            <DataItemTemplate>
                                <a id="clickElement" target="_blank" href="Users.aspx?UserId=<%# Container.KeyValue%>">
                                    Edit </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                    <Settings ShowFilterRow="True"></Settings>
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
</asp:Content>

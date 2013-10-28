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
<h2 class="w875">Search Users</h2>
    <table>
       
        <tr>
            <td>
                <dx:ASPxGridView ID="gvUsers" runat="server" Width="100%" AutoGenerateColumns="False"
                    KeyFieldName="UsersId"  >
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="UserId" FieldName="UserId" VisibleIndex="0" Visible="False" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="User Name" FieldName="UserName" VisibleIndex="1" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="First Name" FieldName="FirstName" VisibleIndex="2" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Last Name" FieldName="LastName" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Email Address" FieldName="EmailAddress" VisibleIndex="4" Width="100px">
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

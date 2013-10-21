<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Roles.aspx.cs" Inherits="HBM.Roles" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                Add Roles
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            Role Name:
                            <asp:HiddenField ID="hdnRoleId" runat="server" />
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtRoleName" runat="server" Width="170px" MaxLength="50">
                                <ValidationSettings Display="Dynamic" ValidationGroup="vgSave">
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Role Description:
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtRoleDescription" runat="server" Width="170px" 
                                MaxLength="50">
                                <ValidationSettings Display="Dynamic" ValidationGroup="vgSave">
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Rights List
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvRights" runat="server" Width="100%" 
                    AutoGenerateColumns="False" KeyFieldName="RightId">
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Module" FieldName="ModuleName" 
                            VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Right Name" FieldName="RightName" 
                            VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Description" FieldName="RightDescription" 
                            VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="RightId" FieldName="RightId" 
                            VisibleIndex="5" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="RolesId" FieldName="RolesId" 
                            VisibleIndex="6" Visible="False">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
</asp:Content>

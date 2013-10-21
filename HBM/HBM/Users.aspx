<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HBM.Users" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
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
                <asp:HiddenField ID="hdnUserId" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                First Name</td>
            <td>
                <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name</td>
            <td>
                <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RegularExpression ErrorText="Invalid" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                User Name</td>
            <td>
                <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <dx:ASPxTextBox ID="txtPassword" runat="server" Password="True" Width="170px" 
                    MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <dx:ASPxTextBox ID="txtConfirmPassword" runat="server" Password="True" 
                    Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Role</td>
            <td>
                <dx:ASPxComboBox ID="ddlRoles" runat="server" EnableIncrementalFiltering="True" 
                    IncrementalFilteringMode="StartsWith" TextFormatString="{0}">
                    <Columns>
                        <dx:ListBoxColumn Caption="RoleName" FieldName="RoleName" />
                        <dx:ListBoxColumn Caption="RoleDescription" FieldName="RoleDescription" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                    ValidationGroup="vgSave">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HBM.Users" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
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
                <asp:HiddenField ID="hdnUserId" runat="server" />
            </td>
            <td>&nbsp;
                </td>
        </tr>
        <tr>
            <td height="17">
                First Name</td>
            <td>
                <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px" MaxLength="50" 
                    Theme="Glass">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td height="17">
                Last Name</td>
            <td>
                <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td height="17">
                Email</td>
            <td>
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RegularExpression ErrorText="Invalid" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
       
        <tr>
            <td height="17">
                User Name</td>
            <td>
                <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td height="17">
                Password</td>
            <td>
                <dx:ASPxTextBox ID="txtPassword" runat="server" Password="True" Width="170px" 
                    MaxLength="50" EnableClientSideAPI="True" 
                    oncustomjsproperties="txtPassword_CustomJSProperties" 
                    ClientInstanceName="password">
                    <ClientSideEvents Init="function(s, e) {
	 s.SetValue(s.cp_myPassword);
}" />
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td height="17">
                Confirm Password</td>
            <td>
                <dx:ASPxTextBox ID="txtConfirmPassword" runat="server" Password="True" 
                    Width="170px" MaxLength="50" 
                    oncustomjsproperties="txtConfirmPassword_CustomJSProperties" Theme="Glass" 
                    ClientInstanceName="confirmTb">
                    <ClientSideEvents Init="function(s, e) {
	s.SetValue(s.cp_myPassword);
}" LostFocus="function(s, e) {
	
if ((password.GetText() == confirmTb.GetText()))
{
     e.IsValid=true;
}
else
{
     e.IsValid=false;
}
 
}" Validation="function(s, e) {

}" />
                    <ValidationSettings ValidationGroup="vgSave" CausesValidation="True" 
                        Display="Dynamic" EnableCustomValidation="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
   
        <tr>
            <td height="17">
                Role</td>
            <td>
                <dx:ASPxComboBox ID="ddlRoles" runat="server" EnableIncrementalFiltering="True" 
                    IncrementalFilteringMode="StartsWith" TextFormatString="{0}" Theme="Glass">
                    <Columns>
                        <dx:ListBoxColumn Caption="RoleName" FieldName="RoleName" />
                        <dx:ListBoxColumn Caption="RoleDescription" FieldName="RoleDescription" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
                </td>
            <td>&nbsp;
                </td>
        </tr>
        <tr>
            <td>&nbsp;
                </td>
            <td>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                    ValidationGroup="vgSave" Theme="Glass">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>

</asp:Content>

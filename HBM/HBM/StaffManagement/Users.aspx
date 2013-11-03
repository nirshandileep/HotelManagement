<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="HBM.Users" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
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
    <div class="wrapper">
        <h2>
            Add User</h2>
        <table class="style1">
            <tr>
                <td width="20%">
                    <asp:HiddenField ID="hdnUserId" runat="server" />
                </td>
                <td width="80%">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="21">
                    First Name
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Last Name
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Email
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RegularExpression ErrorText="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    User Name
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Username must be 5 charactrs" 
                                ValidationExpression="^[a-zA-Z0-9]+$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Password
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Password="True" Width="170px" MaxLength="50"
                        EnableClientSideAPI="True" OnCustomJSProperties="txtPassword_CustomJSProperties"
                        ClientInstanceName="password1">
                        <ClientSideEvents Init="function(s, e) {
	 s.SetValue(s.cp_myPassword);
}" />
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Password must be 6 charactors" 
                                ValidationExpression="^[a-zA-Z0-9]+$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Confirm Password
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtConfirmPassword" runat="server" Password="True" Width="170px"
                        MaxLength="50" OnCustomJSProperties="txtConfirmPassword_CustomJSProperties" ClientInstanceName="password2">
                        <ClientSideEvents Init="function(s, e) {
	s.SetValue(s.cp_myPassword);
}" LostFocus="function(s, e) {
	

 
}" Validation="function(s, e) {
	var originalPasswd = password1.GetText();
    var currentPasswd = s.GetText();
    e.isValid = (originalPasswd  == currentPasswd );
}" />
                        <ValidationSettings ValidationGroup="vgSave" CausesValidation="True" Display="Dynamic"
                            EnableCustomValidation="True">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Password must be 6 charactors" 
                                ValidationExpression="^[a-zA-Z0-9]+$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Role
                </td>
                <td>
                    <dx:ASPxComboBox ID="ddlRoles" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                        TextFormatString="{0}">
                        <Columns>
                            <dx:ListBoxColumn Caption="RoleName" FieldName="RoleName" />
                            <dx:ListBoxColumn Caption="RoleDescription" FieldName="RoleDescription" />
                        </Columns>
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" 
                            ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td height="19">&nbsp;
                    
                </td>
                <td>&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                    
                </td>
                <td>
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" 
                        ValidationGroup="vgSave" HorizontalAlign="Center" ImageSpacing="15px" 
                        VerticalAlign="Middle">
                        <Image Url="~/Images/Save.png"  width="16" height="16">
                        </Image>
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

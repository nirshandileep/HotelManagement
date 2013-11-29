<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="HBM.Users" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            Add User</h2>
        <table class="user-tbl">
            <tr>
                <td width="15%">
                    <asp:HiddenField ID="hdnUserId" runat="server" />
                </td>
                <td width="80%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="21">
                    First Name<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Last Name<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Email<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RegularExpression ErrorText="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    User Name<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Username must be more than 5 chars with no spaces]"
                                ValidationExpression="^[a-zA-Z0-9~!@#$%^&*]{5,20}$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Password<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Password="True" Width="170px" MaxLength="50"
                        EnableClientSideAPI="True" OnCustomJSProperties="txtPassword_CustomJSProperties"
                        ClientInstanceName="password1">
                        <ClientSideEvents Init="function(s, e) {
	 s.SetValue(s.cp_myPassword);
}" />
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Password must be 6 charactors" ValidationExpression="^[a-zA-Z0-9~!@#$%^&*]{6,20}$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Confirm Password<span class="reqfield">*</span>
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
                            EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorText="Password must match">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                            <RegularExpression ErrorText="Password must be 6 charactors" ValidationExpression="^[a-zA-Z0-9~!@#$%^&*]{6,20}$" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Role<span class="reqfield">*</span>
                </td>
                <td>
                    <dx:ASPxComboBox ID="ddlRoles" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                        TextFormatString="{0}" ValueType="System.Int32">
                        <Columns>
                            <dx:ListBoxColumn Caption="RoleName" FieldName="RoleName" />
                            <dx:ListBoxColumn Caption="RoleDescription" FieldName="RoleDescription" />
                        </Columns>
                        <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td height="21">
                    Department <span class="reqfield">*</span>
                </td>
                <td >
                    <dx:ASPxComboBox ID="ddlDepartment" runat="server" IncrementalFilteringMode="Contains"
                        TextFormatString="{0}" ValueType="System.Int32" 
                        ClientInstanceName="ddlDepartment">
                        <ClientSideEvents ButtonClick="function(s, e) {
  	ShowPopupWindow(ppcDepartment);
}" />
                        <Buttons>
                            <dx:EditButton Position="Left" Text="..." ToolTip="Add/Edit Department">
                            </dx:EditButton>
                        </Buttons>
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td height="19">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"
                        HorizontalAlign="Center" ImageSpacing="15px" VerticalAlign="Middle">
                        <Image Url="~/Images/Save.png">
                        </Image>
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <dx:ASPxPopupControl ID="ppcDepartment" HeaderText="Department" AllowDragging="True"
            runat="server" ClientInstanceName="ppcDepartment" Modal="True" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" Width="700px" Height="350px" ContentUrl="~/ControlPanel/Department.aspx">
            <ClientSideEvents CloseUp="function(s, e) {
	ddlDepartment.PerformCallback();
}" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</asp:Content>

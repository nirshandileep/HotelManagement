<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="~/ControlPanel/Company.aspx.cs" Inherits="HBM.ControlPanel.Company" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h2>Company Information</h2>
        <table class="style1">
            <tr>
                <td colspan="2">
                    &nbsp;
                    <asp:HiddenField ID="hdnCompanyLogo" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Company Name
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyAddress" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    City
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyCity" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyEmail" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                            <RegularExpression ErrorText="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Telephone
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyTelephone" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fax
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyFax" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Company Logo
                </td>
                <td>
                    <dx:ASPxUploadControl ID="ucCompanyLogo" runat="server" Width="280px" OnFileUploadComplete="ucCompanyLogo_FileUploadComplete">
                    </dx:ASPxUploadControl>
                </td>
            </tr>
            <tr id="trImageRow" runat="server" visible="false">
                <td>
                    &nbsp;
                </td>
                <td>
                    <dx:ASPxBinaryImage ID="bimgLogo" runat="server" Height="100px" Width="100px">
                    </dx:ASPxBinaryImage>
                </td>
            </tr>
            <tr>
                <td>
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
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save" OnClick="btnSave_Click"
                        HorizontalAlign="Center" ImageSpacing="15px" VerticalAlign="Middle">
                        <Image Url="~/Images/Save.png">
                        </Image>
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

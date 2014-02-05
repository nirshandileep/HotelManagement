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
    <div class="wrapper-inner">
        <h2>
            Company Information</h2>
        <table class="company-info-tbl">
            <tr>
                <td colspan="2">
                    &nbsp;
                    <asp:HiddenField ID="hdnCompanyLogo" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="130" height="22">
                    Company Name<span class="reqfield">*</span>
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
                <td height="22">
                    Address<span class="reqfield">*</span>
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
                <td height="22">
                    City<span class="reqfield">*</span>
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
                <td height="22">
                    Email<span class="reqfield">*</span>
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
                <td height="22">
                    Telephone<span class="reqfield">*</span>
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
                <td height="22">
                    Fax<span class="reqfield">*</span>
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
                <td height="22">
                    Web URL<span class="reqfield">*</span></td>
                <td>
                    <dx:ASPxTextBox ID="txtWebURL" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RegularExpression ErrorText="Format should be http://www.example.com" 
                                ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="22">
                    Registration No<span class="reqfield">*</span></td>
                <td>
                    <dx:ASPxTextBox ID="txtRegistrationNo" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="22">
                    VAT No<span class="reqfield">*</span></td>
                <td>
                    <dx:ASPxTextBox ID="txtVATNo" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="22">
                    Additional Details 1<span class="reqfield">*</span></td>
                <td>
                    <dx:ASPxTextBox ID="txtAdditionalDetails1" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td height="22">
                    Additional Details 2<span class="reqfield">*</span></td>
                <td>
                        <dx:ASPxTextBox ID="txtAdditionalDetails2" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                            <RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox></td>
            </tr>
      
            <tr>
                <td height="22">
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
                        <Image Url="~/Images/Save.png" Width="16" Height="16">
                        </Image>
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="HBM.ControlPanel.Company" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           Company Information
        <table class="style1">
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Company Name</td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyName" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" >
                            <RequiredField ErrorText="Required" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address</td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyAddress" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    City</td>
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
                    Email</td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyEmail" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
<RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                            <RegularExpression ErrorText="Invalid" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Telephone</td>
                <td>
                    <dx:ASPxTextBox ID="txtCompanyTelephone" runat="server" Width="170px" 
                        MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField ErrorText="Required" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="Required"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fax</td>
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Company Logo</td>
                <td>
                    <dx:ASPxUploadControl ID="ucCompanyLogo" runat="server" Width="280px">
                    </dx:ASPxUploadControl>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                     <img src="" id="previewImage" alt="" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <dx:ASPxButton ID="btnUplaod" runat="server" Text="Upload">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                     &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

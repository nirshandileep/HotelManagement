<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HBM.Login" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            width: 500px;
        }
        body
        {
            font-family: "Trebuchet MS" , Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #000;
            background: url(images/back.jpg) center top no-repeat;
        }
        #lblError
        {
            position: absolute;
            margin-top: 7px;
            margin-left: -6px;
        }
    </style>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-win">
        <div class="login-head">
        </div>
        <div class="login-body">
            <div class="login-body-img">
                <table width="670" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <img src="images/login-logo.jpg" width="106" height="86" class="flt-l" />
                            <p class="txt-right flt-r w355">
                                VinIT Solutions<br />
                                No 11, Station Road, Harlesden<br />
                                London, NW10 4UJ<br />
                                TeL : 0203 551 9908 / 0208 965 1451<br />
                                Fax : info@reservation.com<br />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td width="621">
                            &nbsp;
                        </td>
                        <td width="19">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <table width="500" align="center" class="style1">
                                <tr>
                                    <td colspan="3">
                                        <div>
                                            <h2>
                                                Welcome to Hotel Management System login</h2>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="26%">
                                        <label>
                                            User Name</label>
                                    </td>
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" Text="Admin">
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Password</label>
                                    </td>
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="txtPassword" runat="server" Width="170px" Password="True" Text="letmein">
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td width="15%">
                                        <dx:ASPxButton ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click">
                                        </dx:ASPxButton>
                                    </td>
                                    <td width="56%">
                                        <asp:Label ID="lblError" CssClass="error" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="login-footer">
            Copyright &copy; 2014 by VinIT Solutions. All rights reserved.
        </div>
    </div>
    </form>
</body>
</html>

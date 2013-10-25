﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HBM.Login" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
	body{
	font-family:"Trebuchet MS", Arial, Helvetica, sans-serif;
	font-size:12px;
	color:#000;
	background:url(images/back.jpg) center top no-repeat;
	}
    </style>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <div class="login-win">
    <h2>Welcome to Hotel Management Saystem login</h2>
        <table class="style1">
            <tr>
                <td width="32%">
                   <label> User Name</label>
                </td>
                <td width="68%">
                    <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" 
                        Theme="Glass">
                        <ValidationSettings Display="Dynamic">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                   <label> Password</label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Width="170px" Password="True" 
                        Theme="Glass">
                        <ValidationSettings Display="Dynamic">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr id="trMsg" runat="server" visible="false">
                <td>&nbsp;&nbsp;</td>
                <td> 
                    <asp:Label ID="lblError" CssClass="error" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                    
                </td>
                <td>
                    <dx:ASPxButton ID="btnLogin" runat="server" Text="Login" 
                        onclick="btnLogin_Click" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

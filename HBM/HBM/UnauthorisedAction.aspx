<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnauthorisedAction.aspx.cs"
    Inherits="HBM.UnauthorisedAction" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unauthorized Action</title>
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 10px;">
    </div>
    <div class="unauthorizedpage-wrapper">
        <table>
            <tr>
                <td align="center" valign="middle" width="50px" style="position: relative; top: 7px;">
                    <img src="Images/Danger.png" />
                </td>
                <td align="center" valign="middle">
                    <div>
                        <h3>
                            You don't have authorization to access this page!
                        </h3>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    <h4>
                        Please contact administrator!!!</h4>
                </td>
            </tr>
            <tr height="220px">
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <h4>
                        <asp:LinkButton ID="lnkLogin" runat="server" onclick="lnkLogin_Click">Login</asp:LinkButton>
                    </h4>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

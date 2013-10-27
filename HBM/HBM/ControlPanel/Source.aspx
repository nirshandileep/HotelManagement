<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Source.aspx.cs" Inherits="HBM.Reservation.Source" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    
        <table class="style1">
            <tr>
                <td>
                    Source</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Gaurantee Name" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="2">
                                <EditButton Visible="True">
                                </EditButton>
                                <NewButton Visible="True">
                                </NewButton>
                                <DeleteButton Visible="True">
                                </DeleteButton>
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Description" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>

</html>

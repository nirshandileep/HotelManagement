﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCardType.aspx.cs" Inherits="HBM.ControlPanel.CreditCardType" %>

<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper-switchboard">
        <h2>
            Credit Card List</h2>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvCreditCardTypes" runat="server" 
                        AutoGenerateColumns="False" KeyFieldName="CreditCardTypeId"
                        OnRowInserting="gvCreditCardTypes_RowInserting" OnRowDeleting="gvCreditCardTypes_RowDeleting"
                        OnRowUpdating="gvCreditCardTypes_RowUpdating" 
                        oncommandbuttoninitialize="gvCreditCardTypes_CommandButtonInitialize">
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="2" ButtonType="Image" Width="120px" Caption="Actions"
                                FixedStyle="Left">
                                <DeleteButton Visible="True">
                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                    </Image>
                                </DeleteButton>
                                <EditButton Visible="True">
                                    <Image ToolTip="Edit" Url="~/Images/update.png">
                                    </Image>
                                </EditButton>
                                <NewButton Visible="True">
                                    <Image ToolTip="New" Url="~/Images/new.png">
                                    </Image>
                                </NewButton>
                                <UpdateButton Visible="True">
                                    <Image Url="~/Images/Apply.png">
                                    </Image>
                                </UpdateButton>
                                <CancelButton Visible="True">
                                    <Image Url="~/Images/Close.png" ToolTip="Cancel">
                                    </Image>
                                </CancelButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" VisibleIndex="0">
                                <PropertiesTextEdit MaxLength="50">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn Caption="ProcessingFee" 
                                FieldName="ProcessingFee" VisibleIndex="1">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="100">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                        </Columns>
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsText ConfirmDelete="" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
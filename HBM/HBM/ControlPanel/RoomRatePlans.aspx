<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomRatePlans.aspx.cs" Inherits="HBM.ControlPanel.RoomRatePlans" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper-switchboard">
        <h2>
            Room Rate Plan</h2>
        <table>
            <tr>
                <td>
                    <dx:ASPxComboBox ID="cmbRooms" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbRooms_SelectedIndexChanged" ValueType="System.Int32">
                        <Columns>
                            <dx:ListBoxColumn FieldName="RoomName" />
                            <dx:ListBoxColumn FieldName="RoomCode" />
                            <dx:ListBoxColumn FieldName="RoomNumber" />
                            <dx:ListBoxColumn FieldName="MaxAdult" />
                            <dx:ListBoxColumn FieldName="MaxChildren" />
                            <dx:ListBoxColumn FieldName="MaxInfant" />
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvRatePlan" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="RoomRatePlanId" OnRowInserting="gvRatePlan_RowInserting"
                        OnRowDeleting="gvRatePlan_RowDeleting" OnRowUpdating="gvRatePlan_RowUpdating"
                        OnCellEditorInitialize="gvRatePlan_CellEditorInitialize" Width="550px">
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Width="120px" Caption="Actions"
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
                            <dx:GridViewDataComboBoxColumn Caption="Rate Plan" FieldName="RatePlansId"
                                VisibleIndex="3" UnboundType="Integer">
                                <PropertiesComboBox
                                    ValueType="System.Int32">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="Note" UnboundType="String" 
                                VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
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

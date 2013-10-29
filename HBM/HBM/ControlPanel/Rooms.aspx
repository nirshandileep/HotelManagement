<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="HBM.Reservation.Rooms" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table >
            <tr>
                <td>
                    Rooms</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvRooms" runat="server" AutoGenerateColumns="False" 
                        KeyFieldName="RoomId" onrowdeleting="gvRooms_RowDeleting" 
                        onrowinserting="gvRooms_RowInserting" onrowupdating="gvRooms_RowUpdating">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Room Name" FieldName="" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="7">
                                <EditButton Visible="True">
                                </EditButton>
                                <NewButton Visible="True">
                                </NewButton>
                                <DeleteButton Visible="True">
                                </DeleteButton>
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Code" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Room No" VisibleIndex="2">
                                <PropertiesSpinEdit DisplayFormatString="g">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Adult" VisibleIndex="3">
                                <PropertiesSpinEdit DisplayFormatString="g">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Children" VisibleIndex="4">
                                <PropertiesSpinEdit DisplayFormatString="g">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Infant" VisibleIndex="5">
                                <PropertiesSpinEdit DisplayFormatString="g">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataCheckColumn Caption="Allow Smoking" VisibleIndex="6">
                            </dx:GridViewDataCheckColumn>
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

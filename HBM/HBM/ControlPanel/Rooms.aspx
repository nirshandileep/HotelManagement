<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="HBM.Reservation.Rooms" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    Room List
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvRooms" runat="server" AutoGenerateColumns="False" KeyFieldName="RoomId"
                        OnRowDeleting="gvRooms_RowDeleting" OnRowInserting="gvRooms_RowInserting" 
                        OnRowUpdating="gvRooms_RowUpdating" 
                        oncelleditorinitialize="gvRooms_CellEditorInitialize">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Room Name" FieldName="RoomName" VisibleIndex="0">
                                <PropertiesTextEdit>
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="9">
                                <EditButton Visible="True">
                                </EditButton>
                                <NewButton Visible="True">
                                </NewButton>
                                <DeleteButton Visible="True">
                                </DeleteButton>
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Code" VisibleIndex="1" FieldName="RoomCode">
                                <PropertiesTextEdit>
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Room No" FieldName="RoomNumber" VisibleIndex="2">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="5" MaxValue="10000" NullDisplayText="0"
                                    NullText="0" NumberType="Integer">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Adult" VisibleIndex="4" FieldName="MaxAdult">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="5" MaxValue="100" NullDisplayText="0"
                                    NullText="0" NumberType="Integer">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Children" VisibleIndex="5" FieldName="MaxChildren">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="5" MaxValue="100" NullDisplayText="0"
                                    NullText="0" NumberType="Integer">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Max Infant" VisibleIndex="6" FieldName="MaxInfant">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="5" MaxValue="100" NullDisplayText="0"
                                    NullText="0" NumberType="Integer">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataCheckColumn Caption="Allow Smoking" VisibleIndex="7" FieldName="SmokingAllow">
                            </dx:GridViewDataCheckColumn>
                            
                            <dx:GridViewDataComboBoxColumn Caption="Bed Type" FieldName="BedTypeId" 
                                VisibleIndex="3">
                            </dx:GridViewDataComboBoxColumn>
                            
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

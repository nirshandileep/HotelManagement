<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RatePlans.aspx.cs" Inherits="HBM.Reservation.RatePlan" %>

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
            Rate Plan List</h2>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvRatePlans" runat="server" AutoGenerateColumns="False" KeyFieldName="RatePlansId"
                        OnRowDeleting="gvRatePlans_RowDeleting" OnRowInserting="gvRatePlans_RowInserting"
                        OnRowUpdating="gvRatePlans_RowUpdating">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Rate Plan Name" VisibleIndex="0" FieldName="RatePlanName">
                                <PropertiesTextEdit>
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Image" Width="120px" Caption="Actions"
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
                            <dx:GridViewDataDateColumn Caption="Effective From" VisibleIndex="1" FieldName="EffectiveFrom">
                                <PropertiesDateEdit DisplayFormatInEditMode="True" EditFormatString="d" 
                                    EditFormat="Custom">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="Effective To" VisibleIndex="2" FieldName="EffectiveTo">
                                <PropertiesDateEdit DisplayFormatInEditMode="True" EditFormat="Custom" EditFormatString="d">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Rate" VisibleIndex="3" FieldName="Rate">
                                <PropertiesSpinEdit DisplayFormatString="F2" MaxLength="5" MaxValue="100000" NullDisplayText="0"
                                    NullText="0" NumberFormat="Custom">
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Additional Adult Rate" VisibleIndex="4" FieldName="AdditionalAdultRate">
                                <PropertiesSpinEdit DisplayFormatString="F2" MaxLength="5" MaxValue="100000" NullDisplayText="0"
                                    NullText="0" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Additional Child Rate" VisibleIndex="5" FieldName="AdditionalChildrenRate">
                                <PropertiesSpinEdit DisplayFormatString="F2" MaxLength="5" MaxValue="100000" NullDisplayText="0"
                                    NullText="0" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Additional Infant Rate" VisibleIndex="6"
                                FieldName="AdditionalInfantRate">
                                <PropertiesSpinEdit DisplayFormatString="F2" MaxLength="5" MaxValue="100000" NullDisplayText="0"
                                    NullText="0" NumberFormat="Custom">
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

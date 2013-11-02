<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gaurantee.aspx.cs" Inherits="HBM.Reservation.Gaurantee" %>
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
                    Gaurantee List</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvGaurantee" runat="server" AutoGenerateColumns="False"  KeyFieldName="GuaranteeId"
                        onrowdeleting="gvGaurantee_RowDeleting" 
                        onrowinserting="gvGaurantee_RowInserting" 
                        onrowupdating="gvGaurantee_RowUpdating">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Gaurantee Name" VisibleIndex="0" 
                                FieldName="GuaranteeName">
                                <PropertiesTextEdit>
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="2" ButtonType="Image" Width="75px" Caption="Actions"
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
                            <dx:GridViewDataTextColumn Caption="Description" VisibleIndex="1" 
                                FieldName="GuaranteeDescription">
                                <PropertiesTextEdit>
                                    <ValidationSettings>
                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
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

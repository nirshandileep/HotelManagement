<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BedType.aspx.cs" Inherits="HBM.ControlPanel.BedType" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


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
                    Bed Types List</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvBedTypes" runat="server" AutoGenerateColumns="False" 
            KeyFieldName="BedTypeId" 
                        onrowinserting="gvBedTypes_RowInserting" 
                        onrowdeleting="gvBedTypes_RowDeleting" onrowupdating="gvBedTypes_RowUpdating">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="2">
                    <DeleteButton Visible="True">
                    </DeleteButton>
                    <EditButton Visible="True">
                    </EditButton>
                    <NewButton Visible="True">
                    </NewButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="Bed Type" FieldName="BedTypeName" 
                    VisibleIndex="0">
                    <PropertiesTextEdit MaxLength="50">
                        <ValidationSettings>
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Description" FieldName="BedTypeDescription" 
                    VisibleIndex="1">
                    <PropertiesTextEdit MaxLength="100">
                        <ValidationSettings>
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView></td>
            </tr>
        </table>
        
    
    </div>
    </form>
</body>
</html>

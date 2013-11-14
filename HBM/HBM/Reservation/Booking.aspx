<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Booking.aspx.cs" Inherits="HBM.Reservation.Booking" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            Reservation</h2>
        <table width="100%">
            <tr>
                <td align="center">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="400px" HeaderText="Reservation">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Customer
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            Source
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="ASPxComboBox2" runat="server">
                                            </dx:ASPxComboBox>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="400px" HeaderText="Booking Time">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Check In
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Width="150px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            Check Out
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server" Width="150px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" HeaderText="Booking information">
                        <PanelCollection>
                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" Width="100%">
                                    <TabPages>
                                        <dx:TabPage Text="Guest Info">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True"
                                                                VisibleIndex="0">
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="Customer" ShowInCustomizationForm="True" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="In" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Out" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                <PropertiesTextEdit DisplayFormatString="d">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Room" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Rate Plan" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="# of Adults" ShowInCustomizationForm="True"
                                                                VisibleIndex="6">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="# of Childrens" ShowInCustomizationForm="True"
                                                                VisibleIndex="7">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="# of Infant" ShowInCustomizationForm="True" VisibleIndex="8">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Amount" ShowInCustomizationForm="True" VisibleIndex="9">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                        <dx:TabPage Text="Additional Service">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                    <dx:ASPxGridView ID="gvServiceInformation" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        KeyFieldName="ReservationAdditionalServiceId">
                                                        <TotalSummary>
                                                            <dx:ASPxSummaryItem FieldName="Rate" ShowInColumn="Rate" ShowInGroupFooterColumn="Rate"
                                                                SummaryType="Sum" />
                                                        </TotalSummary>
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ButtonType="Image" Caption="Action" ShowInCustomizationForm="True"
                                                                VisibleIndex="0" Width="80px">
                                                                <EditButton Visible="True">
                                                                    <Image ToolTip="Edit" Url="~/Images/update.png">
                                                                    </Image>
                                                                </EditButton>
                                                                <NewButton Visible="True">
                                                                    <Image ToolTip="New" Url="~/Images/new.png">
                                                                    </Image>
                                                                </NewButton>
                                                                <DeleteButton Visible="True">
                                                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                                                    </Image>
                                                                </DeleteButton>
                                                                <CancelButton Visible="True">
                                                                    <Image Url="~/Images/Close.png">
                                                                    </Image>
                                                                </CancelButton>
                                                                <UpdateButton Visible="True">
                                                                    <Image ToolTip="Save" Url="~/Images/Apply.png">
                                                                    </Image>
                                                                </UpdateButton>
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Service Type" FieldName="AdditionalServiceId"
                                                                ShowInCustomizationForm="True" VisibleIndex="1">
                                                                <PropertiesComboBox TextField="ServiceName" ValueField="AdditionalServiceId" ValueType="System.Int32"
                                                                    IncrementalFilteringMode="StartsWith" TextFormatString="{1}">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="Service Code" FieldName="ServiceCode" />
                                                                        <dx:ListBoxColumn Caption="Service Name" FieldName="ServiceName" />
                                                                        <dx:ListBoxColumn Caption="Rate" FieldName="Rate" />
                                                                    </Columns>
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataSpinEditColumn Caption="Amount" FieldName="Amount" ShowInCustomizationForm="True"
                                                                VisibleIndex="2">
                                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                                    <ValidationSettings>
                                                                        <RequiredField ErrorText="Required" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesSpinEdit>
                                                            </dx:GridViewDataSpinEditColumn>
                                                            <dx:GridViewDataTextColumn Caption="Note" FieldName="Note" ShowInCustomizationForm="True"
                                                                VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <SettingsBehavior AllowGroup="False" SortMode="DisplayText" ConfirmDelete="True" />
                                                        <Settings ShowGroupButtons="False" />
                                                    </dx:ASPxGridView>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:TabPage>
                                    </TabPages>
                                </dx:ASPxPageControl>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

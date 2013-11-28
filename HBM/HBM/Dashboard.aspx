<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="HBM.Dashboard" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $winHeight = $(document).height();
            $newHeight = $winHeight - 300;
            //alert($newHeight);
            $(".page-wrapper").css("height", $newHeight);

        });
    </script>
    <div class="wrapper">
        <h2>
            Dashboard</h2>
    </div>
    <table class="dxflInternalEditorTable">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div>
                    <dx:ASPxPageControl ID="pcPageControl" runat="server" ActiveTabIndex="0" Width="100%"
                        SaveStateToCookies="True">
                        <TabPages>
                            <dx:TabPage Name="Timeline" Text="Timeline">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <dxwschs:ASPxScheduler ID="schReservationDashboad" runat="server" ActiveViewType="Timeline"
                                            ClientIDMode="AutoID" Start="2013-11-18">
                                            <Views>
                                                <DayView>
                                                    <TimeRulers>
                                                        <cc1:TimeRuler />
                                                    </TimeRulers>
                                                </DayView>
                                                <WorkWeekView>
                                                    <TimeRulers>
                                                        <cc1:TimeRuler />
                                                    </TimeRulers>
                                                </WorkWeekView>
                                                <TimelineView>
                                                    <TimelineViewStyles>
                                                        <Appointment BackColor="#FFFFCC">
                                                        </Appointment>
                                                    </TimelineViewStyles>
                                                    <AppointmentDisplayOptions AppointmentInterspacing="10" TimeDisplayType="Text" />
                                                </TimelineView>
                                            </Views>
                                            <OptionsCustomization AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None"
                                                AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="None"
                                                AllowAppointmentMultiSelect="False" AllowAppointmentResize="None" AllowDisplayAppointmentDependencyForm="Never"
                                                AllowDisplayAppointmentForm="Never" AllowInplaceEditor="None" />
                                            <OptionsBehavior RecurrentAppointmentDeleteAction="Cancel" />
                                        </dxwschs:ASPxScheduler>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Name="Arrivals" Text="Arrivals">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="600px" HeaderText="Select date range to search">
                                                        <PanelCollection>
                                                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="middle">
                                                                            From Date:
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxDateEdit ID="dtpArrivalFromDate" runat="server" ClientInstanceName="ArrivalFromDate">
                                                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgArrivalsSearch">
                                                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:ASPxDateEdit>
                                                                        </td>
                                                                        <td class="middle">
                                                                            To Date:
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxDateEdit ID="dtpArrivalToDate" runat="server" ClientInstanceName="ArrivalToDate">
                                                                                <ClientSideEvents Validation="function(s, e) {
	var ArrivalFromDateText=new Date(ArrivalFromDate.GetText());
    var ArrivalToDateText =new Date(ArrivalToDate.GetText());
    e.isValid = (ArrivalToDateText &gt;= ArrivalFromDateText );

}" />
                                                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True"
                                                                                    ErrorText="To date must be recent" ValidationGroup="vgArrivalsSearch">
                                                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:ASPxDateEdit>
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxButton ID="btnSearchArrivals" runat="server" AutoPostBack="False" OnClick="btnSearchArrivals_Click"
                                                                                Text="Search" ValidationGroup="vgArrivalsSearch">
                                                                            </dx:ASPxButton>
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
                                            </tr>
                                        </table>
                                        <dx:ASPxGridView ID="gvArrivals" runat="server" AutoGenerateColumns="False" Width="100%"
                                            OnRowUpdating="gvArrivals_RowUpdating" KeyFieldName="ReservationRoomId">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="CustomerName" ShowInCustomizationForm="True"
                                                    VisibleIndex="1" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReservationCode" ShowInCustomizationForm="True"
                                                    VisibleIndex="3" ReadOnly="True">
                                                    <Settings FilterMode="DisplayText" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Booking.aspx?ReservationId=",Eval("ReservationId")) %>'
                                                            Text='<%# Eval("ReservationCode") %>' />
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomName" ShowInCustomizationForm="True" VisibleIndex="4"
                                                    ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomNumber" ShowInCustomizationForm="True"
                                                    VisibleIndex="5" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckInDate" ShowInCustomizationForm="True"
                                                    UnboundType="DateTime" VisibleIndex="6" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckOutDate" ShowInCustomizationForm="True"
                                                    UnboundType="DateTime" VisibleIndex="7" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn Caption="Actual Check In" FieldName="ActualCheckInDate"
                                                    ShowInCustomizationForm="True" UnboundType="DateTime" VisibleIndex="8">
                                                    <PropertiesDateEdit DisplayFormatString="">
                                                    </PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewCommandColumn ButtonType="Image" Caption="#" ShowInCustomizationForm="True"
                                                    VisibleIndex="0">
                                                    <EditButton Visible="True">
                                                        <Image Url="~/Images/update.png
">
                                                        </Image>
                                                    </EditButton>
                                                    <CancelButton Visible="True">
                                                        <Image Url="~/Images/Close.png">
                                                        </Image>
                                                    </CancelButton>
                                                    <UpdateButton Visible="True">
                                                        <Image Url="~/Images/Apply.png">
                                                        </Image>
                                                    </UpdateButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Sharers" ReadOnly="True" ShowInCustomizationForm="True"
                                                    VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Name="Departures" Text="Departures">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="600px" 
                                                        HeaderText="Select date range to search">
                                                        <PanelCollection>
                                                            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="middle">
                                                                            From Date:
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxDateEdit ID="dtpDeparturesFrom" runat="server" 
                                                                                ClientInstanceName="DeparturesFrom">
                                                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" 
                                                                                    ValidationGroup="vgDepartureSearch">
                                                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:ASPxDateEdit>
                                                                        </td>
                                                                        <td class="middle">
                                                                            To Date:
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxDateEdit ID="dtpDeparturesTo" runat="server" 
                                                                                ClientInstanceName="DeparturesTo">
                                                                                <ClientSideEvents Validation="function(s, e) {
	var DeparturesFromText=new Date(DeparturesFrom.GetText());
    var DeparturesToText =new Date(DeparturesTo.GetText());
    e.isValid = (DeparturesToText &gt;= DeparturesFromText );
}" />
                                                                                <ValidationSettings EnableCustomValidation="True" 
                                                                                    ErrorDisplayMode="ImageWithTooltip" ErrorText="To date must be recent" 
                                                                                    ValidationGroup="vgDepartureSearch">
                                                                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                                                                </ValidationSettings>
                                                                            </dx:ASPxDateEdit>
                                                                        </td>
                                                                        <td class="middle">
                                                                            <dx:ASPxButton ID="btnSearchDepartures" runat="server" Text="Search" 
                                                                                ValidationGroup="vgDepartureSearch">
                                                                            </dx:ASPxButton>
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
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxGridView ID="gvDepartures" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        KeyFieldName="ReservationRoomId" OnRowUpdating="gvDepartures_RowUpdating">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="CustomerName" ShowInCustomizationForm="True"
                                                                VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="ReservationCode" ShowInCustomizationForm="True"
                                                                VisibleIndex="2">
                                                                <Settings FilterMode="DisplayText" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Booking.aspx?ReservationId=",Eval("ReservationId")) %>'
                                                                        Text='<%# Eval("ReservationCode") %>' />
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="RoomName" ShowInCustomizationForm="True" VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="RoomNumber" ShowInCustomizationForm="True"
                                                                VisibleIndex="4">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CheckOutDate" ShowInCustomizationForm="True"
                                                                UnboundType="DateTime" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="TotalDue" ShowInCustomizationForm="True" UnboundType="Decimal"
                                                                VisibleIndex="7">
                                                                <PropertiesTextEdit DisplayFormatString="c">
                                                                </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataButtonEditColumn Caption="ReservationId" FieldName="ReservationId"
                                                                ShowInCustomizationForm="True" UnboundType="Integer" VisibleIndex="6" Visible="false">
                                                            </dx:GridViewDataButtonEditColumn>
                                                            <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                <EditButton Visible="True">
                                                                    <Image Url="~/Images/update.png
">
                                                                    </Image>
                                                                </EditButton>
                                                                <UpdateButton Visible="True">
                                                                    <Image Url="~/Images/Apply.png">
                                                                    </Image>
                                                                </UpdateButton>
                                                                <ClearFilterButton Visible="True">
                                                                </ClearFilterButton>
                                                            </dx:GridViewCommandColumn>
                                                        </Columns>
                                                        <Settings ShowFilterRow="True" />
                                                    </dx:ASPxGridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Name="Dirty Rooms" Text="Dirty Rooms">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <dx:ASPxGridView ID="gvDirtyRooms" runat="server" AutoGenerateColumns="False" Width="100%"
                                            KeyFieldName="RoomId" OnCellEditorInitialize="gvDirtyRooms_CellEditorInitialize"
                                            OnRowUpdating="gvDirtyRooms_RowUpdating">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="RoomName" ReadOnly="True" ShowInCustomizationForm="True"
                                                    VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomNumber" ReadOnly="True" ShowInCustomizationForm="True"
                                                    VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="CleanedBy" ShowInCustomizationForm="True"
                                                    UnboundType="Integer" VisibleIndex="3" Caption="Cleaned By">
                                                    <PropertiesComboBox ValueType="System.Int32">
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" VisibleIndex="0">
                                                    <EditButton Visible="True">
                                                        <Image Url="~/Images/update.png
">
                                                        </Image>
                                                    </EditButton>
                                                    <CancelButton Visible="True">
                                                        <Image Url="~/Images/Close.png
">
                                                        </Image>
                                                    </CancelButton>
                                                    <UpdateButton Visible="True">
                                                        <Image Url="~/Images/Apply.png
">
                                                        </Image>
                                                    </UpdateButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="CleaningNote" ShowInCustomizationForm="True"
                                                    VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn Caption="Dirty" FieldName="IsDirty" ShowInCustomizationForm="True"
                                                    UnboundType="Boolean" VisibleIndex="5">
                                                </dx:GridViewDataCheckColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                    </dx:ASPxPageControl>
                </div>
                <div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

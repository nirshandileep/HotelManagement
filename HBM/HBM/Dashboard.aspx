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
                    <dx:ASPxPageControl ID="pcPageControl" runat="server" ActiveTabIndex="1" 
                        Width="100%" 
                        SaveStateToCookies="True">
                        <TabPages>
                            <dx:TabPage Name="Timeline" Text="Timeline">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <dxwschs:ASPxScheduler ID="schReservationDashboad" runat="server" ActiveViewType="Timeline"
                                            ClientIDMode="AutoID" Start="2013-11-18">
                                            <ResourceColorSchemas>
                                                <cc1:SchedulerColorSchema Cell="255, 244, 188" CellBorder="243, 228, 177" CellBorderDark="234, 208, 152"
                                                    CellLight="255, 255, 213" CellLightBorder="255, 239, 199" CellLightBorderDark="246, 219, 162">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="Control" CellBorder="ControlDark" CellBorderDark="ControlDark"
                                                    CellLight="Window" CellLightBorder="ControlDark" CellLightBorderDark="ControlDark">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="179, 212, 151" CellBorder="168, 203, 138" CellBorderDark="140, 180, 104"
                                                    CellLight="213, 236, 188" CellLightBorder="205, 228, 180" CellLightBorderDark="186, 209, 162">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="139, 158, 191" CellBorder="128, 147, 181" CellBorderDark="97, 116, 152"
                                                    CellLight="207, 216, 230" CellLightBorder="193, 201, 219" CellLightBorderDark="161, 175, 204">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="190, 134, 161" CellBorder="180, 124, 149" CellBorderDark="156, 101, 122"
                                                    CellLight="227, 203, 214" CellLightBorder="218, 189, 199" CellLightBorderDark="197, 163, 171">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="137, 177, 167" CellBorder="123, 168, 156" CellBorderDark="84, 142, 128"
                                                    CellLight="193, 214, 209" CellLightBorder="174, 202, 195" CellLightBorderDark="145, 182, 173">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="247, 180, 127" CellBorder="235, 167, 113" CellBorderDark="202, 131, 71"
                                                    CellLight="250, 208, 174" CellLightBorder="238, 196, 163" CellLightBorderDark="225, 166, 118">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="221, 140, 142" CellBorder="210, 129, 131" CellBorderDark="179, 100, 101"
                                                    CellLight="239, 200, 201" CellLightBorder="233, 187, 189" CellLightBorderDark="222, 164, 166">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="137, 150, 132" CellBorder="129, 138, 122" CellBorderDark="102, 100, 89"
                                                    CellLight="208, 216, 203" CellLightBorder="196, 207, 191" CellLightBorderDark="172, 181, 169">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="0, 199, 200" CellBorder="0, 186, 187" CellBorderDark="0, 151, 153"
                                                    CellLight="168, 236, 236" CellLightBorder="144, 226, 227" CellLightBorderDark="84, 203, 204">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="168, 148, 207" CellBorder="155, 136, 194" CellBorderDark="118, 99, 155"
                                                    CellLight="221, 213, 236" CellLightBorder="210, 199, 230" CellLightBorderDark="185, 169, 216">
                                                </cc1:SchedulerColorSchema>
                                                <cc1:SchedulerColorSchema Cell="204, 204, 204" CellBorder="189, 189, 189" CellBorderDark="121, 121, 121"
                                                    CellLight="230, 230, 230" CellLightBorder="204, 204, 204" CellLightBorderDark="177, 177, 177">
                                                </cc1:SchedulerColorSchema>
                                            </ResourceColorSchemas>
                                            <Views>
                                                <DayView>
                                                    <TimeSlots>
                                                        <cc1:TimeSlot Value="01:00:00" DisplayName="60 Minutes" MenuCaption="6&amp;0 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:30:00" DisplayName="30 Minutes" MenuCaption="&amp;30 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:15:00" DisplayName="15 Minutes" MenuCaption="&amp;15 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:10:00" DisplayName="10 Minutes" MenuCaption="10 &amp;Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:06:00" DisplayName="6 Minutes" MenuCaption="&amp;6 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot DisplayName="5 Minutes" MenuCaption="&amp;5 Minutes"></cc1:TimeSlot>
                                                    </TimeSlots>
                                                    <TimeRulers>
                                                        <cc1:TimeRuler />
                                                    </TimeRulers>
                                                </DayView>
                                                <WorkWeekView>
                                                    <TimeSlots>
                                                        <cc1:TimeSlot Value="01:00:00" DisplayName="60 Minutes" MenuCaption="6&amp;0 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:30:00" DisplayName="30 Minutes" MenuCaption="&amp;30 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:15:00" DisplayName="15 Minutes" MenuCaption="&amp;15 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:10:00" DisplayName="10 Minutes" MenuCaption="10 &amp;Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot Value="00:06:00" DisplayName="6 Minutes" MenuCaption="&amp;6 Minutes">
                                                        </cc1:TimeSlot>
                                                        <cc1:TimeSlot DisplayName="5 Minutes" MenuCaption="&amp;5 Minutes"></cc1:TimeSlot>
                                                    </TimeSlots>
                                                    <TimeRulers>
                                                        <cc1:TimeRuler />
                                                    </TimeRulers>
                                                </WorkWeekView>
                                                <TimelineView>
                                                    <Scales>
                                                        <cc1:TimeScaleYear Enabled="False"></cc1:TimeScaleYear>
                                                        <cc1:TimeScaleQuarter Enabled="False"></cc1:TimeScaleQuarter>
                                                        <cc1:TimeScaleMonth Enabled="False"></cc1:TimeScaleMonth>
                                                        <cc1:TimeScaleWeek></cc1:TimeScaleWeek>
                                                        <cc1:TimeScaleDay></cc1:TimeScaleDay>
                                                        <cc1:TimeScaleHour Enabled="False"></cc1:TimeScaleHour>
                                                        <cc1:TimeScale15Minutes Enabled="False"></cc1:TimeScale15Minutes>
                                                    </Scales>
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
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                From Date:
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpArrivalFromDate" runat="server">
                                                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                                    </ValidationSettings>
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                            <td>
                                                                To Date:
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpArrivalToDate" runat="server">
                                                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                                                    </ValidationSettings>
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                            <td>
                                                                <dx:ASPxButton ID="btnSearchArrivals" runat="server" Text="Search" 
                                                                    AutoPostBack="False" OnClick="btnSearchArrivals_Click">
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
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
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                From Date:
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpDeparturesFrom" runat="server">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                            <td>
                                                                To Date:
                                                            </td>
                                                            <td>
                                                                <dx:ASPxDateEdit ID="dtpDeparturesTo" runat="server">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                              <td>
                                                                <dx:ASPxButton ID="btnSearchDepartures" runat="server" Text="Search">
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr><tr><td> </td></tr>
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
                                                            <dx:GridViewDataTextColumn FieldName="RoomName" ShowInCustomizationForm="True" 
                                                                VisibleIndex="3">
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
                                                            <dx:GridViewDataButtonEditColumn Caption="ReservationId" 
                                                                FieldName="ReservationId" ShowInCustomizationForm="True"
                                                                UnboundType="Integer" VisibleIndex="6" Visible="false">
                                                            </dx:GridViewDataButtonEditColumn>
                                                            <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                                VisibleIndex="0">
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
                                        <dx:ASPxGridView ID="gvDirtyRooms" runat="server" AutoGenerateColumns="False" 
                                            Width="700px" KeyFieldName="RoomId" 
                                            OnCellEditorInitialize="gvDirtyRooms_CellEditorInitialize" 
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
                                                <dx:GridViewDataTextColumn FieldName="CleaningNote" 
                                                    ShowInCustomizationForm="True" VisibleIndex="4">
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

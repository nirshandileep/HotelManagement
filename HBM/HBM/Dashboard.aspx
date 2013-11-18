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
                    <dx:ASPxPageControl ID="pcPageControl" runat="server" ActiveTabIndex="0" 
                        Width="100%">
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
                                        <dx:ASPxGridView ID="gvArrivals" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="CustomerName" ShowInCustomizationForm="True"
                                                    VisibleIndex="1" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReservationCode" ShowInCustomizationForm="True"
                                                    VisibleIndex="2" ReadOnly="True">
                                                    <Settings FilterMode="DisplayText" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Booking.aspx?ReservationId=",Eval("ReservationId")) %>'
                                                            Text='<%# Eval("ReservationCode") %>' />
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomName" ShowInCustomizationForm="True" 
                                                    VisibleIndex="3" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomNumber" ShowInCustomizationForm="True"
                                                    VisibleIndex="4" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckInDate" ShowInCustomizationForm="True"
                                                    UnboundType="DateTime" VisibleIndex="5" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckOutDate" ShowInCustomizationForm="True"
                                                    UnboundType="DateTime" VisibleIndex="6" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn Caption="Actual Check In" 
                                                    FieldName="ActualCheckInDate" ShowInCustomizationForm="True" UnboundType="DateTime" 
                                                    VisibleIndex="7">
                                                    <PropertiesDateEdit DisplayFormatString="">
                                                    </PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewCommandColumn ButtonType="Image" Caption="#" 
                                                    ShowInCustomizationForm="True" VisibleIndex="0">
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
                                            </Columns>
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Name="Departures" Text="Departures">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <dx:ASPxGridView ID="gvDepartures" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="CustomerName" ShowInCustomizationForm="True"
                                                    VisibleIndex="0">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReservationCode" ShowInCustomizationForm="True"
                                                    VisibleIndex="1">
                                                    <Settings FilterMode="DisplayText" />
                                                    <DataItemTemplate>
                                                        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Reservation/Booking.aspx?ReservationId=",Eval("ReservationId")) %>'
                                                            Text='<%# Eval("ReservationCode") %>' />
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomName" ShowInCustomizationForm="True" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomNumber" ShowInCustomizationForm="True"
                                                    VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckOutDate" ShowInCustomizationForm="True"
                                                    UnboundType="DateTime" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TotalDue" ShowInCustomizationForm="True" UnboundType="Decimal"
                                                    VisibleIndex="5">
                                                    <PropertiesTextEdit DisplayFormatString="c">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataButtonEditColumn Caption=" " FieldName="ReservationId" ShowInCustomizationForm="True"
                                                    UnboundType="Integer" VisibleIndex="6" Visible="false">
                                                </dx:GridViewDataButtonEditColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="True" />
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Name="Dirty Rooms" Text="Dirty Rooms">
                                <ContentCollection>
                                    <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                        <dx:ASPxGridView ID="gvDirtyRooms" runat="server" AutoGenerateColumns="False" Width="700px">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="RoomName" ReadOnly="True" ShowInCustomizationForm="True"
                                                    VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RoomNumber" ReadOnly="True" ShowInCustomizationForm="True"
                                                    VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="CleanedBy" ShowInCustomizationForm="True"
                                                    UnboundType="Integer" VisibleIndex="3">
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
                                                <dx:GridViewDataTextColumn FieldName="Note" ShowInCustomizationForm="True" VisibleIndex="4">
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

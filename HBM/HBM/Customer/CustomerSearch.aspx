<%@ Page Title="" Language="C#" MasterPageFile="~/HBMMaster.Master" AutoEventWireup="true"
    CodeBehind="CustomerSearch.aspx.cs" Inherits="HBM.CustomerSearch" %>

<%@ MasterType VirtualPath="~/HBMMaster.Master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-inner">
        <h2>
            Search Customers</h2>
        <table width="900">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" 
                        KeyFieldName="CustomerId" Width="100%">
                        <Columns>                         
                            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Customer Name" 
                                FieldName="CustomerName" Width="250px" UnboundType="String">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                                <DataItemTemplate>
                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Customer/Customers.aspx?CustomerId=",Eval("CustomerId").ToString()) %>'
                                        Text='<%# Eval("CustomerName") %>' />
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MemberCode" VisibleIndex="1" 
                                Width="100px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" UnboundType="String" 
                                VisibleIndex="3" Width="150px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerId" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Guest Type" FieldName="GuestTypeName" UnboundType="String"
                                VisibleIndex="7" Width="150px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" UnboundType="String" VisibleIndex="5">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mobile" FieldName="Mobile" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Company" FieldName="CompanyName" 
                                VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="Control" />
                        <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

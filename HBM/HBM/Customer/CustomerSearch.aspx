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
                        KeyFieldName="CustomerId" Width="100%" 
                        onrowdeleting="gvCustomers_RowDeleting">
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
                            <dx:GridViewDataTextColumn FieldName="MemberCode" VisibleIndex="2" 
                                Width="100px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" UnboundType="String" 
                                VisibleIndex="4" Width="150px">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerId" Visible="False" 
                                VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Guest Type" FieldName="GuestTypeName" UnboundType="String"
                                VisibleIndex="8" Width="150px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" UnboundType="String" 
                                VisibleIndex="6">
                                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" 
                                    SortMode="DisplayText" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mobile" FieldName="Mobile" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Company" FieldName="CompanyName" 
                                VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="Actions" 
                                Width="60px">
                                  <DeleteButton Visible="True">
                                    <Image ToolTip="Delete" Url="~/Images/delete.png">
                                    </Image>
                                </DeleteButton>
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dx:GridViewCommandColumn>
                        </Columns>
                        <SettingsBehavior ColumnResizeMode="Control" ConfirmDelete="True" />
                        <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

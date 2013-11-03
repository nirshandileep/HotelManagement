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
    <div class="wrapper">
        <h2>
            Customer Search List</h2>
        <table width="905">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" KeyFieldName="CustomerId">
                        <Columns>
                            <%-- <dx:GridViewDataHyperLinkColumn Caption="Customer Name" FieldName="CustomerId" UnboundExpression="CustomerId"
                                UnboundType="Integer" VisibleIndex="1">
                                <PropertiesHyperLinkEdit NavigateUrlFormatString='<%# CreateURLQueryString(Eval("CustomerId")) %>'
                                    TextField="CustomerName">
                                </PropertiesHyperLinkEdit>
                            </dx:GridViewDataHyperLinkColumn>--%>
                            <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Customer Name" FieldName="CustomerId">
                                <DataItemTemplate>
                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# HBM.Utility.CommonTools.CreateURLQueryString("~/Customer/Customers.aspx?CustomerId=",Eval("CustomerId")) %>'
                                        Text='<%# Eval("CustomerName") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MemberCode" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" UnboundType="String" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CustomerId" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Guest Type" FieldName="GuestTypeName" UnboundType="String"
                                VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" UnboundType="String" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Settings ShowFilterRow="True" />
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

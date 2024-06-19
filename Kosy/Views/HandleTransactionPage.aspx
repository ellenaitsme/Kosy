<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="Kosy.Views.HandleTransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Handle Transaction</h1>
    <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="false"  OnRowCommand="TransactionGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:ButtonField CommandName="Detail" Text="Detail" ButtonType="Button"></asp:ButtonField>
            <asp:ButtonField CommandName="Accept" Text="Accept" ButtonType="Button"></asp:ButtonField>
             <asp:ButtonField CommandName="Reject" Text="Reject" ButtonType="Button"></asp:ButtonField>
        </Columns>

    </asp:GridView>
</asp:Content>

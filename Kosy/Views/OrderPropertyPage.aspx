<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="OrderPropertyPage.aspx.cs" Inherits="Kosy.Views.OrderPropertyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Property</h1>
    <hr />

    <asp:GridView ID="PropertyGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="PropertyGridView_RowCommand" DataKeyNames="PropertyID">
        <Columns>
            <asp:BoundField DataField="PropertyID" HeaderText="ID" SortExpression="PropertyID" />
            <asp:BoundField DataField="PropertyName" HeaderText="Name" SortExpression="PropertyName" />
            <asp:BoundField DataField="PropertyPrice" HeaderText="Price" SortExpression="PropertyPrice" />
            <asp:BoundField DataField="PropertyArea" HeaderText="Area (m^2)" SortExpression="PropertyArea" />
            <asp:BoundField DataField="PropertyType.PropertyTypeName" HeaderText="Type" SortExpression="PropertyType.PropertyTypeName" />
            <asp:BoundField DataField="PropertyOwner.OwnerName" HeaderText="Owner" SortExpression="PropertyOwner.OwnerName" />
            <asp:TemplateField HeaderText="Input Negotiated Price">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTextBox" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="AddToCartButton" runat="server" CommandName="add_to_cart" CommandArgument='<%# Container.DataItemIndex %>' Text="Nego" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>

    <br />
    <h3>Cart</h3>

    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Property.PropertyName" HeaderText="Property Name" SortExpression="PropertyName" />
            <asp:BoundField DataField="Quantity" HeaderText="Negotiated Price" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" Visible="false" OnClick="CheckoutBtn_Click" />
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" Visible="false" OnClick="ClearCartBtn_Click" />
</asp:Content>

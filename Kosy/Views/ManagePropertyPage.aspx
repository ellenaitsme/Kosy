<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="ManagePropertyPage.aspx.cs" Inherits="Kosy.Views.ManagePropertyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-bottom: 5px;">Properties</h1>
    <h5 style="color: red; margin: 0px; margin-bottom: 5px">Deleting a property will also remove all related property items from shopping carts and transaction details</h5>

    <asp:GridView ID="Property" runat="server" AutoGenerateColumns="False" OnRowEditing="Property_RowEditing" OnRowDeleting="Property_RowDeleting">
        <Columns>
            <asp:BoundField DataField="PropertyID" HeaderText="Property ID" SortExpression="PropertyID" />
            <asp:BoundField DataField="PropertyName" HeaderText="Property Name" SortExpression="PropertyName" />
            <asp:BoundField DataField="PropertyArea" HeaderText="Property Area" SortExpression="PropertyArea" />
            <asp:BoundField DataField="PropertyPrice" HeaderText="Property Price" SortExpression="PropertyPrice" />
            <asp:BoundField DataField="PropertyTypeID" HeaderText="Property Type ID" SortExpression="PropertyTypeID" />
            <asp:BoundField DataField="OwnerID" HeaderText="Owner ID" SortExpression="OwnerID" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <h1 style="margin-bottom: 5px;">Property Types</h1>
    <h5 style="color: red; margin: 0px; margin-bottom: 5px">Deleting a property type will also remove all related property items from the brand, shopping carts, and transaction details</h5>

    <asp:GridView ID="PropertyTypes" runat="server" AutoGenerateColumns="False" OnRowDeleting="PropertyTypes_RowDeleting" OnRowEditing="PropertyTypes_RowEditing">
        <Columns>
            <asp:BoundField DataField="PropertyTypeID" HeaderText="Property Type ID" SortExpression="PropertyTypeID" />
            <asp:BoundField DataField="PropertyTypeName" HeaderText="Property Type Name" SortExpression="PropertyTypeName" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <br />
    <h1 style="margin-bottom: 5px;">Property Owner</h1>
    <h5 style="color: red; margin: 0px; margin-bottom: 5px">Deleting a property brand will also remove all related property items from the brand, shopping carts, and transaction details</h5>

    <asp:GridView ID="PropertyOwners" runat="server" AutoGenerateColumns="False" OnRowEditing="PropertyOwners_RowEditing" OnRowDeleting="PropertyOwners_RowDeleting">
        <Columns>
            <asp:BoundField DataField="OwnerID" HeaderText="Property Owner ID" SortExpression="OwnerID" />
            <asp:BoundField DataField="OwnerName" HeaderText="Property Owner Name" SortExpression="OwnerName" />
            <asp:BoundField DataField="OwnerRating" HeaderText="Property Owner Rating" SortExpression="OwnerRating" />
            <asp:CommandField ButtonType="Button" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>

    <br />

    <asp:Button ID="InsertProperty" runat="server" Text="Insert Property" OnClick="InsertProperty_Click" />
    <asp:Button ID="InsertPropertyType" runat="server" Text="Insert Property Type" OnClick="InsertPropertyType_Click" />
    <asp:Button ID="InsertPropertyOwner" runat="server" Text="Insert Property Owner" OnClick="InsertPropertyOwner_Click" />
</asp:Content>

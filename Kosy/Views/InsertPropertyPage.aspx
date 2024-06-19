<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="InsertPropertyPage.aspx.cs" Inherits="Kosy.Views.InsertPropertyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />

    <div>
        <asp:Label ID="Namelbl" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="Pricelbl" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="Arealbl" runat="server" Text="Area: "></asp:Label>
        <asp:TextBox ID="AreaTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="m^2"></asp:Label>
    </div>

    <div>
        <asp:Label ID="TypeIDlbl" runat="server" Text="Type ID: "></asp:Label>
        <asp:TextBox ID="TypeIDTB" runat="server" TextMode="Number"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="OwnerIDlbl" runat="server" Text="Owner ID: "></asp:Label>
        <asp:TextBox ID="OwnerIDTB" runat="server" TextMode="Number"></asp:TextBox>
    </div>

    <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" />
    <asp:Label ID="Label" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>

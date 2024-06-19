<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Header.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="Kosy.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Transaction Detail</h1>
 <h3>Transaction ID: <%= tran.TransactionID %></h3>
 <table style="width: 700px; text-align: center;" border="1">
     <tr>
         <th>Property</th>
         <th>Property Type</th>
         <th>Property Owner</th>
         <th>Quantity</th>
         <th>Subtotal</th>
     </tr>
     <%foreach (var detail in tran.TransactionDetails)
         { %>
     <tr>
         <td><%= detail.Property.PropertyName %></td>
         <td><%= detail.Property.PropertyType.PropertyTypeName %></td>
         <td><%= detail.Property.PropertyOwner.OwnerName %></td>
         <td><%= detail.Quantity %></td>
         <td><%= detail.Quantity * detail.Property.PropertyPrice %></td>
     </tr>
     <% } %>
     <tr>
         <td colspan="3">Total</td>
         <td><%= tran.TransactionDetails.Sum(detail => detail.Quantity) %></td>
         <td><%= tran.TransactionDetails.Sum(detail => detail.Quantity * detail.Property.PropertyPrice) %></td>
     </tr>
 </table>
</asp:Content>

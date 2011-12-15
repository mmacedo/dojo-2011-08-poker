<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
         Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebApplication.Core.ProductInfo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Products</h2>
    <strong>Order by: </strong> 
      <%= Html.ActionLink("Product name", "List", new { id = 0 })%> |
      <%= Html.ActionLink("Product price", "List", new { id = 1 }) %> |
      <%= Html.ActionLink("Category", "List", new { id = 2 }) %>
    
    <br /><br />

    <table>
      <tr>
        <td><strong>Name</strong></td>
        <td><strong>Category</strong></td>
        <td><strong>Price</strong></td>
      </tr>
      <% foreach (var prod in Model) { %>
      <tr>
        <td><strong><%= Html.ActionLink(prod.Name, "Detail", new { id = prod.ID }) %></strong></td>
        <td><%= prod.Category %></td>
        <td>$<%= prod.Price %></td>
      </tr>
      <% } %>
    </table>

</asp:Content>

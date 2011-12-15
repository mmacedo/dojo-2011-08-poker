<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
         Inherits="System.Web.Mvc.ViewPage<WebApplication.Data.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Categories
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.ProductName %></h2>
    <p><strong>Price</strong>: $<%= Model.UnitPrice %></p>
    <p><strong><%= Model.Category.CategoryName %></strong>: <%= Model.Category.Description %></p>
    <p><strong>Other information</strong>: There are <%= Model.UnitsInStock %> units in stock, and 
      <%= Model.UnitsOnOrder %> units on order. Quantity per unit is: <%= Model.QuantityPerUnit %></p>
    <br />
    <p>This is truly unique product and you should buy it!</p>
</asp:Content>

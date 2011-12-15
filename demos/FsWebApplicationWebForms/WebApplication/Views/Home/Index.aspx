<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome</h2>
    <ul>
    <li><%: ViewData["Message"] %></li>
    <li>The page with <a href="/Products/List">Products</a> contains some more interesting stuff.</li>
    </ul>
</asp:Content>

﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
        This is a sample F# template that demonstrates how to use the following technologies from F#:
    </p>
    <ul>
      <li><strong>LINQ</strong> - we're using F# quotations and the F# LINQ implementation
        available in PowerPack to access data stored in a sample Northwind database.</li>
      <li><strong>ASP.NET MVC</strong> - we're using ASP.NET MVC to implement this web application.
        The main project is in C#, but all the functionality is implemented in an F# library.</li>
    </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Main content of the page should go here</p>
    <p><%: Html.ActionLink("Page", "Index", controllerName: "Page") %></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsAndStyles" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="NavContent" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>

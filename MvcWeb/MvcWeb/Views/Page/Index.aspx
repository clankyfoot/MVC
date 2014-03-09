<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DynamicPages.Models.PageObject>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%: Html.AntiForgeryToken() %>
    </div>
    <div class="success-summary">
        <p></p>
    </div>
    <div class="error-summary">
        <p></p>
    </div>
    <div>
        <fieldset id="createPageForm" hidden="hidden">
            <p>Page Name</p>
            <p><input id="pageName" type="text" value="" required="required" role="textbox" /><span class="field-validation-error">Invalid</span></p>
            <p>Password</p>
            <p><input class="password" type="text" value="" required="required" role="textbox" /><span class="field-validation-error">Invalid</span></p>
            <button class="create">Create</button><button class="cancel">Cancel</button>
        </fieldset>
        <div>
            <button id="createButton">Create Page</button>
        </div>
    </div>
    <div>
        <% foreach(DynamicPages.Models.PageObject view in Model) { %>
            <div>
                <p id="page-<%: view.id %>"><%: view.name %></p>
                <p id="<%: view.id %>"><input type="button" value="Edit" role="button" onclick="edit_click(this)"/><input type="button" value="Delete" role="button" onclick="delete_click(this)" /></p>
            </div>
        <% } %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsAndStyles" runat="server">
    <script src="../../Scripts/WebForms/PageForms.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="NavContent" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>

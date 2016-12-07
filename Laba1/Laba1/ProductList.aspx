<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Laba1.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Styles" runat="server">
    <link type="text/css" href="Content/product-list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CategoryMenu">
        <asp:ListView ID="categoryList"
            ItemType="Laba1.Models.Category"
            runat="server"
            SelectMethod="GetCategories">
            <ItemTemplate>
                <b><%#:Item.CategoryName %></b>
            </ItemTemplate>
            <ItemSeparatorTemplate> | </ItemSeparatorTemplate>
        </asp:ListView>
    </div>
</asp:Content>
<asp:Content ID="pageScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <script src="Scripts/src/product-list/popover.js"></script>
</asp:Content>
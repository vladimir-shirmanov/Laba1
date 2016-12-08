<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Laba1.ProductList" %>
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
                <b title="<%#:Item.Description %>"><a href="ProductList.aspx?id=<%#:Item.CategoryId %>"><%#:Item.CategoryName %></a></b>
            </ItemTemplate>
            <ItemSeparatorTemplate> | </ItemSeparatorTemplate>
        </asp:ListView>
    </div>

    <section>
        <div class="container">
            <hgroup>
                <h2><%:Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="productList" runat="server"
                DataKeyNames="ProductId" GroupItemCount="4"
                ItemType="Laba1.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productId=<%#:Item.ProductId %>">
                                        <img class="product-img" src="Content/Images/Thumbs/<%#:Item.ImagePath %>" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productId=<%#:Item.ProductId %>">
                                        <span><%#:Item.ProductName %></span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:string.Format("{0:c}", Item.Price) %>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%;">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>

<asp:Content ID="pageScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <script src="Scripts/src/product-list/popover.js"></script>
</asp:Content>
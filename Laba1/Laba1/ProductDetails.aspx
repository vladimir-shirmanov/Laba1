<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Laba1.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Styles" runat="server">
    <link rel="stylesheet" href="Content/product-detail.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:FormView ID="productDetail" runat="server" ItemType="Laba1.Models.Product" SelectMethod="GetProduct" RenderOuterTable="false">
            <ItemTemplate>
                <div>
                    <h1><%#:Item.ProductName %></h1>
                </div>
                <br />
                <table>
                    <tr>
                        <td>
                            <img class="bigImage" src="Content/Images/Product/<%#:Item.ImagePath %>" alt="<%#:Item.ProductName %>" />
                        </td>
                        <td>&nbsp;</td>
                        <td class="product-description">
                            <b>Description:</b><br />
                            <%#:Item.Description %>
                            <br />
                            <span><b>Price:</b>&nbsp;<%#:$"{Item.Price:c}" %></span>
                            <br />
                            <span><b>Product Number:</b>&nbsp;<%#:Item.ProductId %></span>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>

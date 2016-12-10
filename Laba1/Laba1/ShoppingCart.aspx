<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Laba1.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Styles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="ShoppingCartTitle" runat="server" class="ContentHead">
            <h1>Shopping Cart</h1>
        </div>
        <asp:GridView runat="server" ID="CartList" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="Laba1.Models.ShoppingItem" SelectMethod="GetShoppingItems"
            CssClass="table table-stripped table-bordered">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Id" SortExpression="ProductId" />
                <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />
                <asp:BoundField DataField="Product.Price" HeaderText="Price (each)" DataFormatString="{0:c}" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="PurchaseQuantity" Width="40" Text="<%#:Item.Quantity %>"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Total">
                    <ItemTemplate>
                        <%#:$"{Item.Quantity*Convert.ToDouble(Item.Product.Price):c}" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove Item">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="Remove" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
            <p></p>
            <strong>
                <asp:Label runat="server" ID="LableTotalText" Text="Oreder Total: "></asp:Label>
                <asp:Label runat="server" ID="lblTotal" EnableViewState="False" />
            </strong>
        </div>
        <table>
            <tr>
                <td>
                    <asp:Button runat="server" ID="UpdateBtn" Text="Update" OnClick="UpdateBtn_OnClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>

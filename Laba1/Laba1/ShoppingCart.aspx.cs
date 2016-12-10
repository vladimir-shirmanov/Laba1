using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using Laba1.BL;
using Laba1.Models;

namespace Laba1
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cart = new ProductCart();
            decimal cartTotal = cart.GetTotal();
            if (cartTotal > 0)
            {
                lblTotal.Text = $"{cartTotal:c}";
            }
            else
            {
                LableTotalText.Text = string.Empty;
                lblTotal.Text = string.Empty;
                ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                UpdateBtn.Visible = false;
            }
        }

        public IEnumerable<ShoppingItem> GetShoppingItems()
        {
            var cart = new ProductCart();
            return cart.GetCartItems();
        }

        protected void UpdateBtn_OnClick(object sender, EventArgs e)
        {
            this.UpdateCartItems();
        }

        private List<ShoppingItem> UpdateCartItems()
        {
            var cart = new ProductCart();

            string cartGuid = cart.GetCartGuid();

            ProductCart.ShoppingCartUpdates[] cartUpdates = new ProductCart.ShoppingCartUpdates[CartList.Rows.Count];
            for (int i = 0; i < CartList.Rows.Count; i++)
            {
                var rowValue = GetValues(CartList.Rows[i]);
                cartUpdates[i].ProductId = int.Parse(rowValue["ProductId"].ToString());

                var cbRemove = (CheckBox) CartList.Rows[i].FindControl("Remove");
                cartUpdates[i].RemoveItem = cbRemove.Checked;

                var quantityTextBox = (TextBox) CartList.Rows[i].FindControl("PurchaseQuantity");
                cartUpdates[i].PurchaseQuantity = int.Parse(quantityTextBox.Text);
            }

            cart.UpdateShoppingCart(cartGuid, cartUpdates);
            CartList.DataBind();
            lblTotal.Text = $"{cart.GetTotal():c}";
            return cart.GetCartItems();
        }

        private IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }

            return values;
        }
    }
}
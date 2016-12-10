using System;
using Laba1.BL;

namespace Laba1
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductId"];
            try
            { 
                int productId = int.Parse(rawId);
                var userShoppingCart = new ProductCart();
                userShoppingCart.AddToCart(productId);
            }
            catch
            {
                throw new Exception("ERROR: It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}
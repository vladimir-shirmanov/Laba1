using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laba1.Models;

namespace Laba1.BL
{
    public class ProductCart
    {
        private ICollection<Category> categories;

        private ICollection<ShoppingItem> cartItems;

        public string CartGuid { get; set; }

        public const string CART_SESSION_KEY = "CartGuid";

        public ProductCart()
        {
            this.categories = UtilityClass.GetData();

            this.cartItems = new List<ShoppingItem>();
        }

        public void AddToCart(int id)
        {
            this.CartGuid = this.GetCartGuid();

            var cartItem = this.cartItems.FirstOrDefault(x => x.CartGUID == CartGuid && x.Product.ProductId == id);

            if (cartItem == null)
            {
                cartItem = new ShoppingItem
                {
                    ItemGUID = Guid.NewGuid().ToString(),
                    Product = categories.First(x => x.Products.FirstOrDefault(p => p.ProductId == id) != null)
                        .Products.First(x => x.ProductId == id),
                    CartGUID = this.CartGuid,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                this.cartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public List<ShoppingItem> GetCartItems()
        {
            this.CartGuid = this.GetCartGuid();

            return this.cartItems.Where(x => x.CartGUID == this.CartGuid).ToList();
        }

        private string GetCartGuid()
        {
            var sessionCartGuid = HttpContext.Current.Session[CART_SESSION_KEY] ?? Guid.NewGuid().ToString();

            return sessionCartGuid.ToString();
        }
    }
}
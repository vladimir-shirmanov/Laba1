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

        public const string CART_APP_KEY = "CartItems";

        public ProductCart()
        {
            this.categories = UtilityClass.GetData();

            this.cartItems = this.GetCart();
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
                    DateCreated = DateTime.Now,
                    ProductId = id
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

        public decimal GetTotal()
        {
            this.CartGuid = this.GetCartGuid();

            decimal? total = (decimal?)this.cartItems.Where(x => x.CartGUID == this.CartGuid).Select(x => x.Quantity*x.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public string GetCartGuid()
        {
            if (HttpContext.Current.Session[CART_SESSION_KEY] == null)
            {
                HttpContext.Current.Session[CART_SESSION_KEY] = Guid.NewGuid().ToString();
                return HttpContext.Current.Session[CART_SESSION_KEY].ToString();
            }

            return HttpContext.Current.Session[CART_SESSION_KEY].ToString();
        }

        private ICollection<ShoppingItem> GetCart()
        {
            if (HttpContext.Current.Application[CART_APP_KEY] == null)
            {
                HttpContext.Current.Application[CART_APP_KEY] = new List<ShoppingItem>();
                return HttpContext.Current.Application[CART_APP_KEY] as List<ShoppingItem>;
            }

            return HttpContext.Current.Application[CART_APP_KEY] as List<ShoppingItem>;
        }

        public void UpdateShoppingCart(string cartGuid, ShoppingCartUpdates[] cartUpdates)
        {
            try
            {
                int cartItemCount = cartUpdates.Length;
                List<ShoppingItem> myCart = GetCartItems();
                foreach (var shoppingItem in myCart)
                {
                    for (int i = 0; i < cartItemCount; i++)
                    {
                        if (shoppingItem.Product.ProductId == cartUpdates[i].ProductId)
                        {
                            if (cartUpdates[i].PurchaseQuantity < 1 || cartUpdates[i].RemoveItem)
                            {
                                RemoveItem(cartGuid, shoppingItem.ProductId);
                            }
                            else
                            {
                                UpdateItem(cartGuid, shoppingItem.ProductId, cartUpdates[i].PurchaseQuantity);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("ERROR: Unable to Update Cart");
            }
        }

        public int GetCount()
        {
            this.CartGuid = this.GetCartGuid();

            int? count = this.cartItems.Where(x => x.CartGUID == this.CartGuid).Sum(x => x.Quantity);
            return (int) count;
        }

        private void UpdateItem(string cartGuid, int productId, int purchaseQuantity)
        {
            var myItem = this.cartItems.FirstOrDefault(
                    x => x.CartGUID == cartGuid && x.Product.ProductId == productId);
            if (myItem != null)
            {
                myItem.Quantity = purchaseQuantity;
            }
        }

        private void RemoveItem(string cartGuid, int shoppingItemProductId)
        {
            var myItem =
                this.cartItems.FirstOrDefault(
                    x => x.CartGUID == cartGuid && x.Product.ProductId == shoppingItemProductId);
            if (myItem != null)
            {
                this.cartItems.Remove(myItem);
            }
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}
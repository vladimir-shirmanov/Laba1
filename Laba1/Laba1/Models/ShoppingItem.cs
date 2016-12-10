using System;

namespace Laba1.Models
{
    public class ShoppingItem
    {
        public string ItemGUID { get; set; }

        public string CartGUID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
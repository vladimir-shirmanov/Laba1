using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using Laba1.Models;

namespace Laba1
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public ICollection<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Gym", Description = "Gym equipment" },
                new Category { CategoryId = 2, CategoryName = "Fitness", Description = "Fitness equipment for personal training" },
                new Category { CategoryId = 3, CategoryName = "Team games", Description = "Football, Volleyball, Basketball and others" },
                new Category { CategoryId = 4, CategoryName = "Fighting", Description = "All sorts of equipment for any figting kind of sport" }
            };
        }

        public ICollection<Product> GetProducts([QueryString("id")] int? categoryId)
        {
        }
    }
}
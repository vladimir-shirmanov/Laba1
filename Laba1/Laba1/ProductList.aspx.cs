using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using Laba1.Models;
using System.Linq;

namespace Laba1
{
    public partial class ProductList : System.Web.UI.Page
    {
        private List<Category> categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            var product = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                product.Add(new Product { ProductName = $"Name{i}", ProductId = i, Price = i*10, ImagePath = "gym.png" });
            }

            this.categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Gym",
                    Description = "Gym equipment",
                    Products = product
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Fitness",
                    Description = "Fitness equipment for personal training",
                    Products = product.Select(x => new Product { ProductName = x.ProductName + "a", ProductId = x.ProductId * 10, ImagePath = "fitness.jpeg" , Price = x.Price}).ToList()
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Team games",
                    Description = "Football, Volleyball, Basketball and others",
                    Products = product.Select(x => new Product { ProductName = x.ProductName + "b", ProductId = x.ProductId * 100, ImagePath = "teamgames.png", Price = x.Price }).ToList()
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Fighting",
                    Description = "All sorts of equipment for any figting kind of sport",
                    Products = product.Select(x => new Product { ProductName = x.ProductName + "c", ProductId = x.ProductId * 1000, ImagePath = "fighting.png", Price = x.Price }).ToList()
                }
            };
        }

        public ICollection<Category> GetCategories()
        {
            return this.categories;
        }

        public ICollection<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var products = this.categories.First(x => x.CategoryId == categoryId).Products;
            return products;
        }
    }
}
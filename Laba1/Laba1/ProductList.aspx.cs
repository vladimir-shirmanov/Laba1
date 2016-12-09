using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using Laba1.Models;
using System.Linq;
using Laba1.BL;

namespace Laba1
{
    public partial class ProductList : System.Web.UI.Page
    {
        private ICollection<Category> categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.categories = UtilityClass.GetData();
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
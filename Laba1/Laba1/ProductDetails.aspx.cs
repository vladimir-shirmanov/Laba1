using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using Laba1.BL;
using Laba1.Models;

namespace Laba1
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private ICollection<Category> categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.categories = UtilityClass.GetData();
        }

        public Product GetProduct([QueryString("productId")] int? productId)
        {
            return categories.First(x => x.Products.FirstOrDefault(p => p.ProductId == productId) != null)
                .Products.First(x => x.ProductId == productId);
        }
    }
}
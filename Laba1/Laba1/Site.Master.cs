using System;
using System.Web.UI;
using Laba1.BL;

namespace Laba1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var cart = new ProductCart();
            cartCount.InnerText = $"Cart ({cart.GetCount()})";
        }
    }
}
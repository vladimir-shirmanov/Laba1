namespace Laba1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public double? Price { get; set; }

        public Category Category { get; set; }
    }
}
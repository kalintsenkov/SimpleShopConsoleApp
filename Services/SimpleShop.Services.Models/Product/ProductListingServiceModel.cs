namespace SimpleShop.Services.Models.Product
{
    public class ProductListingServiceModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public decimal MinimalPrice { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}

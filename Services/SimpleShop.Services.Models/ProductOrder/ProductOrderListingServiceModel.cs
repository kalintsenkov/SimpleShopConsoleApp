namespace SimpleShop.Services.Models.ProductOrder
{
    public class ProductOrderListingServiceModel
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}

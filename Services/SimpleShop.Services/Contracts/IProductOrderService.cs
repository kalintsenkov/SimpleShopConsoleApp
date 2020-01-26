namespace SimpleShop.Services.Contracts
{
    using System.Collections.Generic;
    using Models.ProductOrder;

    public interface IProductOrderService
    {
        decimal Create(int productId, int userId, int quantity, decimal productPrice);

        IEnumerable<ProductOrderListingServiceModel> LastPurchases(int userId);
    }
}
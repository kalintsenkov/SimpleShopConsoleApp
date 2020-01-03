﻿namespace SimpleShop.Services.Contracts
{
    using System.Collections.Generic;
    using Models.ProductOrder;

    public interface IProductOrderService
    {
        void Create(int productId, int userId, int quantity);

        IEnumerable<ProductOrderListingServiceModel> LastPurchases(int userId);
    }
}
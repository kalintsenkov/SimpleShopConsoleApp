namespace SimpleShop.Services
{
    using System;
    using Contracts;
    using Data;
    using Data.Models;

    public class ProductOrderService : IProductOrderService
    {
        private readonly ShopDbContext data;
        private readonly IUserService userService;
        private readonly IProductService productService;

        public ProductOrderService(
            ShopDbContext data,
            IUserService userService,
            IProductService productService)
        {
            this.data = data;
            this.userService = userService;
            this.productService = productService;
        }

        public void Create(int productId, int userId, int quantity)
        {
            var product = this.productService.FindById(productId);

            var order = new Order
            {
                Date = DateTime.Now,
                UserId = userId
            };

            var productOrder = new ProductOrder
            {
                Order = order,
                ProductId = productId,
                Quantity = quantity
            };

            var totalProductsPrice = product.Price * quantity;

            this.productService.ReduceQuantity(productId, quantity);
            this.userService.ReduceMoney(userId, totalProductsPrice);

            this.data.Orders.Add(order);
            this.data.ProductsOrders.Add(productOrder);

            this.data.SaveChanges();
        }
    }
}
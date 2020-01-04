namespace SimpleShop.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.ProductOrder;

    public class ProductOrderService : IProductOrderService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public ProductOrderService(
            ShopDbContext data, 
            IMapper mapper, 
            IUserService userService, 
            IOrderService orderService, 
            IProductService productService)
        {
            this.data = data;
            this.mapper = mapper;
            this.userService = userService;
            this.orderService = orderService;
            this.productService = productService;
        }

        public void Create(int productId, int userId, int quantity)
        {
            var product = this.productService.FindById(productId);

            var order = this.orderService.Create(userId);

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

        public IEnumerable<ProductOrderListingServiceModel> LastPurchases(int userId)
            => this.data.ProductsOrders
                .Where(po => po.Order.UserId == userId)
                .OrderByDescending(po => po.Order.Date.Year)
                .ThenByDescending(po => po.Order.Date.Month)
                .ThenByDescending(po => po.Order.Date.Day)
                .ProjectTo<ProductOrderListingServiceModel>(this.mapper.ConfigurationProvider)
                .Take(10);
    }
}
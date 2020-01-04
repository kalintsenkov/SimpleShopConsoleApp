namespace SimpleShop.Services
{
    using System;
    using Contracts;
    using Data.Models;

    public class OrderService : IOrderService
    {
        public Order Create(int userId)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                UserId = userId
            };

            return order;
        }
    }
}

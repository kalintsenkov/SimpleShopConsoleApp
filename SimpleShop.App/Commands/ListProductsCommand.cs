﻿namespace SimpleShop.App.Commands
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using Services.Contracts;

    public class ListProductsCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;
        private readonly IProductService productService;

        public ListProductsCommand(
            IUserSessionService userSessionService,
            IProductService productService)
        {
            this.userSessionService = userSessionService;
            this.productService = productService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var allProducts = this.productService
                .GetAllAvailableProducts()
                .GroupBy(p => p.Category)
                .ToList();

            if (!allProducts.Any())
            {
                return "Sorry, we don't have any products at the moment.";
            }

            var sb = new StringBuilder();

            foreach (var group in allProducts)
            {
                sb.AppendLine($"--Category: {group.Key}");

                foreach (var product in group)
                {
                    sb.AppendLine($"   Name: {product.Name}");
                    sb.AppendLine($"   Price: {product.Price:F2}$");
                    sb.AppendLine($"   Quantity: {product.Quantity}");
                    sb.AppendLine($"   Description: {(string.IsNullOrWhiteSpace(product.Description) ? "No Description" : product.Description)}");
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

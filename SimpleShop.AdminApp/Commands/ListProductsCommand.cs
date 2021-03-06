﻿namespace SimpleShop.AdminApp.Commands
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using Services.Contracts;

    public class ListProductsCommand : ICommand
    {
        private readonly IAdminSessionService adminSessionService;
        private readonly IProductService productService;

        public ListProductsCommand(
            IAdminSessionService adminSessionService,
            IProductService productService)
        {
            this.adminSessionService = adminSessionService;
            this.productService = productService;
        }

        public string Execute()
        {
            if (!this.adminSessionService.IsLoggedIn())
            {
                return "Please login with admin account";
            }

            var allProducts = this.productService
                .GetAllAvailableProducts()
                .GroupBy(p => p.Category)
                .ToList();

            if (!allProducts.Any())
            {
                return "We don't have any products at the moment! Please add some.";
            }

            var sb = new StringBuilder();

            foreach (var group in allProducts)
            {
                sb.AppendLine($"--Category: {group.Key}");

                foreach (var product in group)
                {
                    sb.AppendLine($"   Name: {product.Name}");
                    sb.AppendLine($"   Price: {product.Price:F2}$");
                    sb.AppendLine($"   Minimal Price: {product.MinimalPrice:F2}$");
                    sb.AppendLine($"   Quantity: {product.Quantity}");
                    sb.AppendLine($"   Description: {(string.IsNullOrWhiteSpace(product.Description) ? "No Description" : product.Description)}");
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

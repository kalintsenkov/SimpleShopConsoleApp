namespace SimpleShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Product;
    using Utilities;

    public class ProductService : IProductService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public ProductService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public ProductServiceModel FindById(int productId)
            => this.data.Products
                .Where(p => p.Id == productId)
                .ProjectTo<ProductServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public ProductServiceModel FindByName(string productName)
            => this.data.Products
                .Where(p => p.Name == productName)
                .ProjectTo<ProductServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public ProductServiceModel Create(string name, int quantity, decimal price, decimal minimalPrice, int categoryId, string description)
        {
            Validator.ValidateProduct(name, quantity, price, minimalPrice);

            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                Price = price,
                MinimalPrice = minimalPrice,
                Description = !string.IsNullOrWhiteSpace(description) ? description : null,
                IsOnBlackFriday = false,
                CategoryId = categoryId
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            var productServiceModel = this.mapper.Map<ProductServiceModel>(product);

            return productServiceModel;
        }

        public void EditActualPrice(int productId, decimal newPrice)
        {
            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            if (newPrice <= 0)
            {
                throw new InvalidOperationException(ProductExceptionMessages.InvalidPrice);
            }

            product.Price = newPrice;

            this.data.SaveChanges();
        }

        public void EditMinimalPrice(int productId, decimal newMinimalPrice)
        {
            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            if (newMinimalPrice <= 0)
            {
                throw new InvalidOperationException(ProductExceptionMessages.InvalidMinimalPrice);
            }

            product.MinimalPrice = newMinimalPrice;

            this.data.SaveChanges();
        }

        public void ReduceQuantity(int productId, int quantity)
        {
            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            if (quantity <= 0)
            {
                throw new ArgumentException(ProductExceptionMessages.InvalidQuantity);
            }

            if (product.Quantity - quantity < 0)
            {
                throw new ArgumentException(
                    string.Format(
                        ProductExceptionMessages.NotEnoughPieces,
                        quantity,
                        product.Name));
            }

            product.Quantity -= quantity;
        }

        public void IncreaseQuantity(int productId, int quantity)
        {
            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            if (quantity <= 0)
            {
                throw new ArgumentException(ProductExceptionMessages.InvalidQuantity);
            }

            product.Quantity += quantity;

            this.data.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            this.data.Products.Remove(product);
            this.data.SaveChanges();
        }

        public void StartBlackFriday(int categoryId, decimal discountPercentage)
        {
            var products = this.data.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException(ProductExceptionMessages.InvalidDiscountPercentage);
            }

            foreach (var product in products)
            {
                var productNewPrice = product.Price - (product.Price * (discountPercentage / 100));

                product.IsOnBlackFriday = true;

                if (productNewPrice < product.MinimalPrice)
                {
                    continue;
                }

                this.EditActualPrice(product.Id, productNewPrice);
            }

            this.data.SaveChanges();
        }

        public void StopBlackFriday()
        {
            var products = this.data.Products
                .Where(p => p.IsOnBlackFriday)
                .ToList();

            foreach (var product in products)
            {
                product.IsOnBlackFriday = false;
            }

            this.data.SaveChanges();
        }

        public IEnumerable<ProductListingServiceModel> GetAllAvailableProducts()
            => this.data.Products
                .Where(p => p.Quantity > 0)
                .ProjectTo<ProductListingServiceModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Name)
                .ThenByDescending(p => p.Price)
                .ThenByDescending(p => p.Quantity);

        public IEnumerable<ProductListingServiceModel> GetAllBlackFridayProducts()
            => this.data.Products
                .Where(p => p.IsOnBlackFriday)
                .ProjectTo<ProductListingServiceModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Name)
                .ThenByDescending(p => p.Price)
                .ThenByDescending(p => p.Quantity);
    }
}

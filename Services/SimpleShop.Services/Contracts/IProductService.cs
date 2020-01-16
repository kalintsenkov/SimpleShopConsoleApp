namespace SimpleShop.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Product;

    public interface IProductService
    {
        ProductServiceModel FindById(int productId);

        ProductServiceModel FindByName(string productName);

        ProductServiceModel Create(string name, int quantity, decimal price, decimal minimalPrice, int categoryId, string description);

        void EditActualPrice(int productId, decimal newPrice);

        void EditMinimalPrice(int productId, decimal newMinimalPrice);

        void ReduceQuantity(int productId, int quantity);

        void IncreaseQuantity(int productId, int quantity);

        void Delete(int productId);

        bool Exists(string productName);

        void StartBlackFriday(int categoryId, decimal discountPercentage);

        void StopBlackFriday();

        IEnumerable<ProductListingServiceModel> GetAllAvailableProducts();

        IEnumerable<ProductListingServiceModel> GetAllBlackFridayProducts();
    }
}

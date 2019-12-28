namespace SimpleShop.Services.Contracts
{
    public interface IProductOrderService
    {
        void Create(int productId, int userId, int quantity);
    }
}
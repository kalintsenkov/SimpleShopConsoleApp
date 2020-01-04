namespace SimpleShop.Services.Contracts
{
    using Data.Models;

    public interface IOrderService
    {
        Order Create(int userId);
    }
}

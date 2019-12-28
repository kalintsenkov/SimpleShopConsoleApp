namespace SimpleShop.Services.Contracts
{
    using Models.User;

    public interface IUserService
    {
        UserServiceModel FindByUsername(string username);

        UserServiceModel FindByEmail(string email);

        UserServiceModel FindByUsernameAndPassword(string username, string password);

        void Create(string firstName, string lastName, string username, string password, string email, decimal balance);

        void AddMoney(int userId, decimal money);

        void ReduceMoney(int userId, decimal money);
    }
}

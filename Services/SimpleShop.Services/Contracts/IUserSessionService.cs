namespace SimpleShop.Services.Contracts
{
    using Models.User;

    public interface IUserSessionService
    {
        UserServiceModel User { get; }

        UserServiceModel Login(string username, string password);

        void Logout();

        bool IsLoggedIn();
    }
}

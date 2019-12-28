namespace SimpleShop.Services.Contracts
{
    using Models.Admin;

    public interface IAdminSessionService
    {
        AdminServiceModel Admin { get; }

        AdminServiceModel Login(string username, string password);

        void Logout();

        bool IsLoggedIn();
    }
}

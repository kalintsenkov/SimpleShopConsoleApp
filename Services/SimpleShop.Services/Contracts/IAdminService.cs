namespace SimpleShop.Services.Contracts
{
    using Models.Admin;

    public interface IAdminService
    {
        AdminServiceModel FindByUsernameAndPassword(string username, string password);

        void Create(string username, string password, string name);

        bool Exists(string username);
    }
}

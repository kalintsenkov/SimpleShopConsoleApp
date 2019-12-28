namespace SimpleShop.Services.Contracts
{
    using Models.Category;

    public interface ICategoryService
    {
        CategoryServiceModel FindByName(string categoryName);

        CategoryServiceModel Create(string name);
    }
}
namespace SimpleShop.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Category;
    using Utilities;

    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public CategoryService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public CategoryServiceModel FindByName(string categoryName)
            => this.data.Categories
                .Where(c => c.Name == categoryName)
                .ProjectTo<CategoryServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public CategoryServiceModel Create(string name)
        {
            Validator.ValidateCategory(name);

            var category = new Category
            {
                Name = name
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();

            var categoryServiceModel = this.mapper.Map<CategoryServiceModel>(category);

            return categoryServiceModel;
        }
    }
}
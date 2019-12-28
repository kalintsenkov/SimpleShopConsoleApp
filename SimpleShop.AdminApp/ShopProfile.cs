namespace SimpleShop.AdminApp
{
    using AutoMapper;
    using Data.Models;
    using Services.Models.Admin;
    using Services.Models.Category;
    using Services.Models.Product;

    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Admin, AdminServiceModel>();

            CreateMap<Category, CategoryServiceModel>();

            CreateMap<Product, ProductServiceModel>();
            CreateMap<Product, ProductListingServiceModel>()
                .ForMember(dest => dest.Category, y => y.MapFrom(src => src.Category.Name));
        }
    }
}

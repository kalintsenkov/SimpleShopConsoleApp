﻿namespace SimpleShop.App
{
    using AutoMapper;
    using Data.Models;
    using Services.Models.Product;
    using Services.Models.ProductOrder;
    using Services.Models.User;

    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<User, UserServiceModel>();

            CreateMap<Product, ProductServiceModel>();
            CreateMap<Product, ProductListingServiceModel>()
                .ForMember(dest => dest.Category, y => y.MapFrom(src => src.Category.Name));

            CreateMap<ProductOrder, ProductOrderListingServiceModel>();
        }
    }
}

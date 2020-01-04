namespace SimpleShop.App
{
    using System;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Commands;
    using Commands.Contracts;
    using Core;
    using Core.Contracts;
    using Data;
    using IO;
    using IO.Contracts;
    using Services;
    using Services.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            serviceProvider.GetService<IEngine>().Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ShopDbContext>(
                options => options.UseSqlServer(DataSettings.ConnectionString));

            serviceCollection.AddAutoMapper(typeof(ShopProfile));

            // Console app entry point
            serviceCollection.AddTransient<IEngine, Engine>();

            serviceCollection.AddTransient<IConsoleReader, ConsoleReader>();
            serviceCollection.AddTransient<IConsoleWriter, ConsoleWriter>();
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IProductOrderService, ProductOrderService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IUserService, UserService>();

            serviceCollection.AddSingleton<IUserSessionService, UserSessionService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}

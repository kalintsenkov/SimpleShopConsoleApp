namespace SimpleShop.AdminApp
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

            // App entry point
            serviceCollection.AddTransient<IEngine, Engine>();

            serviceCollection.AddTransient<IConsoleReader, ConsoleReader>();
            serviceCollection.AddTransient<IConsoleWriter, ConsoleWriter>();
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IProductOrderService, ProductOrderService>();
            serviceCollection.AddTransient<IProductService, ProductService>();

            serviceCollection.AddSingleton<IAdminSessionService, AdminSessionService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

        private static void ResetDatabase(DbContext data)
        {
            data.Database.EnsureDeleted();
            data.Database.Migrate();
        }
    }
}

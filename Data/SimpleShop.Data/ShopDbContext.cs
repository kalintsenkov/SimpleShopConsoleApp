namespace SimpleShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
        }

        public ShopDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrder> ProductsOrders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}

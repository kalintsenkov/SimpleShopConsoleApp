namespace SimpleShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> admin)
        {
            admin
                .HasIndex(a => a.Username)
                .IsUnique(true);
        }
    }
}

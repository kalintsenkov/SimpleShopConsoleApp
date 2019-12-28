namespace SimpleShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> productOrder)
        {
            productOrder
                .HasKey(po => new { po.ProductId, po.OrderId });

            productOrder
                .HasOne(po => po.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(po => po.ProductId);

            productOrder
                .HasOne(po => po.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(po => po.OrderId);
        }
    }
}

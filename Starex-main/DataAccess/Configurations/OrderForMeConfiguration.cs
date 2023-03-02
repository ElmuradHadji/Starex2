using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class OrderForMeConfiguration : IEntityTypeConfiguration<OrderForMe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderForMe> builder)
        {
            builder.Property(p => p.InternalCargoPrice).HasDefaultValue(0);
            builder.Property(p => p.IsPaid).HasDefaultValue(false);
            builder.Property(p => p.OrderStatusId).HasDefaultValue(1);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.ProductCount).HasDefaultValue(1);
            builder.Property(p => p.ProductColor).HasDefaultValue("");
            builder.Property(p => p.ProductSize).HasDefaultValue("");
            builder.Property(p => p.ProductUrl).IsRequired();


        }
    }

}

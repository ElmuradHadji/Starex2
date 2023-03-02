using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderStatus> builder)
        {
            builder.Property(p => p.Value).IsRequired();

        }
    }

}

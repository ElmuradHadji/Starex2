using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class DeliveryPointConfiguration : IEntityTypeConfiguration<DeliveryPoint>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryPoint> builder)
        {
            builder.Property(p => p.Adress).IsRequired();
            builder.Property(p => p.City).IsRequired();
            //builder.Property(p => p.CountryId).IsRequired();
            //builder.Property(p => p.BranchId).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PackageCapasity).IsRequired();

        }
    }

}

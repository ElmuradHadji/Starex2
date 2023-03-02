using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class WareHouseConfiguration : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WareHouse> builder)
        {
            builder.Property(p => p.ZIP).IsRequired();
            builder.Property(p => p.Province).IsRequired();
            builder.Property(p => p.PackageCapasity).IsRequired();
            builder.Property(p => p.District).IsRequired();
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.AdressTitle).IsRequired();
            builder.Property(p => p.Adress1).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(false);

        }
    }

}

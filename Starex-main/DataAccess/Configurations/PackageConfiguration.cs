using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.Property(p=>p.Cost).IsRequired();
            builder.Property(p=>p.CostCurrencyId).IsRequired();
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=>p.packageStatusId).HasDefaultValue(2);
            builder.HasIndex(p=>p.InternalTrackingId).IsUnique();

        }
    }
}

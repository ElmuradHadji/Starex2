using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.Property(p => p.MinKG).IsRequired();
            builder.Property(p => p.MaxKG).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.CurrencyId).IsRequired();
        }
    }
}

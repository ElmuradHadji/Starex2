using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
        {
            builder.Property(p => p.CurrencyId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Flag).IsRequired();
        }
    }

}

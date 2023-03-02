using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Currency> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ShortName).IsRequired();
            builder.Property(p => p.Icon).IsRequired();

        }
    }

}

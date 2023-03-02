using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Advantage> builder)
        {
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.Title).IsRequired();

        }
    }

}

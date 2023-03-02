using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Service> builder)
        {
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);

        }
    }

}

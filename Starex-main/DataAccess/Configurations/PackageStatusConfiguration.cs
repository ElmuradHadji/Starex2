using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class PackageStatusConfiguration : IEntityTypeConfiguration<PackageStatus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PackageStatus> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }

}

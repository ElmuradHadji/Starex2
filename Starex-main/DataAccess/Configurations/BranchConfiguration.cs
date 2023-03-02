using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Branch> builder)
        {
            builder.Property(p => p.Adress).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PackageCapasity).IsRequired();
        }
    }

}

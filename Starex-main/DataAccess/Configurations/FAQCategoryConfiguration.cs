using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class FAQCategoryConfiguration : IEntityTypeConfiguration<FAQCategory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FAQCategory> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }

}

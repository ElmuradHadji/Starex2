using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FAQ> builder)
        {
            builder.Property(p => p.Question).IsRequired();
            builder.Property(p => p.Answer).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.IsMain).HasDefaultValue(false);


        }
    }

}

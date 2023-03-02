using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<About> builder)
        {
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Text).IsRequired();
        }
    }

}

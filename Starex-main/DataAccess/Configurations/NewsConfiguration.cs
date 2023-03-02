using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<News> builder)
        {
            builder.Property(p => p.CreatedTime).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.UpdatedTime).HasDefaultValue(DateTime.Now);

        }
    }

}

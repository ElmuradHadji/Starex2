using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Configurations
{
    public class SocialConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Social> builder)
        {
            builder.Property(p=>p.Url).IsRequired();
            builder.Property(p=>p.SettingId).IsRequired();
            builder.Property(p=>p.Icon).IsRequired();
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=>p.IsActive).HasDefaultValue(true);
        }
    }
 }


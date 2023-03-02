using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Setting> builder)
        {
            builder.Property(p=>p.Adress).IsRequired();
            builder.Property(p=>p.Logo).IsRequired();
            builder.Property(p=>p.Phone).IsRequired();
        }
    }
 }


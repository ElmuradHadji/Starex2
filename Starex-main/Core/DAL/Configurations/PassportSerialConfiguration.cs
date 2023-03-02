using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Configurations
{
    public class PassportSerialConfiguration : IEntityTypeConfiguration<PassportSerial>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PassportSerial> builder)
        {
            builder.Property(p => p.Value).IsRequired(); 
        }
    }

}

using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Number).IsRequired();

        }
    }

}

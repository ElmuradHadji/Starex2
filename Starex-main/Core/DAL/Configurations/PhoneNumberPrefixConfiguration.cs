using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Configurations
{
    public class PhoneNumberPrefixConfiguration : IEntityTypeConfiguration<PhoneNumberPrefix>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PhoneNumberPrefix> builder)
        {
            builder.Property(p=>p.Value).IsRequired();
        }
    }
 }


using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Gender> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }

}

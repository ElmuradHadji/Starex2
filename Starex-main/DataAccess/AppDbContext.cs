using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Gender)));
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<PassportSerial> PassportSerials { get; set; }
        public DbSet<PhoneNumberPrefix> Prefixes { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<FAQCategory> FAQCategories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<OrderForMe> OrderFors { get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Pricing> Prices { get; set; }
        //public DbSet<Setting> Setting { get; set; }
        //public DbSet<Social> Socials { get; set; }
    }
}

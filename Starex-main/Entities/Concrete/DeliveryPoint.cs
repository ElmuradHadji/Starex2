using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class DeliveryPoint : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public Country country { get; set; }
        public bool IsActive { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int PackageCapasity { get; set; }
        public string? WeekDayWorkingHours { get; set; }
        public string? WeekEndWorkingHours { get; set; }
        public string? SpecialWorkingHours { get; set; }
        public int? BranchId { get; set; }
        public Branch branch { get; set; }
        public List<AppUser> Users { get; set; }
        //public List<Employee> employees { get; set; }
        public List<Package> packages { get; set; }
    }
}

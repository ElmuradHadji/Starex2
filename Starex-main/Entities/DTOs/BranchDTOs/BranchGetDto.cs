using Core.Entities.Concrete;
using Entities.Concrete;

namespace Entities.DTOs.BranchDTOs
{
    public class BranchGetDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int PackageCapasity { get; set; }
        public string WeekDayWorkingHours { get; set; }
        public string WeekEndWorkingHours { get; set; }
        public string SpecialWorkingHours { get; set; }

    }
}

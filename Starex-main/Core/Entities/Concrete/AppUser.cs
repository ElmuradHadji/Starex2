using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class AppUser:IdentityUser,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public DateTime Brithday { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int BranchOrPointId { get; set; }
        public int PassportSerialId { get; set; }
        public string PassportSerialNumber { get; set; }
        public string FIN { get; set; }
        public int? WareHouseId { get; set; }
        public int? BranchId { get; set; }

    }
}

using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class WareHouse : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country country { get; set; }
        public bool IsActive { get; set; }
        public string AdressTitle { get; set; }
        public string Adress1 { get; set;}
        public string Province { get; set;}
        public string ZIP { get; set;}
        public string City { get; set;}
        public string District { get; set; }
        public int PackageCapasity { get; set; }

       public List<AppUser> employees { get; set; }
       public List<Package> packages { get; set; }

    }
}

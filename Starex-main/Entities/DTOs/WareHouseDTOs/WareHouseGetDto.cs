
namespace Entities.DTOs.WareHouseDTOs
{
    public class WareHouseGetDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
        public string AdressTitle { get; set; }
        public string Adress1 { get; set; }
        public string Province { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int PackageCapasity { get; set; }
    }
}

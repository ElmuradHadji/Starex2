using Entities.Concrete;

namespace Entities.DTOs.PackageDTOs
{
    public class PackagePostDto
    {

        public string Name { get; set; }
        public double Cost { get; set; }
        public int CostCurrencyId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? PriceCurrencyId { get; set; }
        public string? OriginalTrackingId { get; set; }
        public  int? InternalTrackingId { get; set; } 

        public int packageStatusId { get; set; } = 2;
        public int? wareHouseId { get; set; }
        public int? branchId { get; set; }
        public bool IsDeleted { get; set; }
      
    }
    }

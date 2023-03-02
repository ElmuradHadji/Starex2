using Core.Entities;

namespace Entities.Concrete
{
    public class Package : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Cost { get; set; }
        public int CostCurrencyId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? PriceCurrencyId { get; set; }
        public string? OriginalTrackingId { get; set; }
      
        public   int? InternalTrackingId { get; set; }

        public PackageStatus packageStatus { get; set; }
        public int packageStatusId { get; set; }
        public int? wareHouseId { get; set; }
        public int? branchId { get; set; }
        public bool IsDeleted { get; set; }
          
    }
}

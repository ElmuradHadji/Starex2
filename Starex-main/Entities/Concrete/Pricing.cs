using Core.Entities;

namespace Entities.Concrete
{
    public class Pricing:IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public double MinKG { get; set; }
        public double MaxKG { get; set; }
        public double Price { get; set; }
    }
}

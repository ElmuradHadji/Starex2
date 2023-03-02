using Core.Entities;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public int CurrencyId { get; set; }
        public Currency currency { get; set; }
        public List<WareHouse> wareHouses { get; set; }
    }
}

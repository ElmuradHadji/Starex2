using Core.Entities;

namespace Entities.Concrete
{
    public class OrderStatus : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<OrderForMe> Orders { get; set; }
    }
}

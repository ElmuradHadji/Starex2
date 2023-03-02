using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class OrderForMe : IEntity
    {
        public int Id { get; set; }
        public int OrderStatusId { get; set; }
        public bool IsPaid { get; set; }
        public string ProductUrl { get; set; }
        public int ProductCount { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public double InternalCargoPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }


    }
}

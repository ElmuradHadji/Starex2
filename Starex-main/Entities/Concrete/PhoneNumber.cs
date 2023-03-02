using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class PhoneNumber : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}

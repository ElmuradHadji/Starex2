using Core.Entities;

namespace Entities.Concrete
{
    public class FAQCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FAQ> FAQs { get; set; }
        public bool IsActive { get; set; }
    }
}

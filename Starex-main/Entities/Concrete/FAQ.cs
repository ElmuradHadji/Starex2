using Core.Entities;

namespace Entities.Concrete
{
    public class FAQ : IEntity
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public int CategoryId { get; set; }
        public FAQCategory category { get; set; }

    }
}

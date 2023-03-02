using Entities.Concrete;

namespace Entities.DTOs.FAQCategoryDTOs
{
    public class FAQCategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

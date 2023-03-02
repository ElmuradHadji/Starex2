namespace Entities.DTOs.FAQDTOs
{
    public class FAQPostDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public int CategoryId { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AdvantageDTOs
{
    public class AdvantagePostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile formFile { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}

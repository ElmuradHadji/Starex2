using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.AboutDTOs
{
    public class AboutPostDto
    {
        public IFormFile formFile { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
    }
}

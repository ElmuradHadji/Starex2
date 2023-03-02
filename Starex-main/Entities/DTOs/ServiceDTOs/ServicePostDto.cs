using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ServiceDTOs
{
    public class ServicePostDto
    {
        public IFormFile formFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}

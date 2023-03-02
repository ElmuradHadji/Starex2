using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.NewsDTOs
{
    public class NewsPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile formFile { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CountryDTOs
{
    public class CountryPostDto
    {
        public string Name { get; set; }
        public IFormFile formFile { get; set; }
        public int CurrencyId { get; set; }
    }
}

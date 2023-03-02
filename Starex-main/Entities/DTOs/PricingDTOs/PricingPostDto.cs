namespace Entities.DTOs.PricingDTOs
{
    public class PricingPostDto
    {
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public double MinKG { get; set; }
        public double MaxKG { get; set; }
        public double Price { get; set; }
    }
}

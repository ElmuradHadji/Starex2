namespace Entities.DTOs.OrderForMeDTOs
{
    public class OrderForMePostDto
    {
        public bool IsPaid { get; set; }
        public string ProductUrl { get; set; }
        public int ProductCount { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public double ProductPrice { get; set; }
        public double InternalCargoPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Note { get; set; }
        public int? UserId { get; set; }
    }
}

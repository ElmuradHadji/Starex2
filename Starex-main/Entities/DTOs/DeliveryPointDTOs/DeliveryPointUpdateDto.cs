using System.Security.Cryptography.X509Certificates;

namespace Entities.DTOs.DeliveryPointDTOs
{
    public class DeliveryPointUpdateDto
    {
        public DeliveryPointGetDto deliveryPointGetDto { get; set; }
        public DeliveryPointPostDto deliveryPointPostDto { get; set; }
    }
}

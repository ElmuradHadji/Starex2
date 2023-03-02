using Entities.DTOs.PricingDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPricingService
    {
        List<PricingGetDto> GetAll();
        PricingGetDto GetById(int id);
        void Create(PricingPostDto pricingPostDto);
        void Update(PricingUpdateDto pricingUpdateDto);
        void Delete(int id);
    }
}

using Entities.DTOs.OrderForMeDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IOrderForMeService
    {
        List<OrderForMeGetDto> GetAll();
        OrderForMeGetDto GetById(int id);
        void Create(OrderForMePostDto orderForMePostDto);
        void Update(OrderForMeUpdateDto orderForMeUpdateDto);
        void Delete(int id);
    }
}

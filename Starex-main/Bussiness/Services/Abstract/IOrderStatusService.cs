using Entities.DTOs.OrderStatusDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Services.Abstract
{
    public interface IOrderStatusService
    {
        List<OrderStatusGetDto> GetAll();
        OrderStatusGetDto GetById(int id);
        void Create(OrderStatusPostDto orderStatusPostDto);
        void Update(OrderStatusUpdateDto orderStatusUpdateDto);
        void Delete(int id);
    }
}

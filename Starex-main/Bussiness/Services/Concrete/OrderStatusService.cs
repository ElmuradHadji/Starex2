using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.OrderStatusDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(OrderStatusPostDto orderStatusPostDto)
        {
            OrderStatus orderStatus = _orderStatusRepository.Get(p => p.Value == orderStatusPostDto.Value);
            if (orderStatus is not null)
            {
                throw new AlreadyExsistException("Status mövcuddur");
            }
            orderStatus = _mapper.Map<OrderStatus>(orderStatusPostDto);




            _orderStatusRepository.Create(orderStatus);
            _orderStatusRepository.Save();
        }

        public void Delete(int id)
        {
            OrderStatus orderStatus = _orderStatusRepository.Get(p => p.Id == id);
            if (orderStatus is null)
                throw new NotFoundException("Data tapılmadı");
            _orderStatusRepository.Delete(orderStatus);
            _orderStatusRepository.Save();

        }

        public List<OrderStatusGetDto> GetAll()
        {
            List<OrderStatusGetDto> list = new List<OrderStatusGetDto>();
            return _orderStatusRepository.GetAll().Count is not 0 ? _mapper.Map<List<OrderStatusGetDto>>(_orderStatusRepository.GetAll()) : list;
        }

        public OrderStatusGetDto GetById(int id)
        {
            OrderStatusGetDto orderStatusGetDto = new OrderStatusGetDto();
            if (_orderStatusRepository.Get(p => p.Id == id) is not null)
            {
                orderStatusGetDto = _mapper.Map<OrderStatusGetDto>(_orderStatusRepository.Get(p => p.Id == id));

            }
            return orderStatusGetDto;
        }




        public void Update(OrderStatusUpdateDto orderStatusUpdateDto)
        {
            OrderStatus orderStatus = _orderStatusRepository.Get(p => p.Id == orderStatusUpdateDto.orderStatusGetDto.Id);
            if (orderStatus is null)
                throw new NotFoundException("Data tapılmadı");
            orderStatus.Value = orderStatusUpdateDto.orderStatusPostDto.Value;
            _orderStatusRepository.Update(orderStatus);
            _orderStatusRepository.Save();
        }
    }
}

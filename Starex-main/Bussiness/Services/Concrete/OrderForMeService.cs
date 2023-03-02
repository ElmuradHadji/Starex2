using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.OrderForMeDTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class OrderForMeService : IOrderForMeService
    {
        private readonly IOrderForMeRepository _orderForMeRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public OrderForMeService(IOrderForMeRepository orderForMeRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _orderForMeRepository = orderForMeRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(OrderForMePostDto orderForMePostDto)
        {
            OrderForMe orderForMe = _orderForMeRepository.Get(p => p.ProductUrl == orderForMePostDto.ProductUrl);
            if (orderForMe is not null)
            {
                throw new AlreadyExsistException("Anbar mövcuddur");
            }
            orderForMe = _mapper.Map<OrderForMe>(orderForMePostDto);




            _orderForMeRepository.Create(orderForMe);
            _orderForMeRepository.Save();
        }

        public void Delete(int id)
        {
            OrderForMe orderForMe = _orderForMeRepository.Get(p => p.Id == id);
            if (orderForMe is null)
                throw new NotFoundException("Data tapılmadı");
            _orderForMeRepository.Delete(orderForMe);
            _orderForMeRepository.Save();

        }

        public List<OrderForMeGetDto> GetAll()
        {
            List<OrderForMeGetDto> list = new List<OrderForMeGetDto>();
            return _orderForMeRepository.GetAll().Count is not 0 ? _mapper.Map<List<OrderForMeGetDto>>(_orderForMeRepository.GetAll()) : list;
        }

        public OrderForMeGetDto GetById(int id)
        {
            OrderForMeGetDto orderForMeGetDto = new OrderForMeGetDto();
            if (_orderForMeRepository.Get(p => p.Id == id) is not null)
            {
                orderForMeGetDto = _mapper.Map<OrderForMeGetDto>(_orderForMeRepository.Get(p => p.Id == id));

            }
            return orderForMeGetDto;
        }



        //public void ModifyActivation(int id)
        //{
        //    OrderForMe orderForMe = _orderForMeRepository.Get(p => p.Id == id);
        //    if (orderForMe is null)
        //        throw new NotFoundException("Data tapılmadı");
        //    if (orderForMe.IsActive == true)
        //    {
        //        orderForMe.IsActive = false;
        //    }
        //    else { orderForMe.IsActive = true; }
        //    _orderForMeRepository.Update(orderForMe);
        //    _orderForMeRepository.Save();
        ////}

        public void Update(OrderForMeUpdateDto orderForMeUpdateDto)
        {
            OrderForMe orderForMe = _orderForMeRepository.Get(p => p.Id == orderForMeUpdateDto.orderForMeGetDto.Id);
            if (orderForMe is null)
                throw new NotFoundException("Data tapılmadı");
            //orderForMe.PackageCapasity = orderForMeUpdateDto.orderForMePostDTo.PackageCapasity;
            //orderForMe.Adress1 = orderForMeUpdateDto.orderForMePostDTo.Adress1;
            //orderForMe.AdressTitle = orderForMeUpdateDto.orderForMePostDTo.AdressTitle;
            //orderForMe.City = orderForMeUpdateDto.orderForMePostDTo.City;
            //orderForMe.CountryId = orderForMeUpdateDto.orderForMePostDTo.CountryId;
            //orderForMe.District = orderForMeUpdateDto.orderForMePostDTo.District;
            //orderForMe.Province = orderForMeUpdateDto.orderForMePostDTo.Province;
            //orderForMe.ZIP = orderForMeUpdateDto.orderForMePostDTo.ZIP;
            _orderForMeRepository.Update(orderForMe);
            _orderForMeRepository.Save();
        }
    }
}

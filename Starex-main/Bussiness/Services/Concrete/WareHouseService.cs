using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.WareHouseDTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public WareHouseService(IWareHouseRepository wareHouseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(WareHousePostDTO wareHousePostDto)
        {
            WareHouse wareHouse = _wareHouseRepository.Get(p => p.Adress1 == wareHousePostDto.Adress1);
            if (wareHouse is not null)
            {
                throw new AlreadyExsistException("Anbar mövcuddur");
            }
            wareHouse = _mapper.Map<WareHouse>(wareHousePostDto);




            _wareHouseRepository.Create(wareHouse);
            _wareHouseRepository.Save();
        }

        public void Delete(int id)
        {
            WareHouse wareHouse = _wareHouseRepository.Get(p => p.Id == id);
            if (wareHouse is null)
                throw new NotFoundException("Data tapılmadı");
            _wareHouseRepository.Delete(wareHouse);
            _wareHouseRepository.Save();

        }

        public List<WareHouseGetDto> GetAll()
        {
            List<WareHouseGetDto> list = new List<WareHouseGetDto>();
            return _wareHouseRepository.GetAll().Count is not 0 ? _mapper.Map<List<WareHouseGetDto>>(_wareHouseRepository.GetAll()) : list;
        }

        public WareHouseGetDto GetById(int id)
        {
            WareHouseGetDto wareHouseGetDto = new WareHouseGetDto();
            if (_wareHouseRepository.Get(p => p.Id == id) is not null)
            {
                wareHouseGetDto = _mapper.Map<WareHouseGetDto>(_wareHouseRepository.Get(p => p.Id == id));

            }
            return wareHouseGetDto;
        }



        public void ModifyActivation(int id)
        {
            WareHouse wareHouse = _wareHouseRepository.Get(p => p.Id == id);
            if (wareHouse is null)
                throw new NotFoundException("Data tapılmadı");
            if (wareHouse.IsActive == true)
            {
                wareHouse.IsActive = false;
            }
            else { wareHouse.IsActive = true; }
            _wareHouseRepository.Update(wareHouse);
            _wareHouseRepository.Save();
        }

        public void Update(WareHouseUpdateDto wareHouseUpdateDto)
        {
            WareHouse wareHouse = _wareHouseRepository.Get(p => p.Id == wareHouseUpdateDto.wareHouseGetDto.Id);
            if (wareHouse is null)
                throw new NotFoundException("Data tapılmadı");
            wareHouse.PackageCapasity= wareHouseUpdateDto.wareHousePostDTo.PackageCapasity;
            wareHouse.Adress1= wareHouseUpdateDto.wareHousePostDTo.Adress1;
            wareHouse.AdressTitle= wareHouseUpdateDto.wareHousePostDTo.AdressTitle;
            wareHouse.City= wareHouseUpdateDto.wareHousePostDTo.City;
            wareHouse.CountryId= wareHouseUpdateDto.wareHousePostDTo.CountryId;
            wareHouse.District= wareHouseUpdateDto.wareHousePostDTo.District;
            wareHouse.Province= wareHouseUpdateDto.wareHousePostDTo.Province;
            wareHouse.ZIP= wareHouseUpdateDto.wareHousePostDTo.ZIP;
            _wareHouseRepository.Update(wareHouse);
            _wareHouseRepository.Save();
        }
    }
}

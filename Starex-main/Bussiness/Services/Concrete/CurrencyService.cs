using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.CurrencyDTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(CurrencyPostDto currencyPostDto)
        {
            _currencyRepository.Create(_mapper.Map<Currency>(currencyPostDto));
            _currencyRepository.Save();
        }

        public void Delete(int id)
        {
            Currency currency = _currencyRepository.Get(p => p.Id == id);
            if (currency is null)
                throw new NotFoundException("Data tapılmadı");
            _currencyRepository.Delete(currency);
            _currencyRepository.Save();

        }

        public List<CurrencyGetDto> GetAll()
        {
            List<CurrencyGetDto> list = new List<CurrencyGetDto>();
            return _currencyRepository.GetAll().Count is not 0 ? _mapper.Map<List<CurrencyGetDto>>(_currencyRepository.GetAll()) : list;
        }

        public CurrencyGetDto GetById(int id)
        {
            CurrencyGetDto currencyGetDto = new CurrencyGetDto();
            if (_currencyRepository.Get(p => p.Id == id) is not null)
            {
                currencyGetDto = _mapper.Map<CurrencyGetDto>(_currencyRepository.Get(p => p.Id == id));

            }
            return currencyGetDto;
        }

        public void Update(CurrencyUpdateDto currencyUpdateDto)
        {
            Currency currency = _currencyRepository.Get(p => p.Id == currencyUpdateDto.currencyGetDto.Id);
            if (currency is null)
                throw new NotFoundException("Data tapılmadı");
            currency.Name = currencyUpdateDto.currencyPostDto.Name;
            currency.ShortName = currencyUpdateDto.currencyPostDto.ShortName;
            currency.Icon = currencyUpdateDto.currencyPostDto.Icon;
            _currencyRepository.Update(currency);
            _currencyRepository.Save();
        }
    }
}

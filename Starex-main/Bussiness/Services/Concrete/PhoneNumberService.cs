using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.PhoneNumberDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class PhoneNumberService: IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(PhoneNumberPostDto phoneNumberPostDto)
        {
            _phoneNumberRepository.Create(_mapper.Map<PhoneNumber>(phoneNumberPostDto));
            _phoneNumberRepository.Save();
        }

        public void Delete(int id)
        {
            PhoneNumber phoneNumber = _phoneNumberRepository.Get(p => p.Id == id);
            if (phoneNumber is null)
                throw new NotFoundException("Data tapılmadı");
            _phoneNumberRepository.Delete(phoneNumber);
            _phoneNumberRepository.Save();

        }

        public List<PhoneNumberGetDto> GetAll()
        {
            List<PhoneNumberGetDto> list = new List<PhoneNumberGetDto>();
            return _phoneNumberRepository.GetAll().Count is not 0 ? _mapper.Map<List<PhoneNumberGetDto>>(_phoneNumberRepository.GetAll()) : list;
        }

        public PhoneNumberGetDto GetById(int id)
        {
            PhoneNumberGetDto phoneNumberGetDto = new PhoneNumberGetDto();
            if (_phoneNumberRepository.Get(p => p.Id == id) is not null)
            {
                phoneNumberGetDto = _mapper.Map<PhoneNumberGetDto>(_phoneNumberRepository.Get(p => p.Id == id));

            }
            return phoneNumberGetDto;
        }

        public void Update(PhoneNumberUpdateDto phoneNumberUpdateDto)
        {
            PhoneNumber phoneNumber = _phoneNumberRepository.Get(p => p.Id == phoneNumberUpdateDto.phoneNumberGetDto.Id);
            if (phoneNumber is null)
                throw new NotFoundException("Data tapılmadı");
            phoneNumber.Number = phoneNumberUpdateDto.phoneNumberPostDto.Number;
            _phoneNumberRepository.Update(phoneNumber);
            _phoneNumberRepository.Save();
        }
    }
}

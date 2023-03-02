using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.PhoneNumberPrefixDTOs;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class PhoneNumberPrefixService : IPhoneNumberPrefixService
    {
        private readonly IPhoneNumberPrefixRepository _phoneNumberPrefixRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PhoneNumberPrefixService(IPhoneNumberPrefixRepository phoneNumberPrefixRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _phoneNumberPrefixRepository = phoneNumberPrefixRepository;
            _mapper = mapper;
            _env = env;
        }


        public void Create(PhoneNumberPrefixPostDto phoneNumberPrefixPostDto)
        {
            PhoneNumberPrefix phoneNumberPrefix = _phoneNumberPrefixRepository.Get(p => p.Value == phoneNumberPrefixPostDto.Value);
            if (phoneNumberPrefix is not null)
            {
                throw new AlreadyExsistException("Sual mövcuddur");
            }
            phoneNumberPrefix = _mapper.Map<PhoneNumberPrefix>(phoneNumberPrefixPostDto);




            _phoneNumberPrefixRepository.Create(phoneNumberPrefix);
            _phoneNumberPrefixRepository.Save();
        }

        public void Delete(int id)
        {
            PhoneNumberPrefix phoneNumberPrefix = _phoneNumberPrefixRepository.Get(p => p.Id == id);
            if (phoneNumberPrefix is null)
                throw new NotFoundException("Data tapılmadı");
            _phoneNumberPrefixRepository.Delete(phoneNumberPrefix);
            _phoneNumberPrefixRepository.Save();

        }

        public List<PhoneNumberPrefixGetDto> GetAll()
        {
            List<PhoneNumberPrefixGetDto> list = new List<PhoneNumberPrefixGetDto>();
            return _phoneNumberPrefixRepository.GetAll().Count is not 0 ? _mapper.Map<List<PhoneNumberPrefixGetDto>>(_phoneNumberPrefixRepository.GetAll()) : list;
        }

        public PhoneNumberPrefixGetDto GetById(int id)
        {
            PhoneNumberPrefixGetDto phoneNumberPrefixGetDto = new PhoneNumberPrefixGetDto();
            if (_phoneNumberPrefixRepository.Get(p => p.Id == id) is not null)
            {
                phoneNumberPrefixGetDto = _mapper.Map<PhoneNumberPrefixGetDto>(_phoneNumberPrefixRepository.Get(p => p.Id == id));

            }
            return phoneNumberPrefixGetDto;
        }




        public void Update(PhoneNumberPrefixUpdateDto phoneNumberPrefixUpdateDto)
        {
            PhoneNumberPrefix phoneNumberPrefix = _phoneNumberPrefixRepository.Get(p => p.Id == phoneNumberPrefixUpdateDto.phoneNumberPrefixGetDto.Id);
            if (phoneNumberPrefix is null)
                throw new NotFoundException("Data tapılmadı");
            phoneNumberPrefix.Value = phoneNumberPrefixUpdateDto.phoneNumberPrefixPostDto.Value;
            _phoneNumberPrefixRepository.Update(phoneNumberPrefix);
            _phoneNumberPrefixRepository.Save();
        }

    }
   
}

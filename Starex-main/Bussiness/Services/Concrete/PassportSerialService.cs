using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.PassportSerialDTOs;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Microsoft.AspNetCore.Hosting;
namespace Bussiness.Services.Concrete
{
    public class PassportSerialService : IPassportSerialService
    {
        private readonly IPassportSerialRepository _passportSerialRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

       public PassportSerialService(IPassportSerialRepository PassportSerialRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _passportSerialRepository = PassportSerialRepository;
            _mapper = mapper;
            _env = env;
        }


        public void Create(PassportSerialPostDto passportSerialPostDto)
        {
            PassportSerial passportSerial = _passportSerialRepository.Get(p => p.Value == passportSerialPostDto.Value);
            if (passportSerial is not null)
            {
                throw new AlreadyExsistException("Sual mövcuddur");
            }
            passportSerial = _mapper.Map<PassportSerial>(passportSerialPostDto);




            _passportSerialRepository.Create(passportSerial);
            _passportSerialRepository.Save();
        }

        public void Delete(int id)
        {
            PassportSerial passportSerial = _passportSerialRepository.Get(p => p.Id == id);
            if (passportSerial is null)
                throw new NotFoundException("Data tapılmadı");
            _passportSerialRepository.Delete(passportSerial);
            _passportSerialRepository.Save();

        }

        public List<PassportSerialGetDto> GetAll()
        {
            List<PassportSerialGetDto> list = new List<PassportSerialGetDto>();
            return _passportSerialRepository.GetAll().Count is not 0 ? _mapper.Map<List<PassportSerialGetDto>>(_passportSerialRepository.GetAll()) : list;
        }

        public PassportSerialGetDto GetById(int id)
        {
            PassportSerialGetDto passportSerialGetDto = new PassportSerialGetDto();
            if (_passportSerialRepository.Get(p => p.Id == id) is not null)
            {
                passportSerialGetDto = _mapper.Map<PassportSerialGetDto>(_passportSerialRepository.Get(p => p.Id == id));

            }
            return passportSerialGetDto;
        }




        public void Update(PassportSerialUpdateDto passportSerialUpdateDto)
        {
            PassportSerial passportSerial = _passportSerialRepository.Get(p => p.Id == passportSerialUpdateDto.passportSerialGetDto.Id);
            if (passportSerial is null)
                throw new NotFoundException("Data tapılmadı");
            passportSerial.Value = passportSerialUpdateDto.passportSerialPostDto.Value;
            _passportSerialRepository.Update(passportSerial);
            _passportSerialRepository.Save();
        }

    }
}

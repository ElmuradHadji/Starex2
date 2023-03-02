using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.GenderDTOs;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public GenderService(IGenderRepository genderRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(GenderPostDto genderPostDto)
        {
            Gender gender = _genderRepository.Get(p => p.Name == genderPostDto.Name);
            if (gender is not null)
            {
                throw new AlreadyExsistException("Sual mövcuddur");
            }
            gender = _mapper.Map<Gender>(genderPostDto);




            _genderRepository.Create(gender);
            _genderRepository.Save();
        }

        public void Delete(int id)
        {
            Gender gender = _genderRepository.Get(p => p.Id == id);
            if (gender is null)
                throw new NotFoundException("Data tapılmadı");
            _genderRepository.Delete(gender);
            _genderRepository.Save();

        }

        public List<GenderGetDto> GetAll()
        {
            List<GenderGetDto> list = new List<GenderGetDto>();
            return _genderRepository.GetAll().Count is not 0 ? _mapper.Map<List<GenderGetDto>>(_genderRepository.GetAll()) : list;
        }

        public GenderGetDto GetById(int id)
        {
            GenderGetDto genderGetDto = new GenderGetDto();
            if (_genderRepository.Get(p => p.Id == id) is not null)
            {
                genderGetDto = _mapper.Map<GenderGetDto>(_genderRepository.Get(p => p.Id == id));

            }
            return genderGetDto;
        }




        public void Update(GenderUpdateDto genderUpdateDto)
        {
            Gender gender = _genderRepository.Get(p => p.Id == genderUpdateDto.genderGetDto.Id);
            if (gender is null)
                throw new NotFoundException("Data tapılmadı");
            gender.Name = genderUpdateDto.genderPostDto.Name;
            _genderRepository.Update(gender);
            _genderRepository.Save();
        }

    }
    
    
}

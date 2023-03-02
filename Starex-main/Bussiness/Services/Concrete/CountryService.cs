using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Extentions;
using DataAccess.Repositories.Abstarct;
using DataAccess.Repositories.Conctrete.EF;
using Entities.Concrete;
using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.CountryDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CountryService(ICountryRepository countryRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(CountryPostDto countryPostDto)
        {
            Country country = _countryRepository.Get(p => p.Name == countryPostDto.Name);
            if (country is not null)
            {
                throw new AlreadyExsistException("Ölkə mövcuddur");
            }
            country = _mapper.Map<Country>(countryPostDto);


            country.Flag = countryPostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");
            _countryRepository.Create(country);
            _countryRepository.Save();
        }

        public void Delete(int id)
        {
            Country country = _countryRepository.Get(p => p.Id == id);
            if (country is null)
                throw new NotFoundException("Data tapılmadı");
            _countryRepository.Delete(country);
            _countryRepository.Save();

        }

        public List<CountryGetDto> GetAll()
        {
            List<CountryGetDto> list = new List<CountryGetDto>();
            return _countryRepository.GetAll().Count is not 0 ? _mapper.Map<List<CountryGetDto>>(_countryRepository.GetAll()) : list;
        }

        public CountryGetDto GetById(int id)
        {
            CountryGetDto countryGetDto = new CountryGetDto();
            if (_countryRepository.Get(p => p.Id == id) is not null)
            {
                countryGetDto = _mapper.Map<CountryGetDto>(_countryRepository.Get(p => p.Id == id));

            }
            return countryGetDto;
        }

        public void Update(CountryUpdateDto countryUpdateDto)
        {
            Country country = _countryRepository.Get(p => p.Id == countryUpdateDto.countryGetDto.Id);
            if (country is null)
                throw new NotFoundException("Data tapılmadı");
            country.Name = countryUpdateDto.countryPostDto.Name;
            country.CurrencyId = countryUpdateDto.countryPostDto.CurrencyId;
            if (countryUpdateDto.countryPostDto.formFile is not null)
            {

                Core.Utilities.Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", country.Flag);
                country.Flag = countryUpdateDto.countryPostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");

            }
            _countryRepository.Update(country);
            _countryRepository.Save();
        }
    }
}

using Entities.DTOs.CountryDTOs;

namespace Bussiness.Services.Abstract
{
    public interface ICountryService
    {
        List<CountryGetDto> GetAll();
        CountryGetDto GetById(int id);
        void Create(CountryPostDto countryPostDto);
        void Update(CountryUpdateDto countryUpdateDto);
        void Delete(int id);
    }
}

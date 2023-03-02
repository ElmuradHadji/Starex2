using Entities.DTOs.CountryDTOs;
using Entities.DTOs.CurrencyDTOs;

namespace Bussiness.Services.Abstract
{
    public interface ICurrencyService
    {
        List<CurrencyGetDto> GetAll();
        CurrencyGetDto GetById(int id);
        void Create(CurrencyPostDto currencyPostDto);
        void Update(CurrencyUpdateDto currencyUpdateDto);
        void Delete(int id);
    }
}

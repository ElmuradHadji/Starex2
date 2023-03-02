using Core.Entities.DTOs.PhoneNumberPrefixDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPhoneNumberPrefixService
    {
        List<PhoneNumberPrefixGetDto> GetAll();
        PhoneNumberPrefixGetDto GetById(int id);
        void Create(PhoneNumberPrefixPostDto phoneNumberPrefixPostDto);
        void Update(PhoneNumberPrefixUpdateDto phoneNumberPrefixUpdateDto);
        void Delete(int id);
    }
}

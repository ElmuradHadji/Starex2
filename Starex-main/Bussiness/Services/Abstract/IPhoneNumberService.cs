using Entities.DTOs.PhoneNumberDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPhoneNumberService
    {
        List<PhoneNumberGetDto> GetAll();
        PhoneNumberGetDto GetById(int id);
        void Create(PhoneNumberPostDto phoneNumberPostDto);
        void Update (PhoneNumberUpdateDto pohoneNumberUpdateDto);
        void Delete(int id);
    }
}

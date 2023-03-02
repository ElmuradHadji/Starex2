using Core.Entities.DTOs.PassportSerialDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPassportSerialService
    {
        List<PassportSerialGetDto> GetAll();
        PassportSerialGetDto GetById(int id);
        void Create(PassportSerialPostDto passportSerialPostDto);
        void Update(PassportSerialUpdateDto passportSerialUpdateDto);
        void Delete(int id);
    }
}

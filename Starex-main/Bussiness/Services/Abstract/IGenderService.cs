using Core.Entities.DTOs.GenderDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IGenderService
    {
        List<GenderGetDto> GetAll();
        GenderGetDto GetById(int id);
        void Create(GenderPostDto genderPostDto);
        void Update(GenderUpdateDto genderUpdateDto);
        void Delete(int id);
    }
}

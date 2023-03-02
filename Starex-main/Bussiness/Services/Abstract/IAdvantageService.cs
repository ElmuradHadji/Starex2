using Entities.Concrete;
using Entities.DTOs.AdvantageDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IAdvantageService
    {
        List<AdvantageGetDto> GetAll();
        AdvantageGetDto GetById(int id);
        void Create(AdvantagePostDto aboutPostDto);
        void Update(AdvantageUpdateDto aboutUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}

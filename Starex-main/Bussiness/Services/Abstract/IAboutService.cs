using Entities.DTOs.AboutDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IAboutService
    {
        List<AboutGetDto> GetAll();
        AboutGetDto GetById(int id);
        void Create(AboutPostDto aboutPostDto);
        void Update(AboutUpdateDto aboutUpdateDto);
        void Delete(int id);
    }
}

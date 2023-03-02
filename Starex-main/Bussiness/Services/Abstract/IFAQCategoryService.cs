using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.FAQCategoryDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IFAQCategoryService
    {
        List<FAQCategoryGetDto> GetAll();
        FAQCategoryGetDto GetById(int id);
        void Create(FAQCategoryPostDto FAQCategoryPostDto);
        void Update(FAQCategoryUpdateDto FAQCategoryUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}

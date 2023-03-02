using Entities.DTOs.FAQCategoryDTOs;
using Entities.DTOs.FAQDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IFAQService
    {
        List<FAQGetDto> GetAll();
        FAQGetDto GetById(int id);
        void Create(FAQPostDto FAQPostDto);
        void Update(FAQUpdateDto FAQUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}

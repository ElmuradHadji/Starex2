using Entities.DTOs.FAQDTOs;
using Entities.DTOs.NewsDTOs;

namespace Bussiness.Services.Abstract
{
    public interface INewsService
    {
        List<NewsGetDto> GetAll();
        NewsGetDto GetById(int id);
        void Create(NewsPostDto newsPostDto);
        void Update(NewsUpdateDto newsUpdateDto);
        void Delete(int id);
    }
}

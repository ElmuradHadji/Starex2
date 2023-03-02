using Core.Entities.DTOs.SocialDTOs;

namespace Bussiness.Services.Abstract
{
    public interface ISocialService
    {
        List<SocialGetDto> GetAll();
        SocialGetDto GetById(int id);
        void Create(SocialPostDto socialPostDto);
        void Update(SocialUpdateDto socialUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}

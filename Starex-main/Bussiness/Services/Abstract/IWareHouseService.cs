using Entities.DTOs.WareHouseDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IWareHouseService
    {
        List<WareHouseGetDto> GetAll();
        WareHouseGetDto GetById(int id);
        void Create(WareHousePostDTO wareHousePostDto);
        void Update(WareHouseUpdateDto wareHouseUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);

    }
}

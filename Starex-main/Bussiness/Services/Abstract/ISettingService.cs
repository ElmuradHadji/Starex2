using Core.Entities.DTOs.SettingDTOs;

namespace Bussiness.Services.Abstract
{
    public interface ISettingService
    {
        List<SettingGetDto> GetAll();
        SettingGetDto GetById(int id);
        void Update(SettingUpdateDto settingUpdateDto);
    }
}

using Entities.DTOs.PackageDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPackageService
    {
        //List<PackageGetDto> GetAll();
        List<PackageGetDto> GetAllByWareHouse(int? wareHouseId);
        PackageGetDto GetById(int id);
        void Create(PackagePostDto packagePostDto);
        void Update(PackageUpdateDto packageUpdateDto);
        void Delete(int id);
    }
}

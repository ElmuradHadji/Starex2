using Entities.DTOs.PackageStatusDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IPackageStatusService
    {
        List<PackageStatusGetDto> GetAll();
        PackageStatusGetDto GetById(int id);
        void Create(PackageStatusPostDto packageStatusPostDto);
        void Update(PackageStatusUpdateDto packageStatusUpdateDto);
        void Delete(int id);
    }
}

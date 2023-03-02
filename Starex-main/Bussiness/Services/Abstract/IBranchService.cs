using Entities.DTOs.BranchDTOs;

namespace Bussiness.Services.Abstract
{
    public interface IBranchService
    {
        List<BranchGetDto> GetAll();
        BranchGetDto GetById(int id);
        void Create(BranchPostDto branchPostDto);
        void Update(BranchUpdateDto branchUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}

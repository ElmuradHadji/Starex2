using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class BranchRepository : EntityRepositoryBase<Branch, AppDbContext>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context) { }

    }
}

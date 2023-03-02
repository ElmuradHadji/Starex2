using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PackageStatusRepository : EntityRepositoryBase<PackageStatus, AppDbContext>, IPackageStatusRepository
    {
        public PackageStatusRepository(AppDbContext context) : base(context) { }

    }
}

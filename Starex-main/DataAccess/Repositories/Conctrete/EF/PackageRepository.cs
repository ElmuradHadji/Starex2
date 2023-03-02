using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PackageRepository : EntityRepositoryBase<Package, AppDbContext>, IPackageRepository
    {
        public PackageRepository(AppDbContext context) : base(context) { }

    }
}

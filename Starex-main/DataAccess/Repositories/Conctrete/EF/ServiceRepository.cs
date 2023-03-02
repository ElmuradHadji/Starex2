using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class ServiceRepository : EntityRepositoryBase<Service, AppDbContext>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context) { }

    }
}

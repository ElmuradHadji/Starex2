using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class DeliveryPointRepository : EntityRepositoryBase<DeliveryPoint, AppDbContext>, IDeliveryPointRepository
    {
        public DeliveryPointRepository(AppDbContext context) : base(context) { }

    }
}

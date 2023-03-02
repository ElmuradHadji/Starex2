using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PricingRepository : EntityRepositoryBase<Pricing, AppDbContext>, IPricingRepository
    {
        public PricingRepository(AppDbContext context) : base(context)
        {
        }
    }
}

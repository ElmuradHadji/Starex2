using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class OrderForMeRepository : EntityRepositoryBase<OrderForMe, AppDbContext>, IOrderForMeRepository
    {
        public OrderForMeRepository(AppDbContext context) : base(context) { }

    }
}

using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class OrderStatusRepository : EntityRepositoryBase<OrderStatus, AppDbContext>, IOrderStatusRepository
    {
        public OrderStatusRepository(AppDbContext context) : base(context) { }

    }
}

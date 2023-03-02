using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class WareHouseRepository : EntityRepositoryBase<WareHouse, AppDbContext>, IWareHouseRepository
    {
        public WareHouseRepository(AppDbContext context) : base(context) { }

    }
}

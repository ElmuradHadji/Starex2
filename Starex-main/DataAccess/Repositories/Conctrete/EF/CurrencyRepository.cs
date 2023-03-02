using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class CurrencyRepository : EntityRepositoryBase<Currency, AppDbContext>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context) { }

    }
}

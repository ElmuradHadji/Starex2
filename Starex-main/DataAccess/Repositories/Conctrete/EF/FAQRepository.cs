using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class FAQRepository : EntityRepositoryBase<FAQ, AppDbContext>, IFAQRepository
    {
        public FAQRepository(AppDbContext context) : base(context) { }

    }
}

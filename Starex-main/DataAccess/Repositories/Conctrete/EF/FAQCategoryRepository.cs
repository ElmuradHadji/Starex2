using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class FAQCategoryRepository : EntityRepositoryBase<FAQCategory, AppDbContext>, IFAQCategoryRepository
    {
        public FAQCategoryRepository(AppDbContext context) : base(context) { }

    }
}

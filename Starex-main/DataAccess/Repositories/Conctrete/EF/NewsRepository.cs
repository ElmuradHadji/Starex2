using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class NewsRepository : EntityRepositoryBase<News, AppDbContext>, INewsRepository
    {
        public NewsRepository(AppDbContext context) : base(context) { }

    }
}

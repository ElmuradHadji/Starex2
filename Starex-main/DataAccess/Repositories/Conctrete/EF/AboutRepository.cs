using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class AboutRepository : EntityRepositoryBase<About, AppDbContext>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context) { }

    }

}

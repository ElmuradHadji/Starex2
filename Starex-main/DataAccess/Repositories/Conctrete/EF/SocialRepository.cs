using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class SocialRepository : EntityRepositoryBase<Social, AppDbContext>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context) { }

    }

}

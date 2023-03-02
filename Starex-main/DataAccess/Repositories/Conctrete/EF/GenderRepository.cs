using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class GenderRepository : EntityRepositoryBase<Gender, AppDbContext>, IGenderRepository
    {
        public GenderRepository(AppDbContext context) : base(context) { }
    }

}

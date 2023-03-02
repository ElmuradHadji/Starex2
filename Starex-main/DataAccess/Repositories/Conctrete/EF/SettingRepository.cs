using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class SettingRepository : EntityRepositoryBase<Setting, AppDbContext>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context) { }

    }

}

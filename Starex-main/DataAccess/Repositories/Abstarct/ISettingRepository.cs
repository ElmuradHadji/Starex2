using Core.DAL.Repositories.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface ISettingRepository : IEntityRepository<Setting, AppDbContext>
    {

    }
}

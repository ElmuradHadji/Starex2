using Core.DAL.Repositories.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface ISocialRepository : IEntityRepository<Social, AppDbContext>
    {

    }
}

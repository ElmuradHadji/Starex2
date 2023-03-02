using Core.DAL.Repositories.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface IGenderRepository : IEntityRepository<Gender, AppDbContext>
    {

    }
}

using Core.DAL.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface ICountryRepository:IEntityRepository<Country,AppDbContext>
    {
    }
}

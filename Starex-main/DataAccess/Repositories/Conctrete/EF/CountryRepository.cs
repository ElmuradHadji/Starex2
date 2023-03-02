using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class CountryRepository : EntityRepositoryBase<Country, AppDbContext>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context) { }

    }
}

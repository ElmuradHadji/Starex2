using Core.DAL.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface IAdvantageRepository : IEntityRepository<Advantage, AppDbContext>
    {
        public void ModifyActivationStatus(Advantage advantage);

    }
}

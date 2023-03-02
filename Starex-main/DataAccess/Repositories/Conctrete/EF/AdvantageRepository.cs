using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class AdvantageRepository : EntityRepositoryBase<Advantage, AppDbContext>, IAdvantageRepository
    {
        public AdvantageRepository(AppDbContext context) : base(context) { }

        public void ModifyActivationStatus(Advantage advantage)
        {
            if (advantage.IsActive==true)
            {
                advantage.IsActive = false;
            }
            else advantage.IsActive = true;
        }

        public void ModifyActivationStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}

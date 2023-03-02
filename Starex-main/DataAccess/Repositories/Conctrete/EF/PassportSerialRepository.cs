using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PassportSerialRepository : EntityRepositoryBase<PassportSerial, AppDbContext>, IPassportSerialRepository
    {
        public PassportSerialRepository(AppDbContext context) : base(context) { }


    }

}

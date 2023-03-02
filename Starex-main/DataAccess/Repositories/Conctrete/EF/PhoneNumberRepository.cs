using Core.DAL.Repositories.Concrete;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PhoneNumberRepository : EntityRepositoryBase<PhoneNumber, AppDbContext>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDbContext context) : base(context) { }

    }
}

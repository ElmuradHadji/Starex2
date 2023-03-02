using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class PhoneNumberPrefixRepository : EntityRepositoryBase<PhoneNumberPrefix, AppDbContext>, IPhoneNumberPrefixRepository
    {
        public PhoneNumberPrefixRepository(AppDbContext context) : base(context) { }

    }

}

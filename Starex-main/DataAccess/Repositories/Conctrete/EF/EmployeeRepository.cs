using Core.DAL.Repositories.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstarct;

namespace DataAccess.Repositories.Conctrete.EF
{
    public class EmployeeRepository: EntityRepositoryBase<AppUser, AppDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }
    
    }
}

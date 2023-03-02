using Core.DAL.Repositories.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstarct
{
    public interface IEmployeeRepository : IEntityRepository<AppUser, AppDbContext>
    {

    }
}

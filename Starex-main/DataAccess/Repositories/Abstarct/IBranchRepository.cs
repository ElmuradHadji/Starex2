﻿using Core.DAL.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Abstarct
{
    public interface IBranchRepository:IEntityRepository<Branch,AppDbContext>
    {
    }
}

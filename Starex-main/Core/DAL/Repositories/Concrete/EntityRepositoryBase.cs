using Core.DAL.Repositories.Abstract;
using Core.Entities;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DAL.Repositories.Concrete
{
    public class EntityRepositoryBase<Tentity,Tcontext> : IEntityRepository<Tentity,Tcontext>
        where Tentity:class,IEntity,new()
        where Tcontext:IdentityDbContext<AppUser>
    {
        private readonly Tcontext _context;

        public EntityRepositoryBase(Tcontext context)
        {
            _context = context;
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> expression = null, params string[] includes)
        {
            IQueryable<Tentity> query = GetQuery(includes);
            return expression is null
                ? query.ToList()
                : query.Where(expression).ToList();
        }

        private IQueryable<Tentity> GetQuery(string[] includes)
        {
            IQueryable<Tentity> query = _context.Set<Tentity>();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }

            return query;
        }

        public Tentity Get(Expression<Func<Tentity, bool>> expression, params string[] includes)
        {
            IQueryable<Tentity> query = GetQuery(includes);
            return query.Where(expression).FirstOrDefault();
        }


        public List<Tentity> GetAllPaginated(int page, int size, Expression<Func<Tentity, bool>> expression, params string[] includes)
        {
            IQueryable<Tentity> query = GetQuery(includes);
            return expression is null
                ? query.Skip((page-1)*size).Take(size).ToList()
                : query.Where(expression).Skip((page - 1) * size).Take(size).ToList();
        }

        public bool IsExsists(Expression<Func<Tentity, bool>> expression)
        {
            return _context.Set<Tentity>().Where(expression).Any();
        }
        public void Create(Tentity entity)
        {
            _context.Set<Tentity>().Add(entity);

        }

        public void Delete(Tentity entity)
        {
            _context.Set<Tentity>().Remove(entity);

        }
        public void Update(Tentity entity)
        {
            _context.Set<Tentity>().Update(entity);
        } 
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

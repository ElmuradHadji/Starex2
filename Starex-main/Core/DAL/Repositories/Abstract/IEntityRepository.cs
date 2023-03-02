using System.Linq.Expressions;

namespace Core.DAL.Repositories.Abstract
{
    public interface IEntityRepository<Tentity,Tcontext>
    {
        List<Tentity> GetAll(Expression<Func<Tentity,bool>> expression=null, params string[] includes);
        List<Tentity> GetAllPaginated(int page, int size,Expression<Func<Tentity,bool>> expression, params string[] includes);
        Tentity Get(Expression<Func<Tentity, bool>> expression, params string[] includes);
        bool IsExsists(Expression<Func<Tentity, bool>> expression);
        void Create(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);
        void Save();
    }
}

using System.Linq;

namespace EFProject.Data.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        TEntity CreateAndGet(TEntity entity);

        void Update(TEntity entity, bool includesNullableProps = false);

        void Delete(int id);
    }
}

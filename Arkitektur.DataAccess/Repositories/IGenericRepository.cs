using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity>  where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsycn();

        IQueryable<TEntity> GetQueryable();

        Task<TEntity> GetByIdAsync(int id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);


    }
}

using System.Linq.Expressions;

namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task UpdateAsync(TEntity entity);

        ValueTask<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}

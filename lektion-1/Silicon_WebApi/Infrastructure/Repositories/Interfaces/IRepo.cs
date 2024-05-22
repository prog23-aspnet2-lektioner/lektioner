using System.Linq.Expressions;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<IRepositoryResult<TEntity>> CreateAsync(TEntity entity);
        Task<IRepositoryResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<IRepositoryResult<TEntity>> ExistsAsync(Expression<Func<TEntity, bool>> deligate);
        Task<IRepositoryResult<IEnumerable<TEntity>>> GetAsync();
        Task<IRepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IRepositoryResult<TEntity>> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
    }
}
using System;
using System.Linq.Expressions;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract
{
	public interface IEntityRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> SkipTakeAsync(int skip = 0, int take = 100, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> sortBy = null, bool sortByDescending = true);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}


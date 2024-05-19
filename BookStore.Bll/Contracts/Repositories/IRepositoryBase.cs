using BookStore.Core.Entities.Base;
using System.Linq.Expressions;

namespace BookStore.Bll.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null);
    }
}

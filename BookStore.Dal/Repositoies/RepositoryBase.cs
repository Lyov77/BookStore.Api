using BookStore.Bll.Contracts.Repositories;
using BookStore.Core.Entities.Base;
using BookStore.Dal.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Dal.Repositoies
{
    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        protected ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }

            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<TEntity>().Where(predicate);
            }

            return _context.Set<TEntity>().AsQueryable();
        }
    }
}

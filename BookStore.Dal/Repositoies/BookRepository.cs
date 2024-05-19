using BookStore.Bll.Contracts.Repositories;
using BookStore.Core.Entities;
using BookStore.Dal.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Dal.Repositoies
{
    internal class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        internal BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Book?> GetBookWithAuthor(int bookId)
        {
            return _context.Books
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == bookId);
        }

        public override IQueryable<Book> GetAll(Expression<Func<Book, bool>>? predicate = null)
        {
            return base.GetAll(predicate).Where(x => !x.IsDeleted);
        }
    }
}

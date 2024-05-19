using BookStore.Core.Entities;

namespace BookStore.Bll.Contracts.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<Book?> GetBookWithAuthor(int bookId);
    }
}

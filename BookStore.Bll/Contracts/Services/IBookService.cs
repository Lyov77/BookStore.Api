using BookStore.Core.DTOs.BookDTOs;

namespace BookStore.Bll.Contracts.Services
{
    public interface IBookService
    {
        Task DeleteBook(int bookId);
        Task<BookDTO> AddBookAsync(CreateBookDTO bookDTO);
    }
}

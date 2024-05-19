using BookStore.Bll.Contracts.Services;
using BookStore.Core.DTOs.BookDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> CreateBookAsync([FromBody] CreateBookDTO book)
        {
            var result = await _bookService.AddBookAsync(book);
            return Ok(result);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteAsync(int bookId)
        {
            await _bookService.DeleteBook(bookId);
            return Ok();
        }
    }
}

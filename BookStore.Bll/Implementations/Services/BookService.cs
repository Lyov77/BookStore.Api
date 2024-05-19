using AutoMapper;
using BookStore.Bll.Contracts.Repositories;
using BookStore.Bll.Contracts.Services;
using BookStore.Core.DTOs.BookDTOs;
using BookStore.Core.Entities;

namespace BookStore.Bll.Implementations.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IRepositoryManager _repositoryManager;

        public BookService(
            IBookRepository bookRepository,
            IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BookDTO> AddBookAsync(CreateBookDTO bookDTO)
        {
            var entity = _mapper.Map<Book>(bookDTO);

            _bookRepository.Add(entity);
            await _repositoryManager.CommitAsync();

            var result = await _bookRepository.GetBookWithAuthor(entity.Id);
            return _mapper.Map<BookDTO>(result);
        }

        public async Task DeleteBook(int bookId)
        {
            var entity = await _bookRepository.FirstOrDefaultAsync(x => x.Id == bookId);

            if (entity is null)
            {
                return;
            }

            entity.IsDeleted = true;
            _bookRepository.Update(entity);
            await _repositoryManager.CommitAsync();
        }
    }
}

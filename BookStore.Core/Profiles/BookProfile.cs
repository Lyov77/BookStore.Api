using AutoMapper;
using BookStore.Core.DTOs.BookDTOs;
using BookStore.Core.Entities;

namespace BookStore.Core.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BaseBookDTO>();

            CreateMap<CreateBookDTO, Book>();

            CreateMap<Book, BookDTO>()
                .IncludeBase<Book, BaseBookDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}

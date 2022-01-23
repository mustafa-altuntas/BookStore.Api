using AutoMapper;
using BookStore.Api.BookOperations.GetBookDetail;
using BookStore.Api.BookOperations.GetBooks;
using static BookStore.Api.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}

using AutoMapper;
using BookStore.Api.Aplication.AuthorOperations.Commands.CreateAuthor;
using BookStore.Api.Aplication.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Api.Aplication.AuthorOperations.Queries.GetAuthorDetailQuery;
using BookStore.Api.Aplication.AuthorOperations.Queries.GetAuthors;
using BookStore.Api.Aplication.BookOperations.Queries.GetBookDetail;
using BookStore.Api.Aplication.BookOperations.Queries.GetBooks;
using BookStore.Api.Aplication.GenreOperations.Queries.GetGenreDetail;
using BookStore.Api.Aplication.GenreOperations.Queries.GetGenres;
using BookStore.Api.Entities;
using static BookStore.Api.Aplication.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.Api.Aplication.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace BookStore.Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            
            
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name+" "+ src.LastName))
                .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("dd/MM/yyyy")));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name + " " + src.LastName))
                .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("dd/MM/yyyy")));
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>();


        }

    }
}

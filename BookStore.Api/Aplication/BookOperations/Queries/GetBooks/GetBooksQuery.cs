using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Aplication.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var books = _dbContext.Books.Include(x=> x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List< BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(books);
            return vm;
        }

    }


    public class BooksViewModel
    {

        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}

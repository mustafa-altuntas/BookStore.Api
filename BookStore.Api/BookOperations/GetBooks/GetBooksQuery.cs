using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public List<BooksViewModel> Handle()
        {
            var books = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List< BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in books)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });

            }
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

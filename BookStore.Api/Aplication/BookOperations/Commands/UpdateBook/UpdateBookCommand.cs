using BookStore.Api.DbOperations;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }


        public void Hadler()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Güncellenmek istenen kitap bulunamadı!");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _context.SaveChanges();
        }


        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }

    }
}

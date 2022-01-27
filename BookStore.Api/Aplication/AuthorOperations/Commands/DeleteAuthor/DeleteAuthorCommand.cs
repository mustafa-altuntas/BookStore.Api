using AutoMapper;
using BookStore.Api.DbOperations;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {

        private readonly BookStoreDbContext _context;
        public int AuthorID { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handler()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorID);
            if (author is null)
                throw new InvalidOperationException("Silmek istediğiniz yazar bulunamadı");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }



    }
}

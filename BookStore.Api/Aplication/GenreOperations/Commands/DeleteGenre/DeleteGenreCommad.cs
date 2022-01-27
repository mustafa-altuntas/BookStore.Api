using BookStore.Api.DbOperations;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommad
    {
        public int GenreID { get; set; }

        private readonly BookStoreDbContext _context;

        public DeleteGenreCommad(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreID);
            if(genre is null)
                throw new InvalidOperationException("Silmek istediğiniz kitap tütü bulunamadı.");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}

using AutoMapper;
using BookStore.Api.DbOperations;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        public int GenreID { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {

            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreID);
            if(genre is null)
                throw new InvalidOperationException("Güncellenmek istenen kitap türü bulunamadı.");

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreID))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");

            genre.Name = Model.Name.Trim() != default ? Model.Name:genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }

    }

    public class UpdateGenreModel
    {
        public string Name { get; set;}
        public bool IsActive { get; set; }
    }
}

using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var genra = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genra is not null)
                throw new InvalidOperationException("Eklemek istediğiniz kitap türü zaten mevcut.");
            var genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }


        public class CreateGenreModel
        {
            public string Name { get; set; }
        }
    }
}

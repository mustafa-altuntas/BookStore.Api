using AutoMapper;
using BookStore.Api.DbOperations;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreID { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreID);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü Bulunamadı");
            return _mapper.Map<GenreDetailViewModel>(genre);
        }


    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

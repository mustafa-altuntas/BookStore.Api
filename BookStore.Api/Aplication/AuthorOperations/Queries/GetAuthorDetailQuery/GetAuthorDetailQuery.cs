using AutoMapper;
using BookStore.Api.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int AuthorID { get; set; }

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handler()
        {
            var author = _context.Authors.Include(x => x.Book).SingleOrDefault(x=> x.Id == AuthorID);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }

    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string BookName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}

using AutoMapper;
using BookStore.Api.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Aplication.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handler()
        {
            var authors = _context.Authors.Include(x=> x.Book).OrderBy(x=>x.Id).ToList();
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }


    }


    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string BookName { get; set; }
        public string BirthDay { get; set; }
    }
}

using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel Model { get; set; }


        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handler()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Name == Model.Name && x.LastName == Model.LastName);
            if (author is not null)
                throw new InvalidOperationException("Kayırtlı bir yazarı tekrar kaydedemezsiniz.");
            var newAuthor = _mapper.Map<Author>(Model);
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
        }

    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public int BookId { get; set; }
    }
}

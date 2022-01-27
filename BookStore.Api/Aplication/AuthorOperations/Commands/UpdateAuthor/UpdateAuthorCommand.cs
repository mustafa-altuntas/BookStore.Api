using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System;
using System.Linq;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorID { get; set; }
        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handler()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorID);
            if (author is null)
                throw new InvalidOperationException("Güncellenecek yazar kaydı bulunamadı");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.BirthDay = Model.BirthDay != default ? Model.BirthDay : author.BirthDay;
            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;
            
            _context.SaveChanges();
        }



    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int BookId { get; set; }
    }
}

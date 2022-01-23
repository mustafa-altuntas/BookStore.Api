using BookStore.Api.BookOperations.CreateBook;
using BookStore.Api.BookOperations.DeleteBook;
using BookStore.Api.BookOperations.GetBookDetail;
using BookStore.Api.BookOperations.GetBooks;
using BookStore.Api.BookOperations.UpdateBook;
using BookStore.Api.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.Api.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.Api.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }



        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //        Id = 1,
        //        Title ="Lean Startup",
        //        GenreId = 1, // Personal Growth
        //        PageCount = 200,
        //        PublishDate = new DateTime(2001,06,12)
        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Title ="Herland",
        //        GenreId = 2, // Science Fiction
        //        PageCount = 250,
        //        PublishDate = new DateTime(2010,05,23)
        //    },
        //    new Book
        //    {
        //        Id = 3,
        //        Title ="Dune",
        //        GenreId = 1, // Science Fiction
        //        PageCount = 54,
        //        PublishDate = new DateTime(2001,12,21)
        //    }
        //};


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context);
            try
            {
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
        //    return book;
        //}



        // Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            try
            {
                command.Hadler();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            try
            {
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}

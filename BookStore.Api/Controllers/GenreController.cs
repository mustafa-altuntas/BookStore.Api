using AutoMapper;
using BookStore.Api.Aplication.GenreOperations.Commands.CreateGenre;
using BookStore.Api.Aplication.GenreOperations.Commands.DeleteGenre;
using BookStore.Api.Aplication.GenreOperations.Commands.UpdateGenre;
using BookStore.Api.Aplication.GenreOperations.Queries.GetGenreDetail;
using BookStore.Api.Aplication.GenreOperations.Queries.GetGenres;
using BookStore.Api.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Api.Aplication.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }


        [HttpGet("{id}")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreID = id;
            GenreDetailQueryValidator validator = new GenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }


        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model=newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreID = id;
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {


            DeleteGenreCommad command = new DeleteGenreCommad(_context);
            command.GenreID = id;
            DeleteGenreCommadValidator validator = new DeleteGenreCommadValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}

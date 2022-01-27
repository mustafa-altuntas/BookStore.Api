using FluentValidation;

namespace BookStore.Api.Aplication.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommadValidator: AbstractValidator<DeleteGenreCommad>
    {
        public DeleteGenreCommadValidator()
        {
            RuleFor(command => command.GenreID).GreaterThan(0);
        }
    }
}

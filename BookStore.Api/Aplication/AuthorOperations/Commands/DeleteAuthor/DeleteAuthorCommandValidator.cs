using FluentValidation;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorID).GreaterThan(0);
        }
    }
}

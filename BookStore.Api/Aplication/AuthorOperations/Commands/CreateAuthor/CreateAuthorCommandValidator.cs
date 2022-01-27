using FluentValidation;
using System;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthDay).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.BookId).GreaterThan(0);

        }

    }
}

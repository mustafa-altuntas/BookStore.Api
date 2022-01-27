using FluentValidation;
using System;

namespace BookStore.Api.Aplication.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorID).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthDay).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.BookId).GreaterThan(0);

        }
    }
}

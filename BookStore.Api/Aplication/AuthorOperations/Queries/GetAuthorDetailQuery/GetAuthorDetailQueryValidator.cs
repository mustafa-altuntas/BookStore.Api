using FluentValidation;

namespace BookStore.Api.Aplication.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQueryValidator: AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.AuthorID).GreaterThan(0);
        }
    }
}

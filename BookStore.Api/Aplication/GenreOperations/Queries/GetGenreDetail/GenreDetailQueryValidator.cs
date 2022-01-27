using FluentValidation;

namespace BookStore.Api.Aplication.GenreOperations.Queries.GetGenreDetail
{
    public class GenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreID).GreaterThan(0);
        }
    }
}

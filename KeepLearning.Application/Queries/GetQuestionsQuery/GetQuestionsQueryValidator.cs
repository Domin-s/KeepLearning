using FluentValidation;

namespace KeepLearning.Application.Queries.GetQuestionsQuery
{
    public class GetQuestionsQueryValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsQueryValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;

namespace KeepLearning.Domain.Queries.GetQuestions
{
    public class GetQuestionsQueryValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsQueryValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

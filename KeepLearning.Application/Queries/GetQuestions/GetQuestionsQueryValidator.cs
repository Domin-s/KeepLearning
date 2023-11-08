using FluentValidation;

namespace KeepLearning.Application.Queries.GetQuestions
{
    public class GetQuestionsQueryValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsQueryValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

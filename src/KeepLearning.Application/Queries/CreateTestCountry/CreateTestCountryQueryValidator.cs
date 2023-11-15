using FluentValidation;

namespace KeepLearning.Domain.Queries.CreateTestCountry
{
    public class CreateTestCountryQueryValidator : AbstractValidator<CreateTestCountryQuery>
    {
        public CreateTestCountryQueryValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

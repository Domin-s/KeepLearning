using FluentValidation;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateTestCountryCommandValidator : AbstractValidator<CreateTestCountryCommand>
    {
        public CreateTestCountryCommandValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

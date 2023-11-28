using FluentValidation;
using KeepLearning.Domain.Commands.CreateExamCountry;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateExamCountryCommandValidator : AbstractValidator<CreateExamCountryCommand>
    {
        public CreateExamCountryCommandValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;

using Domain.Commands.CreateExamCountry;

namespace Domain.Commands.CreateTestCountry
{
    public class CreateExamCountryCommandValidator : AbstractValidator<CreateExamCountryCommand>
    {
        public CreateExamCountryCommandValidator()
        {
            RuleFor(q => q.Continents).NotEmpty().NotNull();
        }
    }
}

using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.TestCountry.Command
{
    public class CreateTestCountryCommand : TestCountryBasic, IRequest<TestCountryDto>
    {
        public ToGuessType ToGuessType { get; set; }
    }
}

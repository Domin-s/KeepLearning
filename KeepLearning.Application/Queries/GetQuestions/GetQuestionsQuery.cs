using KeepLearning.Application.Models.Test.Country;
using MediatR;

namespace KeepLearning.Application.Queries.GetQuestions
{
    public class GetQuestionsQuery : TestCountryDto, IRequest<TestCountryDto>
    {
    }
}

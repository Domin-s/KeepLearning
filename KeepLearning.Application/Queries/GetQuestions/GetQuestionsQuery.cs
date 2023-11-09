using KeepLearning.Domain.Models.Test.Country;
using MediatR;

namespace KeepLearning.Domain.Queries.GetQuestions
{
    public class GetQuestionsQuery : TestCountryDto, IRequest<TestCountryDto>
    {
    }
}

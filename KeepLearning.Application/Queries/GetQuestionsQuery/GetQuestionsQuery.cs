using KeepLearning.Application.Models.Test.Country;
using MediatR;

namespace KeepLearning.Application.Queries.GetQuestionsQuery
{
    public class GetQuestionsQuery : TestCountryDto, IRequest<TestCountryDto>
    {
    }
}

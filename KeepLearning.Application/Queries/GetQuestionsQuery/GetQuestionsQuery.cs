using KeepLearning.Application.Models.TestCountry;
using MediatR;

namespace KeepLearning.Application.Queries.GetQuestionsQuery
{
    public class GetQuestionsQuery : TestCountryBase, IRequest<TestCountryDto>
    {
    }
}

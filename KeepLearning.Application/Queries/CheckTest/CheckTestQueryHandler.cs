using KeepLearning.Domain.Models.Result.Test;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.CheckTest
{
    public class CheckTestQueryHandler : IRequestHandler<CheckTestQuery, TestResultDto>
    {
        private readonly ICountryRepository _countryRepository;

        public CheckTestQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Task<TestResultDto> Handle(CheckTestQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("request");
            Console.WriteLine(request);

            throw new NotImplementedException();
        }
    }
}

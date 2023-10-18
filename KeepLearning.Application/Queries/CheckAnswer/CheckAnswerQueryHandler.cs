using KeepLearning.Application.Models.Enums;
using KeepLearning.Domain.Interfaces;
using MediatR;
using RestaurantAPI.Exceptions;

namespace KeepLearning.Application.Queries.CheckAnswer
{
    public class CheckAnswerQueryHandler : IRequestHandler<CheckAnswerQuery, bool>
    {
        private readonly ICountryRepository _countryRepository;

        public CheckAnswerQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> Handle(CheckAnswerQuery request, CancellationToken cancellationToken)
        {
            var country = await GetCountry(request);
            if (country == null)
            {
                throw new NotFoundException("Not found country");
            }

            var result = IsCorrectAnswer(country, request);

            return result;
        }

        private async Task<Domain.Enteties.Country?> GetCountry(CheckAnswerQuery query)
        {
            switch (query.GuessType)
            {
                case GuessType.Value.CapitalCity:
                    return await _countryRepository.GetByName(query.Question);

                case GuessType.Value.Country:
                    return await _countryRepository.GetByCapitalCity(query.Question);

                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsCorrectAnswer(Domain.Enteties.Country country, CheckAnswerQuery query)
        {
            switch (query.GuessType)
            {
                case Models.Enums.GuessType.Value.Country:
                    return country.Name.Equals(query.Answer);

                case Models.Enums.GuessType.Value.CapitalCity:
                    return country.CapitalCity.Equals(query.Answer);

                default: return false;
            }
        }
    }
}

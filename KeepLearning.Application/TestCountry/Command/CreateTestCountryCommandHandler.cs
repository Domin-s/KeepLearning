using AutoMapper;
using KeepLearning.Application.TestCountry.Models;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.TestCountry.Command
{
    internal class CreateTestCountryCommandHandler : IRequestHandler<CreateTestCountryCommand, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateTestCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryCommand request, CancellationToken cancellationToken)
        {
            var mappedContinent = request.Continents.Select(c => Continent.MapContinentToString(c));

            var countries = await _countryRepository.GetByContinents(mappedContinent);

            var test = CreateTest(request, countries);

            return test;
        }

        private TestCountryDto CreateTest(CreateTestCountryCommand command, IEnumerable<Domain.Enteties.Country> countries)
        {
            IEnumerable<QuestionDto> questions = CreateQuestions(command, countries.ToList());

            TestCountryDto test = new TestCountryDto()
            {
                Name = command.Name,
                NumberOfQuestion = command.NumberOfQuestion,
                Continents = command.Continents,
                Questions = questions,
            };

            return test;
        }

        private IEnumerable<QuestionDto> CreateQuestions(CreateTestCountryCommand command, List<Domain.Enteties.Country> countries)
        {
            var pickedUpCountries = new List<Domain.Enteties.Country>();

            while (pickedUpCountries.Count < command.NumberOfQuestion)
            {
                Domain.Enteties.Country randomCountry;
                PickRandomCountry(countries, out randomCountry);

                if (!pickedUpCountries.Contains(randomCountry))
                {
                    pickedUpCountries.Add(randomCountry);
                }
            }

            var questions = ToQuestionDto(pickedUpCountries, GuessType.GuessCapitalCity);

            return questions;
        }

        private void PickRandomCountry(List<Domain.Enteties.Country> countries, out Domain.Enteties.Country country)
        {
            var randomNumber = new Random().Next(0, countries.Count());
            country = countries[randomNumber];
        }

        private List<QuestionDto> ToQuestionDto(List<Domain.Enteties.Country> countries, GuessType guessType)
        {
            var questions = new List<QuestionDto>();

            foreach (var item in countries)
            {
                switch (guessType)
                {
                    case GuessType.GuessCapitalCity:
                        questions.Add(ToQuestionDto(item.Name, item.CapitalCity));
                        break;

                    case GuessType.GuessCountry:
                        questions.Add(ToQuestionDto(item.Name, item.CapitalCity));
                        break;
                }
            }

            return questions;
        }

        private QuestionDto ToQuestionDto(string questionText, string answerText)
         => new QuestionDto(questionText, answerText);
    }
}

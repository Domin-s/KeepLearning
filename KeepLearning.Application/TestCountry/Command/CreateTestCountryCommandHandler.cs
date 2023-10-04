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
            var mappedContinent = request.Continents.Select(c => ContinentClass.ContinentString(c));

            var countries = await _countryRepository.GetByContinents(mappedContinent);

            var test = CreateTest(request, countries);

            return test;
        }

        private TestCountryDto CreateTest(CreateTestCountryCommand command, IEnumerable<Domain.Enteties.Country> countries)
        {
            IEnumerable<Question> questions = CreateQuestions(command, countries.ToList());

            TestCountryDto test = new TestCountryDto()
            {
                Name = command.Name,
                NumberOfQuestion = command.NumberOfQuestion,
                Continents = command.Continents,
                Questions = questions,
            };

            return test;
        }

        private IEnumerable<Question> CreateQuestions(CreateTestCountryCommand command, List<Domain.Enteties.Country> countries)
        {
            var numbersOfQuestion = PickRandomNumbers(command.NumberOfQuestion, countries.Count());
            var questions = new List<Question>();
            
            for (var x = 0; x < command.NumberOfQuestion; x++)
            {
                var numberOfCountry = numbersOfQuestion[x];
                var question = new Question()
                {
                    CountryName = countries[numberOfCountry].Name,
                    CountryCapitalCity = countries[numberOfCountry].CapitalCity,
                };

                questions.Add(question);
            }

            return questions;
        }

        private List<int> PickRandomNumbers(int numberOfNumbers, int too)
        {
            var counter = 0;

            List<int> numbers = new List<int>();

            while(counter < numberOfNumbers)
            {
                var nextNumber = new Random().Next(0, too);
                
                if (!numbers.Contains(nextNumber))
                {
                    numbers.Add(nextNumber);
                    counter++;
                }
            }
            numbers.Sort();

            return numbers;
        }
    }
}

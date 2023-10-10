namespace KeepLearning.Application.Country
{
    public record Countries(IEnumerable<Domain.Enteties.Country> ListOfCountry)
    {
        public Domain.Enteties.Country GetRandomCountry()
        {
            var randomNumber = new Random().Next(0, ListOfCountry.Count());

            return ListOfCountry.ToList()[randomNumber];
        }

        public IEnumerable<Domain.Enteties.Country> GetRandomCountries(int numberOfQuestions)
        {
            var pickedUpCountries = new List<Domain.Enteties.Country>();

            while (pickedUpCountries.Count < numberOfQuestions)
            {
                Domain.Enteties.Country randomCountry = GetRandomCountry();

                if (!pickedUpCountries.Contains(randomCountry))
                {
                    pickedUpCountries.Add(randomCountry);
                }
            }

            return pickedUpCountries;
        }
    }
}

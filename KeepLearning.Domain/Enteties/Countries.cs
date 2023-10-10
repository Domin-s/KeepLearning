namespace KeepLearning.Application.Country
{
    public record Countries(IEnumerable<Domain.Enteties.Country> ListOfCountry)
    {
        public Domain.Enteties.Country GetRandomCountry()
        {
            var randomNumber = new Random().Next(0, ListOfCountry.Count());

            return ListOfCountry.ToList()[randomNumber];
        }
    }
}

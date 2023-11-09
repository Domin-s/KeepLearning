namespace KeepLearning.Domain.Models.Enums.Tests
{
    public class ContinentTests
    {
        [Theory]
        [InlineData(Continent.Name.Africa, "Africa")]
        [InlineData(Continent.Name.Asia, "Asia")]
        [InlineData(Continent.Name.Australia, "Australia")]
        [InlineData(Continent.Name.Europe, "Europe")]
        [InlineData(Continent.Name.NorthAmerica, "N. America")]
        [InlineData(Continent.Name.SouthAmerica, "S. America")]
        public void MapContinentNameToString_WhichCorrectContinentName_ResultShouldBeCorrectString(Continent.Name continentName, string result)
        {
            // act
            var continentString = Continent.MapContinentToString(continentName);

            // assert
            continentString.Should().Be(result);
        }

        [Theory]
        [InlineData("Africa", Continent.Name.Africa)]
        [InlineData("Asia", Continent.Name.Asia)]
        [InlineData("Australia", Continent.Name.Australia)]
        [InlineData("Europe", Continent.Name.Europe)]
        [InlineData("N. America", Continent.Name.NorthAmerica)]
        [InlineData("S. America", Continent.Name.SouthAmerica)]
        public void MapStringToContinentName_WhichCorrectString_ResultShouldBeCorrectContinentName(string continentString, Continent.Name result)
        {
            // act
            var continentName = Continent.MapStringToContinent(continentString);

            // assert
            continentName.Should().Be(result);
        }

        [Fact]
        public void MapStringToContinentName_WhichInorrectString_ResultShouldBeCorrectContinentName()
        {
            // aarrange
            var incorretString = "IncorrectString";

            // act
            Action action = () => Continent.MapStringToContinent(incorretString);

            // assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact()]
        public void GetAllLikeStrings_ShouldReturnAllContinetInList()
        {
            // arrange
            var continentsInString = new List<string>() { "Africa", "Asia", "Australia", "Europe", "N. America", "S. America" };

            // act
            var result = Continent.GetAllLikeStrings();

            // assert
            result.Should().HaveCount(6);
            result.Should().Contain(continentsInString);
        }
    }
}
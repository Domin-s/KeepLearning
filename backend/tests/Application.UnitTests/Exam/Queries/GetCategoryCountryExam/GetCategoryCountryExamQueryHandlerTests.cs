using Application.Exam.Queries.GetCategoryCountryExam;
using static Domain.Models.Enums.GuessType;

namespace Application.Country.Queries.GetCategoryCountryExam.UnitTest;

public class GetCategoryCountryExamQueryHandlerTests
{
    [Fact()]
    public async void Handle_GetAllCategoryCountryExam_ReturnCapitalCityAndCountry()
    {
        // arrange
        var expectedResult = new List<Category>() { Category.CapitalCity, Category.Country };
        var handler = new GetCategoryCountryExamQueryHandler();

        // act
        var result = await handler.Handle(new GetCategoryCountryExamQuery(), CancellationToken.None);

        // assert
        result.Should().Contain(expectedResult);
    }
}
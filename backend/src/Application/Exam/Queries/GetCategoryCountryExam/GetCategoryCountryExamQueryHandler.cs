using Domain.Models.Enums;
using static Domain.Models.Enums.GuessType;

namespace Application.Exam.Queries.GetCategoryCountryExam;

public class GetCategoryCountryExamQueryHandler : IRequestHandler<GetCategoryCountryExamQuery, IEnumerable<Category>>
{
    public GetCategoryCountryExamQueryHandler()
    {
    }

    public async Task<IEnumerable<Category>> Handle(GetCategoryCountryExamQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => GuessType.GetAllLikeStrings());
    }
}

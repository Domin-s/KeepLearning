﻿using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using MediatR;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQuery : IRequest<QuestionDto>
    {
        public GuessType.Category GuessType { get; set; }
        public Continent.Name Continent { get; set; }
    }
}

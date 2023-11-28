﻿using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Question.Queries.CheckAnswer
{
    public class CheckAnswerQuery : IRequest<bool>
    {
        public string Question { get; set; } = default!;
        public string Answer { get; set; } = default!;
        public GuessType.Category Category { get; set; }
    }
}
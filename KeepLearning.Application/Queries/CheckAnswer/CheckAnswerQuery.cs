﻿using KeepLearning.Application.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Queries.CheckAnswer
{
    public class CheckAnswerQuery : IRequest<bool>
    {
        public string Question { get; set; } = default!;
        public string Answer { get; set; } = default!;
        public GuessType.Value GuessType { get; set; }
    }
}
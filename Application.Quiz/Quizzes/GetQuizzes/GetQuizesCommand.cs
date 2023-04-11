using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.GetQuizzes
{
    public class GetQuizesCommand : IRequest<GetQuizesResponse>
    {
        public string? Author { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class AddQuestionCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;

        public List<string> Answers = new();

        public int CorrectAnswerIndex { get; set; }

        public int TimeoutInSeconds { get; set; }
    }
}

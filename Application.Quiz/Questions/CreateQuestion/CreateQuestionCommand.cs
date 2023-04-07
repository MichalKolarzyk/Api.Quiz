using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<CreateQuestionResponse>
    {
        public string Question { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }

        public bool IsPrivate { get; set; } = false;

        public string Category { get; set; } = string.Empty;

        public string DefaultLanugage { get; set; } = string.Empty;
    }
}

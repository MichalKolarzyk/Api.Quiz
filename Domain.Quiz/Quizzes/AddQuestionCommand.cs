using FluentValidation;
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
        public Guid QuizId { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }

        public int TimeoutInSeconds { get; set; }
    }

    public class AddQuestionCommandValidator : AbstractValidator<AddQuestionCommand>
    {
        public AddQuestionCommandValidator()
        {
            RuleFor(x => x.CorrectAnswerIndex)
                .LessThan(x => x.Answers.Count);
        }
    }
}

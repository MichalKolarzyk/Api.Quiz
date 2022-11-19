using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class CreateQuizCommand : IRequest<QuizAggregate>
    {
        public string Name { get; set; } = string.Empty;

        public Guid ThemeId { get; set; }

        public QuestionOrderType QuestionOrderType { get; set; }
    }

    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(10);
            RuleFor(c => c.ThemeId).NotEmpty();
        }
    }
}

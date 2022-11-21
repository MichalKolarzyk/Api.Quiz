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

        public Guid WorkspaceId { get; set; }

        public Guid ThemeId { get; set; }
    }

    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
            RuleFor(q => q.Name).MinimumLength(10);
            RuleFor(q => q.ThemeId).NotEmpty();
            RuleFor(q => q.WorkspaceId).NotEmpty();
        }
    }
}

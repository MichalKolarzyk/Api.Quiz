using Domain.Quiz.Quizzes;
using FluentValidation;
using MediatR;

namespace Application.Quiz.Quizzes
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

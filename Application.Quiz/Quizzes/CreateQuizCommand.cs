using Domain.Quiz.Quizzes;
using FluentValidation;
using MediatR;

namespace Application.Quiz.Quizzes
{
    public class CreateQuizCommand : IRequest<Domain.Quiz.Quizzes.QuizAggregate>
    {
        public string Name { get; set; } = string.Empty;
    }
}

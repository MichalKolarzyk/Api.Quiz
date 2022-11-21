using Application.Quiz.Database;
using Domain.Quiz.Quizzes;
using MediatR;


namespace Application.Quiz.Quiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, QuizAggregate>
    {
        IRepository<QuizAggregate> _quizRepository;

        public CreateQuizCommandHandler(IRepository<QuizAggregate> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<QuizAggregate> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizAggregate(request.ThemeId, request.WorkspaceId);

            var quizAggregate = await _quizRepository.InsertOne(quiz);

            return quizAggregate;
        }
    }
}

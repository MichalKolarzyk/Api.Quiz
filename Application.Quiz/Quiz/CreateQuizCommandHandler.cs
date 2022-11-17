using Domain.Quiz.Quizzes;
using Infrastructure.Quiz.Databases;
using MediatR;


namespace Application.Quiz.Quiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand>
    {
        IRepository<QuizAggregate> _quizRepository;

        public CreateQuizCommandHandler(IRepositoryFactory repositoryFactory)
        {
            _quizRepository = repositoryFactory.Create<QuizAggregate>();
        }

        public Task<Unit> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizAggregate
            {
                questionOrderType = request.QuestionOrderType,
                ThemeId = request.ThemeId,
            };
            _quizRepository.InsertOne(quiz);

            return Unit.Task;
        }
    }
}

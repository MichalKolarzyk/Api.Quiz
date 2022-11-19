using Application.Quiz.Database;
using Domain.Quiz.Quizzes;
using MediatR;


namespace Application.Quiz.Quiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, QuizAggregate>
    {
        IRepository<QuizAggregate> _quizRepository;

        public CreateQuizCommandHandler(IRepositoryFactory repositoryFactory)
        {
            _quizRepository = repositoryFactory.Create<QuizAggregate>();
        }

        public async Task<QuizAggregate> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizAggregate
            {
                questionOrderType = request.QuestionOrderType,
                ThemeId = request.ThemeId,
            };
            var quizAggregate = await _quizRepository.InsertOne(quiz);

            return quizAggregate;
        }
    }
}

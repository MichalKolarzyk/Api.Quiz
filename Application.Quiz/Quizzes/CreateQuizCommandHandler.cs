using Application.Quiz.Database;
using Application.Quiz.Services;
using Domain.Quiz.Quizzes;
using MediatR;


namespace Application.Quiz.Quizzes
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, Domain.Quiz.Quizzes.QuizAggregate>
    {
        private readonly IRepository<QuizAggregate> _quizRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public CreateQuizCommandHandler(IRepository<Domain.Quiz.Quizzes.QuizAggregate> quizRepository, ICurrentIdentity currentIdentity)
        {
            _quizRepository = quizRepository;
            _currentIdentity = currentIdentity;
        }

        public async Task<QuizAggregate> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizAggregate(request.Name, _currentIdentity.AccountId ?? Guid.Empty);

            var quizAggregate = await _quizRepository.InsertAsync(quiz);

            return quizAggregate;
        }
    }
}

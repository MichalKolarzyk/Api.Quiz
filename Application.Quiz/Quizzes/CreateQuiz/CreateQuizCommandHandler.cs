using Application.Quiz.Database;
using Application.Quiz.Services;
using Domain.Quiz.Quizzes;
using MediatR;


namespace Application.Quiz.Quizzes.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreateQuizResponse>
    {
        private readonly IRepository<QuizAggregate> _quizRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public CreateQuizCommandHandler(IRepository<QuizAggregate> quizRepository, ICurrentIdentity currentIdentity)
        {
            _quizRepository = quizRepository;
            _currentIdentity = currentIdentity;
        }

        public async Task<CreateQuizResponse> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new QuizAggregate(request.Name, _currentIdentity.AccountId ?? Guid.Empty);

            var quizAggregate = await _quizRepository.InsertAsync(quiz);

            return new CreateQuizResponse
            {
                Id = quizAggregate.Id,
            };
        }
    }
}

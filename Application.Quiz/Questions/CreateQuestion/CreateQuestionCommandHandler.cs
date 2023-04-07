using Application.Quiz.Database;
using Application.Quiz.Services;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionResponse>
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public CreateQuestionCommandHandler(IRepository<Question> questionRepository, ICurrentIdentity currentIdentity)
        {
            _questionRepository = questionRepository;
            _currentIdentity = currentIdentity;
        }

        public async Task<CreateQuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = new Question(request.Question,
                request.Answers,
                request.CorrectAnswerIndex,
                request.IsPrivate,
                request.Category,
                request.DefaultLanugage,
                _currentIdentity.AccountId ?? Guid.Empty);

            await _questionRepository.InsertAsync(question);
            return new CreateQuestionResponse
            {
                Id = question.Id,
            };
        }
    }
}

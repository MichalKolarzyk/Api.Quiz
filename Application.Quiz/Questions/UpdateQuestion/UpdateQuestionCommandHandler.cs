using Application.Quiz.Database;
using Application.Quiz.Services;
using Domain.Quiz.Exceptions;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public UpdateQuestionCommandHandler(IRepository<Question> questionRepository, ICurrentIdentity currentIdentity)
        {
            _questionRepository = questionRepository;
            _currentIdentity = currentIdentity;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = await _questionRepository.GetAsync(q => q.Id == request.Id);

            if (_currentIdentity.AccountId != question.AuthorId)
                throw Result.DomainException(new Error("User is not an autohor of the question.", "", 403));

            question.UpdateQuestion(request.Question, request.Answers, request.CorrectAnswerIndex, request.IsPrivate, request.Category, request.DefaultLanugage);
            await _questionRepository.UpdateAsync(question);
            return Unit.Value;
        }
    }
}

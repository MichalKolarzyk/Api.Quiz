using Application.Quiz.Database;
using Application.Quiz.ReferenceItems;
using Application.Quiz.Services;
using Domain.Quiz.Exceptions;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionResponse>
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<ReferenceItem> _referenceItemsRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public CreateQuestionCommandHandler(IRepository<Question> questionRepository, ICurrentIdentity currentIdentity, IRepository<ReferenceItem> referenceItemsRepository)
        {
            _questionRepository = questionRepository;
            _currentIdentity = currentIdentity;
            _referenceItemsRepository = referenceItemsRepository;
        }

        public async Task<CreateQuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var categories = await _referenceItemsRepository.GetListAsync(i => i.Key == "Category");

            if(!string.IsNullOrEmpty(request.Category) && !categories.Any(c => c.Value == request.Category))
                throw Result.DomainException(new Error("Category is not correct", "Category", 403));

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

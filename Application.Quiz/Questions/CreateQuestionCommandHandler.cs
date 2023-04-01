using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionResponse>
    {
        private readonly IRepository<Question> _questionRepository;

        public CreateQuestionCommandHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<CreateQuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = new Question(request.Question, request.Answers, request.CorrectAnswerIndex, request.IsPrivate, request.Category, request.DefaultLanugage);
            await _questionRepository.InsertAsync(question);
            return new CreateQuestionResponse
            {
                Id = question.Id,
            };
        }
    }
}

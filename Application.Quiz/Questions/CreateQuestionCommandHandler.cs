using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand>
    {
        private readonly IRepository<QuestionAggregate> _questionRepository;

        public CreateQuestionCommandHandler(IRepository<QuestionAggregate> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            QuestionAggregate question = new QuestionAggregate(request.WorkspaceId, request.Description, request.Answers, request.CorrectAnswerIndex);
            await _questionRepository.InsertAsync(question);
            return Unit.Value;
        }
    }
}

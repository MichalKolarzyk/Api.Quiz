using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IRepository<QuestionAggregate> _questionRepository;

        public UpdateQuestionCommandHandler(IRepository<QuestionAggregate> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            QuestionAggregate question = await _questionRepository.GetAsync(q => q.Id == request.Id);
            question.ChangeDescription(request.Description);
            question.ChangeWorkspace(request.WorkspaceId);
            question.ChangeAnswers(request.Answers, request.CorrectAnswerIndex);
            await _questionRepository.UpdateAsync(question);
            return Unit.Value;
        }
    }
}

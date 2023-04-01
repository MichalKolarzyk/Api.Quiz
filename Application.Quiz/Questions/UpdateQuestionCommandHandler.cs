using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;

namespace Application.Quiz.Questions
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IRepository<Question> _questionRepository;

        public UpdateQuestionCommandHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = await _questionRepository.GetAsync(q => q.Id == request.Id);
            question.DefaultLanugage = request.DefaultLanugage;
            question.Description = request.Question;
            question.Answers= request.Answers;
            question.CorrectAnswerIndex = request.CorrectAnswerIndex;
            question.Category= request.Category;
            await _questionRepository.UpdateAsync(question);
            return Unit.Value;
        }
    }
}

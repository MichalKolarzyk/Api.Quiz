using Domain.Quiz.Quizzes;
using MediatR;

namespace Application.Quiz.Database
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand>
    {
        private readonly IRepository<QuizAggregate> _quizRepository;

        public AddQuestionCommandHandler(IRepository<QuizAggregate> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetOne(x => x.Id == request.QuizId);
            quiz.Questions.Add(new Question
            {
                Id = Guid.NewGuid(),
                CorrectAnswerIndex = request.CorrectAnswerIndex,
                Description = request.Description,
                Answers = request.Answers,
            });

            await _quizRepository.ReplaceOne(quiz);
            return Unit.Value;
        }
    }
}

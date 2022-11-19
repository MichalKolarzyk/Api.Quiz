using Domain.Quiz.Quizzes;
using Infrastructure.Quiz.Databases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quiz
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand>
    {
        private readonly IRepository<QuizAggregate> _quizRepository;

        public AddQuestionCommandHandler(IRepositoryFactory repositoryFactory)
        {
            _quizRepository = repositoryFactory.Create<QuizAggregate>();
        }

        public async Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetOne(x => x.Id == request.QuizId);
            quiz.Questions.Add(new Question
            {
                Id = Guid.NewGuid(),
                CorrectAnswerIndex = request.CorrectAnswerIndex,
                Description = request.Description,
                TimeoutInSeconds = request.TimeoutInSeconds,
                Answers = request.Answers,
            });

            await _quizRepository.ReplaceOne(quiz);
            return Unit.Value;
        }
    }
}

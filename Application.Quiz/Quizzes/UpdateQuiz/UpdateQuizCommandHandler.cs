using Application.Quiz.Database;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand>
    {
        private readonly IRepository<QuizAggregate> _quizRepository;

        public UpdateQuizCommandHandler(IRepository<QuizAggregate> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetAsync(q => q.Id == request.QuizId);
            quiz.UpdateQuestions(request.QuestionIds);

            await _quizRepository.UpdateAsync(quiz);
            return Unit.Value;
        }
    }
}

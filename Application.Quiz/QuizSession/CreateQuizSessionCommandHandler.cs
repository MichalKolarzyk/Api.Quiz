using Application.Quiz.Database;
using Domain.Quiz.QuizSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.QuizSession
{
    public class CreateQuizSessionCommandHandler : IRequestHandler<CreateQuizSessionCommand>
    {
        private readonly IRepository<QuizSessionAggregate> _quizSessionRepository;

        public CreateQuizSessionCommandHandler(IRepository<QuizSessionAggregate> quizSessionRepository)
        {
            _quizSessionRepository = quizSessionRepository;
        }

        public async Task<Unit> Handle(CreateQuizSessionCommand request, CancellationToken cancellationToken)
        {
            var quizSession = new QuizSessionAggregate(
                request.QuizId, 
                request.SessionOwnerId, 
                request.StartTime, 
                request.TimeForQuestionInSecounds, 
                request.QuizPickQuestionType);

            await _quizSessionRepository.InsertAsync(quizSession);
            return Unit.Value;
        }
    }
}

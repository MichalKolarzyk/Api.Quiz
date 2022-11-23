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
    public class StartQuizSessionCommandHandler : IRequestHandler<StartQuizSessionCommand>
    {
        private readonly IRepository<QuizSessionAggregate> _quizSessionRepository;

        public StartQuizSessionCommandHandler(IRepository<QuizSessionAggregate> quizSessionRepository)
        {
            _quizSessionRepository = quizSessionRepository;
        }

        public async Task<Unit> Handle(StartQuizSessionCommand request, CancellationToken cancellationToken)
        {
            var quizSession = await _quizSessionRepository.GetAsync(q => q.Id == request.QuizSessionId);
            quizSession.Start();
            await _quizSessionRepository.UpdateAsync(quizSession);

            return Unit.Value;
        }
    }
}

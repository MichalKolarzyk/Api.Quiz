using Application.Quiz.Database;
using Application.Quiz.QuizSession.ExtenrnalEvents;
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
        private readonly ISessionComunicator _sessionComunicator;

        public CreateQuizSessionCommandHandler(IRepository<QuizSessionAggregate> quizSessionRepository, ISessionComunicator sessionComunicator)
        {
            _quizSessionRepository = quizSessionRepository;
            _sessionComunicator = sessionComunicator;
        }

        public async Task<Unit> Handle(CreateQuizSessionCommand request, CancellationToken cancellationToken)
        {
            var quizSession = new QuizSessionAggregate(
                request.QuizId, 
                request.SessionOwnerId, 
                request.StartTime, 
                request.TimeForQuestionInSecounds, 
                request.QuestionAmount, 
                request.QuizPickQuestionType);

            await _sessionComunicator.SendMessageToAll($"quiz session created {quizSession.Id}");

            await _quizSessionRepository.InsertAsync(quizSession);
            return Unit.Value;
        }
    }
}

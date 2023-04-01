using Application.Quiz.Database;
using Application.Quiz.QuizSession.ExtenrnalEvents;
using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;
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
        private readonly IRepository<QuizAggregate> _quizRepository;
        //private readonly ISessionComunicator _sessionComunicator;

        public CreateQuizSessionCommandHandler(IRepository<QuizSessionAggregate> quizSessionRepository, IRepository<QuizAggregate> quizRepository)
        {
            _quizSessionRepository = quizSessionRepository;
           // _sessionComunicator = sessionComunicator;
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(CreateQuizSessionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetAsync(q => q.Id == request.QuizId);
            var quizSession = new QuizSessionAggregate(
                quiz, 
                request.SessionOwnerId, 
                request.StartTime, 
                request.TimeForQuestionInSecounds, 
                request.QuestionAmount, 
                request.QuizPickQuestionType);

            //await _sessionComunicator.SendMessageToAll($"quiz session created {quizSession.Id}");

            await _quizSessionRepository.InsertAsync(quizSession);
            return Unit.Value;
        }
    }
}

using Application.Quiz.Database;
using Application.Quiz.ExtenrnalEvents;
using Domain.Quiz.QuizSession;
using Domain.Quiz.QuizSession.DomainEvents;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.QuizSession.DomainEventHandlers
{
    public class QuizSessionStartedDomainEventHandler : INotificationHandler<QuizSessionStartedDomainEvent>
    {
        //private readonly ISessionStartedExternalEvent _sessionStartedExternalEvent;

        public QuizSessionStartedDomainEventHandler()
        {
            //_sessionStartedExternalEvent = sessionStartedExternalEvent;
        }

        public Task Handle(QuizSessionStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            //_sessionStartedExternalEvent.Publish(notification);
            return Task.CompletedTask;
        }
    }
}

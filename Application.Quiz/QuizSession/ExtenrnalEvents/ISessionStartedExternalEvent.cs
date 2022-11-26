using Domain.Quiz.QuizSession.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.ExtenrnalEvents
{
    public interface ISessionStartedExternalEvent
    {
        public void Publish(QuizSessionStartedDomainEvent quizSessionStartedDomainEvent);
    }
}

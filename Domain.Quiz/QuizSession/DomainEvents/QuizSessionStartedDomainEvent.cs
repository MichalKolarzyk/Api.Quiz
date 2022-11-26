using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.QuizSession.DomainEvents
{
    public class QuizSessionStartedDomainEvent : DomainEvent
    {
        public Guid QuizSessionId { get; set; }
        public int QuestionAmount { get; set; }
        public int TimeForSingleQuestion { get; set; }
    }
}

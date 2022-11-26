using Application.Quiz.ExtenrnalEvents;
using BaseImplementationLib.RabbitMq;
using Domain.Quiz.QuizSession.DomainEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.ExternalEvents
{
    public class SessionStartedExternalEvent : ISessionStartedExternalEvent
    {
        private readonly ProducerBase<AppEventMessage> _producer;

        public SessionStartedExternalEvent(ProducerBase<AppEventMessage> producer)
        {
            _producer = producer;
        }

        public void Publish(QuizSessionStartedDomainEvent quizSessionStartedDomainEvent)
        {
            _producer.SendMessage(new AppEventMessage
            {
                EventsAmount = quizSessionStartedDomainEvent.QuestionAmount,
                RepeatAfterSecounts = quizSessionStartedDomainEvent.TimeForSingleQuestion,
                Start = DateTime.Now,
                Payload = JsonConvert.SerializeObject(quizSessionStartedDomainEvent)
            }, "StartQuizExchange");
        }

        public class AppEventMessage
        {
            public DateTime Start { get; set; }
            public int EventsAmount { get; set; } = 1;
            public int RepeatAfterSecounts { get; set; }
            public string Payload { get; set; } = string.Empty;
        }
    }
}

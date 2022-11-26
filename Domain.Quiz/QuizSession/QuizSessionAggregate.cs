using Domain.Quiz.Abstracts;
using Domain.Quiz.QuizSession.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.QuizSession
{
    public class QuizSessionAggregate : AggregateRoot
    {
        public Guid QuizId { get; set; }
        public Guid SessionOwnerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ActualStartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int TimeForQuestionInSecounds { get; set; }
        public int QuestionAmount { get; set; }
        public State QuizState { get; set; }
        public PickQuestionType QuizPickQuestionType { get; set; }

        public QuizSessionAggregate(Guid quizId, Guid sessionOwnerId, DateTime startTime, int timeForQuestionInSecounds, int questionAmount, PickQuestionType quizPickQuestionType)
        {
            QuizId = quizId;
            SessionOwnerId = sessionOwnerId;
            StartTime = startTime;
            TimeForQuestionInSecounds = timeForQuestionInSecounds;
            QuestionAmount = questionAmount;
            QuizPickQuestionType = quizPickQuestionType;

            QuizState = State.Ready;
        }


        public enum PickQuestionType
        {
            OneByOne,
            Random,
        }

        public enum State
        {
            Ready,
            Started,
            Finished,
        }

        public void Start()
        {
            this.QuizState = State.Started;
            ActualStartTime = DateTime.Now;

            AddDomainEvent(new QuizSessionStartedDomainEvent
            {
                QuizSessionId = this.Id,
                TimeForSingleQuestion = this.TimeForQuestionInSecounds,
                QuestionAmount = this.QuestionAmount,
            });
        }

        public void Finish()
        {
            this.QuizState = State.Finished;
            FinishTime = DateTime.Now;
        }
    }
}

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
        public List<QuizSessionQuesion> QuizSessionQuesions { get; set; }

        public QuizSessionAggregate(Guid quizId, Guid sessionOwnerId, DateTime startTime, int timeForQuestionInSecounds, int questionAmount, PickQuestionType quizPickQuestionType)
        {
            QuizId = quizId;
            SessionOwnerId = sessionOwnerId;
            StartTime = startTime;
            TimeForQuestionInSecounds = timeForQuestionInSecounds;
            QuestionAmount = questionAmount;
            QuizPickQuestionType = quizPickQuestionType;

            QuizSessionQuesions = new List<QuizSessionQuesion>();
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

        public void AddQuizSessionQuestion(Guid questionId, int timeForQuestionInSeconds)
        {
            this.QuizSessionQuesions.Add(new QuizSessionQuesion(questionId));
        }

        public void StartSessionQuestion(Guid sessionQuestionId)
        {
            var sessionQuestion = this.QuizSessionQuesions.FirstOrDefault(q => q.Id == sessionQuestionId);
            
            if (sessionQuestion == null)
                throw new Exception("There is no sesion question with this id");

            sessionQuestion.State = QuizSessionQuesion.QuizSessionQuesionState.Started;
        }

        public void FinishSessionQuestion(Guid sessionQuestionId)
        {
            var sessionQuestion = this.QuizSessionQuesions.FirstOrDefault(q => q.Id == sessionQuestionId);

            if (sessionQuestion == null)
                throw new Exception("There is no sesion question with this id");

            sessionQuestion.State = QuizSessionQuesion.QuizSessionQuesionState.Finished;

            if(this.QuizSessionQuesions.Count == this.QuestionAmount && this.QuizSessionQuesions.All(q => q.State == QuizSessionQuesion.QuizSessionQuesionState.Finished))
            {
                this.QuizState = State.Finished;
                FinishTime = DateTime.Now;
            }

        }

        public void AnswerTheQuestion(Guid userProfileId, Guid questionId, string answer)
        {
            var quizQuestion = this.QuizSessionQuesions.FirstOrDefault(q => q.QuestionId == questionId);
            
            if (quizQuestion == null)
                throw new Exception($"There is no question with Id {questionId} in quiz session {this.Id}");

            if (quizQuestion.State != QuizSessionQuesion.QuizSessionQuesionState.Started)
                throw new Exception($"Time is out for question {quizQuestion.Id}");

            quizQuestion.QuizSessionQuestionAnswers.Add(new QuizSessionQuestionAnswer
            {
                Answer = answer,
                UserProfileId = userProfileId,
            });
        }
    }
}

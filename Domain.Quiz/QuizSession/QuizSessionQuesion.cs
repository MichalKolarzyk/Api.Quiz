using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.QuizSession
{
    public class QuizSessionQuesion : Entity
    {
        public QuizSessionQuesion(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Guid QuestionId { get; set; }
        public QuizSessionQuesionState State;
        public List<QuizSessionQuestionAnswer> QuizSessionQuestionAnswers { get; set; } = new List<QuizSessionQuestionAnswer>();

        public enum QuizSessionQuesionState
        {
            Created,
            Started,
            Finished,
        }
    }
}

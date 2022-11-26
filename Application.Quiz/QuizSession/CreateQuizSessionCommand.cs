using Domain.Quiz.QuizSession;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.QuizSession
{
    public class CreateQuizSessionCommand : IRequest
    {
        public Guid QuizId { get; set; }
        public Guid SessionOwnerId { get; set; }
        public DateTime StartTime { get; set; }
        public int TimeForQuestionInSecounds { get; set; }
        public int QuestionAmount { get; set; }
        public QuizSessionAggregate.PickQuestionType QuizPickQuestionType { get; set; }
    }
}

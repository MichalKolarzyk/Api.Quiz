using Domain.Quiz.QuizSession;

namespace Api.Quiz.Controllers.QuizSessionControllers
{
    public class CreateQuizSessionDto
    {
        public Guid QuizId { get; set; }
        public DateTime StartTime { get; set; }
        public int TimeForQuestionInSecounds { get; set; }
        public int QuestionAmount { get; set; }
        public QuizSessionAggregate.PickQuestionType QuizPickQuestionType { get; set; }
    }
}

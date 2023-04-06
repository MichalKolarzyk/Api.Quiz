using Domain.Quiz.Quizzes;

namespace Application.Quiz.Quizzes
{
    public class GetQuizesResponse
    {
        public List<Domain.Quiz.Quizzes.QuizAggregate> Quizes { get; set; } = new List<Domain.Quiz.Quizzes.QuizAggregate>();
        public long Count { get; set; }
    }
}

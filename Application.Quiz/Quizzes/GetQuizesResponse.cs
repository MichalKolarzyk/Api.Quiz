using Domain.Quiz.Quizzes;

namespace Application.Quiz.Quizzes
{
    public class GetQuizesResponse
    {
        public List<QuizAggregate> Quizes { get; set; } = new List<QuizAggregate>();
    }
}

using Domain.Quiz.Quizzes;

namespace Application.Quiz.Quizzes.GetQuizzes
{
    public class GetQuizesResponse
    {
        public List<Quiz> Quizes { get; set; } = new List<Quiz>();
        public long Count { get; set; }

        public class Quiz
        {
            public Guid Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public string Author { get; set; } = string.Empty;

            public long QuestionCount { get; set; }

            public List<string> Category { get; set; } = new List<string>();
        }
    }


}

using Application.Quiz.Database;

namespace Application.Quiz.Aggregations
{
    public class QuestionAggregationModel : IAggregationModel
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }

        public bool IsPrivate { get; set; } = false;

        public string Category { get; set; } = string.Empty;

        public string DefaultLanugage { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}

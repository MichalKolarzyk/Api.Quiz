using Domain.Quiz.Abstracts;
using Domain.Quiz.Exceptions;

namespace Domain.Quiz.Questions
{
    public class Question : AggregateRoot
    {
        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }

        public bool IsPrivate { get; set; } = false;

        public string Category { get; set; } = string.Empty;

        public string DefaultLanugage { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public Question()
        {
        }

        public Question(string description, List<string> answers, int correctAnswerIndex, bool isPrivate, string category, string defualtLanguage, Guid authorId)
        {
            UpdateQuestion(description, answers, correctAnswerIndex, isPrivate, category, defualtLanguage);
            AuthorId = authorId;
        }

        public void UpdateQuestion(string description, List<string> answers, int correctAnswerIndex, bool isPrivate, string category, string defualtLanguage)
        {
            var result = new Result();

            if (string.IsNullOrEmpty(description))
                result.AddError(new Error("You have to provide question", nameof(Description), 403));

            if (answers.Count < 3)
                result.AddError(new Error("You have to provide at least 3 answers", nameof(Answers), 403));

            if (answers.Any(a => string.IsNullOrWhiteSpace(a)))
                result.AddError(new Error("Some answers are empty", nameof(Answers), 403));

            if (correctAnswerIndex < 0 || correctAnswerIndex >= answers.Count)
                result.AddError(new Error("Correct answer index is not set", nameof(CorrectAnswerIndex), 403));

            if (result.HasErrors)
                throw result.ToException();

            Description = description;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            IsPrivate = isPrivate;
            Category = category;
            DefaultLanugage = defualtLanguage;
        }
    }
}

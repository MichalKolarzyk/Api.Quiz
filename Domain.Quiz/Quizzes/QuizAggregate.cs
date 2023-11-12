using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class QuizAggregate : AggregateRoot
    {
        public QuizAggregate(){}

        public QuizAggregate(string name, Guid authorId)
        {
            Name = name;
            AuthorId = authorId;
        }

        public List<Guid> QuestionIds { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; } = Guid.Empty;

        public void UpdateQuestions(List<Guid> questionIds)
        {
            QuestionIds = questionIds;
        }
    }
}

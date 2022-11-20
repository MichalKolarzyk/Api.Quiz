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
        public List<Question> Questions { get; set; } = new();

        public Guid ThemeId { get; set; }

        public QuestionOrderType questionOrderType { get; set; }
    }
}

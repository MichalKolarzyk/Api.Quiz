using Application.Quiz.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.Models
{
    public class QuizAggregationModel : IAggregationModel
    {
        public Guid Id { get; set; }

        public List<Guid> QuestionIds { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}

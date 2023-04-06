using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes
{
    public class QuizDto
    {
        public List<Guid> QuestionIds { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public long QuestionCount { get; set; }
    }
}

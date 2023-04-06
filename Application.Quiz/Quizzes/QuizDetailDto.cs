using Application.Quiz.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes
{
    public class QuizDetailDto
    {
        public List<QuestionDto> Questions { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; }
    }
}

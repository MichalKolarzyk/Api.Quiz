using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }
    }
}

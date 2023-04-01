using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Question(string description, List<string> answers, int correctAnswerIndex, bool isPrivate, string category, string defualtLanguage)
        {
            Description = description;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            IsPrivate = isPrivate;
            Category = category;
            DefaultLanugage = defualtLanguage;
        }
    }
}

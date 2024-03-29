﻿using Application.Quiz.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.GetQuiz
{
    public class GetQuizResponse
    {
        public List<Question> Questions { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public class Question
        {
            public Guid Id { get; set; }

            public string Description { get; set; } = string.Empty;

            public string Category { get; set; } = string.Empty;

            public string DefaultLanugage { get; set; } = string.Empty;

            public string Author { get; set; } = string.Empty;
        }
    }
}

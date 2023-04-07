using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions.GetQuestions
{
    public class GetQuestionsResponse
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public long Count { get; set; }
        public long PagesCount { get; set; }

        public class Question
        {
            public Guid Id { get; set; }

            public string Description { get; set; } = string.Empty;

            public bool IsPrivate { get; set; } = false;

            public string Category { get; set; } = string.Empty;

            public string DefaultLanugage { get; set; } = string.Empty;

            public string Author { get; set; } = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class GetQuestionsResponse
    {
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        public long Count { get; set; }
        public long PagesCount { get; set; }
    }
}

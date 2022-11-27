using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.QuizSession
{
    public class QuizSessionQuestionAnswer
    {
        public Guid UserProfileId { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
}

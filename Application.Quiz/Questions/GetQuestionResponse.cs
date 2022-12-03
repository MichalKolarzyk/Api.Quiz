using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class GetQuestionResponse
    {
        public List<GetQuestionDto> Questions { get; set; } = new List<GetQuestionDto>();
    }
}

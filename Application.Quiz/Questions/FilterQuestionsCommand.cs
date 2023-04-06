using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class FilterQuestionsCommand : IRequest<GetQuestionsResponse>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPrivate { get; set; }
        public string Author { get; set; }
    }
}

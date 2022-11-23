using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.QuizSession
{
    public class StartQuizSessionCommand : IRequest
    {
        public Guid QuizSessionId { get; set; }
    }
}

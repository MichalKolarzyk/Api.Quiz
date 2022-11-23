using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes
{
    public class UpdateQuizCommand : IRequest
    {
        public Guid QuizId { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }
}

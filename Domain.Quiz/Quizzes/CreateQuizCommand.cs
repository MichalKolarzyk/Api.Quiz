using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class CreateQuizCommand : IRequest<QuizAggregate>
    {
        public string Name { get; set; } = string.Empty;

        public Guid ThemeId { get; set; }

        public QuestionOrderType QuestionOrderType { get; set; }
    }
}

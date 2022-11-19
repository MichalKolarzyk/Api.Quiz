using Domain.Quiz.Abstracts;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Exceptions
{
    public class QuizVaidationExceptionHandler : IRequestHandler<QuizVaidationException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(QuizVaidationException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 444,
                Errors = request.ValidationResult.Errors.GroupBy(e => e.PropertyName).ToDictionary(v => v.Key, v => v.FirstOrDefault().ErrorMessage)
            });
        }
    }
}

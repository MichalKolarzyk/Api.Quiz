using Domain.Quiz.Abstracts;
using Domain.Quiz.Exceptions;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.GeneralExceptions
{
    public class DomainValidationExceptionHandler : IRequestHandler<DomainValidationException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(DomainValidationException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 403,
                Errors = request.ValidationResult.Errors.ToDictionary(v => v.PropertyName, v => v.ErrorMessage)
            });
        }
    }
}

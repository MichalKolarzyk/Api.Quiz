using Domain.Quiz.Abstracts;
using Domain.Quiz.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.GeneralExceptions
{
    public class NotFoundDomainExceptionHandler : IRequestHandler<NotFoundDomainException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(NotFoundDomainException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 404,
                Errors = new() { { nameof(NotFoundDomainException.ErrorMessage), request.ErrorMessage } }
            });
        }
    }
}

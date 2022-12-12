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
    internal class UnprocessableEntityDomainExceptionHandler : IRequestHandler<UnprocessableEntityDomainException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(UnprocessableEntityDomainException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 422,
                Errors = new() { { request.Key ?? nameof(NotFoundDomainException.ErrorMessage), request.ErrorMessage } }
            });
        }
    }
}

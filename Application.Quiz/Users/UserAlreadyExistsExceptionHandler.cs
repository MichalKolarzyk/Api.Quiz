using Domain.Quiz.Abstracts;
using Domain.Quiz.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Users
{
    public class UserAlreadyExistsExceptionHandler : IRequestHandler<UserAlreadyExistsException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(UserAlreadyExistsException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 404,
                Errors = new Dictionary<string, string>()
                {
                    {nameof(UserAggregate.Login), "User with this login already exists" }
                }
            });
        }
    }
}

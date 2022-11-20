using Domain.Quiz.Abstracts;
using Domain.Quiz.Account;
using MediatR;

namespace Application.Quiz.Account
{
    public class AccountAlreadyExistsExceptionHandler : IRequestHandler<AccountAlreadyExistsException, ErrorMessage>
    {
        public async Task<ErrorMessage> Handle(AccountAlreadyExistsException request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new ErrorMessage
            {
                StatusCode = 404,
                Errors = new Dictionary<string, string>()
                {
                    {nameof(AccountAggregate.Login), "Account with this login already exists" }
                }
            });
        }
    }
}

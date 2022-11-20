using Application.Quiz.Database;
using Domain.Quiz.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Account
{
    internal class LoginToAccountCommandHandler : IRequestHandler<LoginToAccountCommand, LoginToAccountResponse>
    {
        IRepository<AccountAggregate> _userRepository;

        public LoginToAccountCommandHandler(IRepository<AccountAggregate> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginToAccountResponse> Handle(LoginToAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetOne(u => u.Login == request.Login);
            if (user != null)
                throw new AccountAlreadyExistsException();

            return new LoginToAccountResponse
            {
                Succeed = true,
                Token = "Token",
            };
        }
    }
}

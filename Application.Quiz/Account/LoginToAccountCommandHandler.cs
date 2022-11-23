using Application.Quiz.Authentications;
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
        IAuthenticationTokenService _authenticationTokenService;

        public LoginToAccountCommandHandler(IRepository<AccountAggregate> userRepository, IAuthenticationTokenService authenticationTokenService)
        {
            _userRepository = userRepository;
            _authenticationTokenService = authenticationTokenService;
        }

        public async Task<LoginToAccountResponse> Handle(LoginToAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Login == request.Login);

            var token = _authenticationTokenService.GenerateToken(new GenerateTokenData
            {
                Name = user.Login,
                NameIdentifier = user.Id.ToString(),
            });

            return new LoginToAccountResponse
            {
                Token = token
            };
        }
    }
}

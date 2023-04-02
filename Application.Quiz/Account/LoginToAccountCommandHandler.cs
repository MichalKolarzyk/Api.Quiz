using Application.Quiz.Authentications;
using Application.Quiz.Database;
using Domain.Quiz.Account;
using Domain.Quiz.Exceptions;
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
        IAuthenticationSettings _authenticationSettings;

        public LoginToAccountCommandHandler(IRepository<AccountAggregate> userRepository, IAuthenticationTokenService authenticationTokenService, IAuthenticationSettings authenticationSettings)
        {
            _userRepository = userRepository;
            _authenticationTokenService = authenticationTokenService;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<LoginToAccountResponse> Handle(LoginToAccountCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            var user = await _userRepository.GetAsync(u => u.Login == request.Login);
            if (user == null)
                throw Result.DomainException(new Error("Wrong user name or password.", 404));

            if(user.HashPassword != request.Password)
                throw Result.DomainException(new Error("Wrong user name or password.", 404));

            var expires = DateTime.Now.AddSeconds(_authenticationSettings.ExpireTimeInSeconds);
            var token = _authenticationTokenService.GenerateToken(new GenerateTokenData
            {
                Name = user.Login,
                NameIdentifier = user.Id.ToString(),
                Expires = expires,
            });

            return new LoginToAccountResponse
            {
                Token = token,
                Expires = expires,
            };
        }
    }
}

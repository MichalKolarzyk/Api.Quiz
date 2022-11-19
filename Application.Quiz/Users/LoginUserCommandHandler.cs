using Application.Quiz.Database;
using Domain.Quiz.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Users
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        IRepository<UserAggregate> _userRepository;

        public LoginUserCommandHandler(IRepositoryFactory repositoryFactory)
        {
            _userRepository = repositoryFactory.Create<UserAggregate>();
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetOne(u => u.Login == request.Login);
            if (user != null)
                throw new UserAlreadyExistsException();

            return new LoginUserResponse
            {
                Succeed = true,
                Token = "Token",
            };
        }
    }
}

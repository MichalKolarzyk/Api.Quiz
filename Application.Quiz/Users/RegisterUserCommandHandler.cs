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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        IRepository<UserAggregate> _repository;

        public RegisterUserCommandHandler(IRepository<UserAggregate> repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new UserAggregate(request.Login, request.Password);
            _repository.InsertOne(newUser);
            _repository.Save();
            return Unit.Task;
        }
    }
}

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
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        IRepository<AccountAggregate> _repository;

        public RegisterAccountCommandHandler(IRepository<AccountAggregate> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var userWithTheSameLogin = await _repository.GetAsync(a => a.Login == request.Login);
            if (userWithTheSameLogin != null)
                result.AddError(new Error("Login is already taken.", nameof(request.Login), 422));

            if (request.Password.Length < 6)
                result.AddError(new Error("Password is to short", nameof(request.Password), 422));

            if (request.Password != request.RepetePassword)
                result.AddError(new Error("Passwords are not match.", nameof(request.RepetePassword), 422));

            if (result.HasErrors)
                throw result.ToException();

            var newUser = new AccountAggregate(request.Login, request.Password);
            await _repository.InsertAsync(newUser);
            return Unit.Value;
        }
    }
}

﻿using Application.Quiz.Database;
using Domain.Quiz.Account;
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
            var newUser = new AccountAggregate(request.Login, request.Password);
            await _repository.InsertAsync(newUser);
            return Unit.Value;
        }
    }
}

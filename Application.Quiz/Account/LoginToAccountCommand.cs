using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Account
{
    public class LoginToAccountCommand : IRequest<LoginToAccountResponse>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public class LoginToAccountCommandValidator : AbstractValidator<LoginToAccountCommand>
    {
        public LoginToAccountCommandValidator()
        {
            RuleFor(r => r.Login).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}

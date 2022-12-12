using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Account
{
    public class RegisterAccountCommand : IRequest
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RepetePassword { get; set; } = string.Empty;
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor((c) => c.Password)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor((c) => c.Login)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor((c) => c.RepetePassword)
                .Equal(c => c.Password)
                .WithMessage("Passwords are not match");
        }
    }
}

using Domain.Quiz.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Quiz.Account;

namespace Api.Quiz.Controllers.AccountControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<RegisterAccountCommand> _registerUserCommandValidator;

        public AccountController(IMediator mediator, IValidator<RegisterAccountCommand> registerUserCommandValidator)
        {
            _mediator = mediator;
            _registerUserCommandValidator = registerUserCommandValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountCommand registerAccountCommand)
        {
            var result = _registerUserCommandValidator.Validate(registerAccountCommand);
            if (!result.IsValid)
                throw new DomainValidationException(result);

            await _mediator.Send(registerAccountCommand);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginToAccountResponse>> Login([FromBody] LoginToAccountCommand loginUserCommand)
        {
            var loginResult = await _mediator.Send(loginUserCommand);

            return Ok(loginResult);
        }
    }
}

using Domain.Quiz.Exceptions;
using Domain.Quiz.Quizzes;
using Domain.Quiz.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.UserControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<RegisterUserCommand> _registerUserCommandValidator;

        public UserController(IMediator mediator, IValidator<RegisterUserCommand> registerUserCommandValidator)
        {
            _mediator = mediator;
            _registerUserCommandValidator = registerUserCommandValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var result = _registerUserCommandValidator.Validate(registerUserCommand);
            if (!result.IsValid)
                throw new DomainValidationException(result);

            await _mediator.Send(registerUserCommand);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var loginResult = await _mediator.Send(loginUserCommand);

            return Ok(loginResult);
        }
    }
}

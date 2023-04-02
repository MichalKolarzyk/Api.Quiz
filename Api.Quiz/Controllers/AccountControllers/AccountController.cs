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

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountCommand registerAccountCommand)
        {
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

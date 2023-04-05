using Domain.Quiz.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Quiz.Accounts;
using Application.Quiz.Database;
using Microsoft.AspNetCore.Authorization;
using Api.Quiz.Services;
using Domain.Quiz.Accounts;
using Api.Quiz.Controllers.AccountControllers.Dtos;
using Application.Quiz.Services;

namespace Api.Quiz.Controllers.AccountControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentIdentity _currentIdentity;
        private readonly IRepository<Account> _accountRepository;

        public AccountController(IMediator mediator, ICurrentIdentity contextService, IRepository<Account> accountRepository)
        {
            _mediator = mediator;
            _currentIdentity = contextService;
            _accountRepository = accountRepository;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var accountId = _currentIdentity.AccountId;

            var account = await _accountRepository.GetAsync(u => u.Id == accountId);

            return new AccountDto
            {
                Login= account.Login,
                Language= account.Language,
            };
        }
    }
}

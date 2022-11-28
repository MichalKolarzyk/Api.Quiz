using Api.Quiz.Services;
using Application.Quiz.Database;
using Application.Quiz.QuizSession;
using Domain.Quiz.UserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuizSessionControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuizSessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<UserProfileAggregate> _userProfileRepository;
        private readonly HttpContextService _httpContextService;


        public QuizSessionController(IMediator mediator, IRepository<UserProfileAggregate> userProfileRepository, HttpContextService httpContextService)
        {
            _mediator = mediator;
            _userProfileRepository = userProfileRepository;
            _httpContextService = httpContextService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateQuizSessionDto createQuizSessionDto)
        {

            var accountId = _httpContextService.GetAccountId();
            var sessionOwner = await _userProfileRepository.GetAsync(p => p.AccountId == accountId);

            var createQuizSessionCommand = new CreateQuizSessionCommand
            {
                QuizId = createQuizSessionDto.QuizId,
                QuizPickQuestionType = createQuizSessionDto.QuizPickQuestionType,
                SessionOwnerId = sessionOwner.Id,
                StartTime = createQuizSessionDto.StartTime,
                TimeForQuestionInSecounds = createQuizSessionDto.TimeForQuestionInSecounds,
                QuestionAmount = createQuizSessionDto.QuestionAmount,
            };
            await _mediator.Send(createQuizSessionCommand);

            return Ok();

        }

        [HttpPost("{quizSessionId}/start")]
        public async Task<IActionResult> Start([FromRoute] Guid quizSessionId)
        {
            await _mediator.Send(new StartQuizSessionCommand { QuizSessionId = quizSessionId });

            return Ok();
        }
    }
}

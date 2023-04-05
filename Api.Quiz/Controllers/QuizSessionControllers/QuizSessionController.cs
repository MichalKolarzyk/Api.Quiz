using Api.Quiz.Services;
using Application.Quiz.Database;
using Application.Quiz.QuizSession;
using Application.Quiz.Services;
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
        private readonly ICurrentIdentity _currentIdentity;


        public QuizSessionController(IMediator mediator, ICurrentIdentity currentIdentity)
        {
            _mediator = mediator;
            _currentIdentity = currentIdentity;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateQuizSessionDto createQuizSessionDto)
        {

            var sessionOwnerId = _currentIdentity.AccountId;

            var createQuizSessionCommand = new CreateQuizSessionCommand
            {
                QuizId = createQuizSessionDto.QuizId,
                QuizPickQuestionType = createQuizSessionDto.QuizPickQuestionType,
                SessionOwnerId = sessionOwnerId ?? Guid.Empty,
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

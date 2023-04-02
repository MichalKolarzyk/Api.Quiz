using Application.Quiz.Quizzes;
using Domain.Quiz.Exceptions;
using Domain.Quiz.Quizzes;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuizControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            var createdQuiz = await _mediator.Send(createQuizCommand);
            return Ok(createdQuiz.Id);
        }

        [HttpPut("{quizId}/update")]
        public async Task<IActionResult> Update([FromRoute] Guid quizId, [FromBody] UpdateQuizDto updateQuizDto)
        {
            await _mediator.Send(new UpdateQuizCommand
            {
                QuizId = quizId,
                QuestionIds = updateQuizDto.QuestionIds,
            });

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<GetQuizesResponse>> GetQuizes([FromQuery] GetQuizesCommand getQuizesCommand)
        {
            return await _mediator.Send(getQuizesCommand);
        }
    }
}

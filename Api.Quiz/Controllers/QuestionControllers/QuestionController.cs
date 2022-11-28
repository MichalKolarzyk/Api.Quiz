using Application.Quiz.Questions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuestionControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto createQuestion)
        {
            await _mediator.Send(new CreateQuestionCommand
            {
                WorkspaceId = createQuestion.WorkspaceId,
                Answers = createQuestion.Answers,
                CorrectAnswerIndex = createQuestion.CorrectAnswerIndex,
                Description = createQuestion.Description,
            });

            return Ok();
        }

        [HttpPut("{questionId}/update")]
        public async Task<IActionResult> Update([FromRoute] Guid questionId, [FromBody] UpdateQuestionDto createQuestion)
        {
            await _mediator.Send(new UpdateQuestionCommand
            {
                Id = questionId,
                WorkspaceId = createQuestion.WorkspaceId,
                Answers = createQuestion.Answers,
                CorrectAnswerIndex = createQuestion.CorrectAnswerIndex,
                Description = createQuestion.Description,
            });
            return Ok();
        }
    }
}
